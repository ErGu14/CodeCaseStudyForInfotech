using Commercium.Service.Interfaces;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.AccountRMs;
using Commercium.Shared.Users.UserProfileCustomizationRMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commercium.API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : CustomizingController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRM loginRM)
        {
            var response = await _accountService.LoginAsync(loginRM);
            return CreateReturn(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRM registerRM)
        {
            var response = await _accountService.RegisterAsync(registerRM);
            return CreateReturn(response);
        }

        [Authorize]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRM resetPasswordRM)
        {
            var response = await _accountService.ResetPasswordAsync(resetPasswordRM);
            return CreateReturn(response);
        }

        [Authorize]
        [HttpPost("change-email")]
        public async Task<IActionResult> ChangeEmail([FromBody] ChangeEmailRM changeEmailRM)
        {
            var response = await _accountService.ChangeEmailAsync(changeEmailRM);
            return CreateReturn(response);
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRM changePasswordRM)
        {
            var response = await _accountService.ChangePasswordAsync(changePasswordRM);
            return CreateReturn(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("change-user-role")]
        public async Task<IActionResult> ChangeUserRole([FromBody] ChangeUserRoleRM changeUserRoleRM)
        {
            var response = await _accountService.ChangeUserRoleAsync(changeUserRoleRM);
            return CreateReturn(response);
        }
        [Authorize]
        [HttpPost("update-profile")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileRM updateUserProfileRM)
        {
            var response = await _accountService.UpdateUserProfileAsync(updateUserProfileRM);
            return CreateReturn(response);
        }

        [Authorize]
        [HttpPost("customize-profile")]
        public async Task<IActionResult> CustomizeProfile([FromBody] UpdateUserProfileCustomizationRM updateUserProfileCustomizationRM)
        {
            var response = await _accountService.CustomizeProfileAsync(updateUserProfileCustomizationRM);
            return CreateReturn(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _accountService.GetAllUsersAsync();
            return CreateReturn(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("get-users-with-business-info")]
        public async Task<IActionResult> GetUsersWithBusinessInfo()
        {
            var response = await _accountService.GetUsersWithBusinessInfoAsync();
            return CreateReturn(response);
        }

        [Authorize]
        [HttpGet("get-user-with-business-info/{userId}")]
        public async Task<IActionResult> GetUserWithBusinessInfo(string userId)
        {
            var response = await _accountService.GetUserWithBusinessInfoAsync(userId);
            return CreateReturn(response);
        }

        [Authorize]
        [HttpGet("get-user/{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var response = await _accountService.GetUserAsync(userId);
            return CreateReturn(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("ban-user")]
        public async Task<IActionResult> BanUser([FromQuery] string userId, [FromQuery] bool isPermanent)
        {
            var response = await _accountService.BanUserAsync(userId, isPermanent);
            return CreateReturn(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("unban-user")]
        public async Task<IActionResult> UnbanUser([FromQuery] string userId)
        {
            var response = await _accountService.UnbanUserAsync(userId);
            return CreateReturn(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("approve-user/{userId}")]
        public async Task<IActionResult> ApproveUser(string userId)
        {
            var response = await _accountService.ApproveUserAsync(userId);
            return CreateReturn(response);
        }
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token)
        {
            var response = await _accountService.ConfirmEmailAsync(token);
            return CreateReturn(response);
        }


    }

}
