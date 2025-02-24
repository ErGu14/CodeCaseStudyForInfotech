using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.AccountRMs;
using Commercium.Shared.Users.UserProfileCustomizationRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Interfaces
{
    public interface IAccountService
    {
        //  Kimlik Doğrulama İşlemleri
        Task<ReturnRM<TokenRM>> LoginAsync(LoginRM loginRM);
        Task<ReturnRM<string>> RegisterAsync(RegisterRM registerRM);
        Task<ReturnRM<string>> ResetPasswordAsync(ResetPasswordRM resetPasswordRM);

        //  Kullanıcı Bilgi Güncellemeleri
        Task<ReturnRM<string>> ChangeEmailAsync(ChangeEmailRM changeEmailRM);
        Task<ReturnRM<string>> ChangePasswordAsync(ChangePasswordRM changePasswordRM);
        Task<ReturnRM<string>> ChangeUserRoleAsync(ChangeUserRoleRM changeUserRoleRM);

        //  Profil Özelleştirme
        Task<ReturnRM<string>> UpdateUserProfileAsync(UpdateUserProfileRM updateUserProfileRM);
        Task<ReturnRM<string>> CustomizeProfileAsync(UpdateUserProfileCustomizationRM updateUserProfileCustomizationRM);

        //  Kullanıcı Yönetimi
        Task<ReturnRM<IEnumerable<AppUserRM>>> GetAllUsersAsync(); // Tüm kullanıcıları getirir
        Task<ReturnRM<IEnumerable<AppUserRM>>> GetUsersWithBusinessInfoAsync(); // Tüm kullanıcıları çalıştığı eğer bir hizmet varsa onlar beraber getirir
        Task<ReturnRM<AppUserRM>> GetUserWithBusinessInfoAsync(string userId); // Tek bir kullanıcıyı bağlı olduğu hizmetle getirme
        Task<ReturnRM<AppUserRM>> GetUserAsync(string userId); // Tek bir kullanıcı getirme


        Task<ReturnRM<string>> BanUserAsync(string userId, bool isPermanent); // Kullanıcı yasaklama
        Task<ReturnRM<string>> UnbanUserAsync(string userId); // Kullanıcı yasağını kaldırma
    }

}
