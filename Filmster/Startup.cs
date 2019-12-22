using System.Text;
using AutoMapper;
using AutoMapper.Configuration;
using DAL;
using DAL.Entities;
using Filmster.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using Swashbuckle.AspNetCore.Swagger;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Filmster
{
	public class Startup
	{
		private readonly Container _container = new Container();
		private readonly MapperConfigurationExpression _cfg = new MapperConfigurationExpression();

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			IntegrateSimpleInjector(services);

			Bootstrap();

			services.AddHttpContextAccessor();

			services.AddDbContext<ApplicationContext>(options => 
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<User, IdentityRole<long>>(options =>
			        {
				        options.Password.RequireNonAlphanumeric = false;
			        })
			        .AddEntityFrameworkStores<ApplicationContext>();

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
					.AddJwtBearer(options =>
					{
						options.RequireHttpsMetadata = false;
						options.TokenValidationParameters = new TokenValidationParameters
						{
							ValidateIssuer = true,
							ValidIssuer = Configuration["AuthOptions:ISSUER"],
							ValidateAudience = true,
							ValidAudience = Configuration["AuthOptions:AUDIENCE"],
							ValidateLifetime = true,
							IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["AuthOptions:KEY"])),
							ValidateIssuerSigningKey = true,
						};
					});


			services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Latest);
			// services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseRouting();

			InitializeContainer(app);

			app.UseCors(builder =>
							builder.AllowAnyHeader()
								   .AllowAnyMethod()
								   .AllowCredentials()
								   .WithOrigins("http://localhost:4200", "https://filmster.azurewebsite.com"));

			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
		}

		private void Bootstrap()
		{
			Bootstrapper.Bootstrap(_container);

			MapperBootstrapper.Bootstrap(_cfg);

			_cfg.ForAllPropertyMaps(pm => !pm.Ignored,
									(pm, c) => c.PreCondition(o => !o.GetType().IsDefaultValue(o)));

			Mapper.Initialize(_cfg);
		}

		private void IntegrateSimpleInjector(IServiceCollection services)
		{
			_container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

			services.AddSingleton<IControllerActivator>(
				new SimpleInjectorControllerActivator(_container));

			services.EnableSimpleInjectorCrossWiring(_container);
			services.UseSimpleInjectorAspNetRequestScoping(_container);
		}

		private void InitializeContainer(IApplicationBuilder app)
		{
			// Add application presentation components:
			_container.RegisterMvcControllers(app);
			// _container.RegisterMvcViewComponents(app);

			// Allow Simple Injector to resolve services from ASP.NET Core.
			_container.AutoCrossWireAspNetComponents(app);
		}
	}
}
