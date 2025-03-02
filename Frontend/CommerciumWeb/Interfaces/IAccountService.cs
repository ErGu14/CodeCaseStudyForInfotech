using CommerciumWeb.Models.AccountModels;
using CommerciumWeb.Models.ECommerce.MVC.Models;
using CommerciumWeb.Models;

namespace CommerciumWeb.Interfaces
{
    public interface IAccountService
    {
        Task<ReturnModel<TokenModel>> LoginAsync(LoginModel loginModel);
        Task<ReturnModel<string>> RegisterAsync(RegisterModel registerModel);
        Task<ReturnModel<string>> ResetPasswordAsync(ResetPasswordModel resetPasswordModel);
        Task<ReturnModel<string>> ConfirmEmailAsync(string token);
        Task<ReturnModel<string>> ChangeEmailAsync(ChangeEmailModel changeEmailModel);
        Task<ReturnModel<string>> ChangePasswordAsync(ChangePasswordModel changePasswordModel);
        Task<ReturnModel<string>> ChangeUserRoleAsync(ChangeUserRoleModel changeUserRoleModel);
        Task<ReturnModel<string>> ApproveUserAsync(string userId);
        Task<ReturnModel<string>> UpdateUserProfileAsync(UpdateUserProfileModel updateUserProfileModel);
        Task<ReturnModel<string>> CustomizeProfileAsync(CustomizeUserProfileModel customizeUserProfileModel);
        Task<ReturnModel<IEnumerable<UserModel>>> GetAllUsersAsync();
        Task<ReturnModel<IEnumerable<UserModel>>> GetUsersWithBusinessInfoAsync();
        Task<ReturnModel<UserModel>> GetUserWithBusinessInfoAsync(string userId);
        Task<ReturnModel<UserModel>> GetUserAsync(string userId);
        Task<ReturnModel<string>> BanUserAsync(string userId, bool isPermanent);
        Task<ReturnModel<string>> UnbanUserAsync(string userId);
    }
}
