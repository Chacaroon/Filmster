using BLL.Services;
using SharedKernel.Abstractions.BLL.Services;
using SimpleInjector;

namespace BLL.IoC
{
	public static class Bootstrapper
	{
		public static void Bootstrap(Container container)
		{
			container.Register<ITokenService, TokenService>();
			container.Register<IAuthService, AuthService>();
			container.Register<IFilmService, FilmService>();

			DAL.IoC.Bootstrapper.Bootstrap(container);
		}
	}
}
