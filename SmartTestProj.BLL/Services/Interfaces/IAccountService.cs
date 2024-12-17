using SmartTestProj.BLL.Dto;
using SmartTestProj.BLL.Dto.Account;

namespace SmartTestProj.BLL.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Result<TokenDto>> SignIn(SignInDto model);
    }
}