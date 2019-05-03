using AutoMapper;
using AutoMapper.Configuration;
using Filmster.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
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

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

			InitializeContainer(app);

			app.UseHttpsRedirection();

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});

			app.UseMvc();
		}

		private void Bootstrap()
		{
			Bootstrapper.Bootstrap(_container);

			MapperBootstrapper.Bootstrap(_cfg);

			Mapper.Initialize(_cfg);
		}

		private void IntegrateSimpleInjector(IServiceCollection services)
		{
			_container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

			services.AddHttpContextAccessor();

			services.AddSingleton<IControllerActivator>(
				new SimpleInjectorControllerActivator(_container));

			services.EnableSimpleInjectorCrossWiring(_container);
			services.UseSimpleInjectorAspNetRequestScoping(_container);
		}

		private void InitializeContainer(IApplicationBuilder app)
		{
			// Add application presentation components:
			_container.RegisterMvcControllers(app);
			_container.RegisterMvcViewComponents(app);

			// Allow Simple Injector to resolve services from ASP.NET Core.
			_container.AutoCrossWireAspNetComponents(app);
		}
	}
}
