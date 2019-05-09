using System.Threading.Tasks;
using SharedKernel.Abstractions.BLL.DTOs.Auth;

namespace SharedKernel.Abstractions.BLL.Services
{
	public interface IAuthService
	{
		Task<ILoginSuccessDTO> LoginAsync(ILoginDTO dto);
		Task<ILoginSuccessDTO> RegisterAsync(IRegisterDTO dto);
		Task<ILoginSuccessDTO> RefreshTokenAsync(IRefreshTokenDTO dto);
	}
}
