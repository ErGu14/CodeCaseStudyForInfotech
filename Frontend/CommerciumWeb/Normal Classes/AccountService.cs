using CommerciumWeb.Bases;
using CommerciumWeb.Models.AccountModels;
using CommerciumWeb.Models.ECommerce.MVC.Models;
using CommerciumWeb.Models;
using System.Text.Json;
using CommerciumWeb.Interfaces;

namespace CommerciumWeb.Normal_Classes
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ReturnModel<TokenModel>> LoginAsync(LoginModel loginModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("account/login", loginModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<TokenModel>>(responseBody, _jsonSerializerOptions);
            }
            catch
            {
                return new ReturnModel<TokenModel> { Errors = new List<string> { "Bir hata oluştu." } };
            }
        }

        public async Task<ReturnModel<string>> RegisterAsync(RegisterModel registerModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("account/register", registerModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch
            {
                return new ReturnModel<string> { Errors = new List<string> { "Bir hata oluştu." } };
            }
        }

        public async Task<ReturnModel<string>> ResetPasswordAsync(ResetPasswordModel resetPasswordModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("account/reset-password", resetPasswordModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch
            {
                return new ReturnModel<string> { Errors = new List<string> { "Bir hata oluştu." } };
            }
        }

        public async Task<ReturnModel<string>> ConfirmEmailAsync(string token)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"account/confirm-email?token={token}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch
            {
                return new ReturnModel<string> { Errors = new List<string> { "Bir hata oluştu." } };
            }
        }

        public async Task<ReturnModel<string>> ChangeEmailAsync(ChangeEmailModel changeEmailModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("account/change-email", changeEmailModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch
            {
                return new ReturnModel<string> { Errors = new List<string> { "Bir hata oluştu." } };
            }
        }

        public async Task<ReturnModel<string>> ChangePasswordAsync(ChangePasswordModel changePasswordModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("account/change-password", changePasswordModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch
            {
                return new ReturnModel<string> { Errors = new List<string> { "Bir hata oluştu." } };
            }
        }

        public async Task<ReturnModel<string>> ChangeUserRoleAsync(ChangeUserRoleModel changeUserRoleModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("account/change-user-role", changeUserRoleModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch
            {
                return new ReturnModel<string> { Errors = new List<string> { "Bir hata oluştu." } };
            }
        }

        public async Task<ReturnModel<string>> ApproveUserAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsync($"account/approve-user/{userId}", null);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch
            {
                return new ReturnModel<string> { Errors = new List<string> { "Bir hata oluştu." } };
            }
        }

        public async Task<ReturnModel<string>> UpdateUserProfileAsync(UpdateUserProfileModel updateUserProfileModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PutAsJsonAsync("account/update-profile", updateUserProfileModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch
            {
                return new ReturnModel<string> { Errors = new List<string> { "Bir hata oluştu." } };
            }
        }

        public async Task<ReturnModel<string>> CustomizeProfileAsync(CustomizeUserProfileModel customizeUserProfileModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("account/customize-profile", customizeUserProfileModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch
            {
                return new ReturnModel<string> { Errors = new List<string> { "Bir hata oluştu." } };
            }
        }

        public async Task<ReturnModel<IEnumerable<UserModel>>> GetAllUsersAsync()
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync("account/get-all-users");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<UserModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch
            {
                return new ReturnModel<IEnumerable<UserModel>> { Errors = new List<string> { "Bir hata oluştu." } };
            }
        }

        public async Task<ReturnModel<UserModel>> GetUserAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"account/get-user/{userId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<UserModel>>(responseBody, _jsonSerializerOptions);
            }
            catch
            {
                return new ReturnModel<UserModel> { Errors = new List<string> { "Bir hata oluştu." } };
            }
        }

        public async Task<ReturnModel<string>> BanUserAsync(string userId, bool isPermanent)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsync($"account/ban-user?userId={userId}&isPermanent={isPermanent}", null);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch
            {
                return new ReturnModel<string> { Errors = new List<string> { "Bir hata oluştu." } };
            }
        }

        public async Task<ReturnModel<string>> UnbanUserAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsync($"account/unban-user?userId={userId}", null);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch
            {
                return new ReturnModel<string> { Errors = new List<string> { "Bir hata oluştu." } };
            }
        }

        public async Task<ReturnModel<IEnumerable<UserModel>>> GetUsersWithBusinessInfoAsync()
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync("account/get-users-with-business-info");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<UserModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch
            {
                return new ReturnModel<IEnumerable<UserModel>> { Errors = new List<string> { "Bir hata oluştu." } };
            }
        }

        public async Task<ReturnModel<UserModel>> GetUserWithBusinessInfoAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"account/get-user-with-business-info/{userId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<UserModel>>(responseBody, _jsonSerializerOptions);
            }
            catch
            {
                return new ReturnModel<UserModel> { Errors = new List<string> { "Bir hata oluştu." } };
            }
        }

    }
}
