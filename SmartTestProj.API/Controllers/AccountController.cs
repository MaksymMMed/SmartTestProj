using Microsoft.AspNetCore.Mvc;
using SmartTestProj.BLL.Dto.Account;
using SmartTestProj.BLL.Services.Interfaces;

namespace SmartTestProj.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto model)
        {
            var result = await _accountService.SignIn(model);

            if (!result.IsSuccess)
                return Unauthorized(result.Error);

            return Ok(result.Value);
        }
    }
}
