using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.AccountRMs;
using Commercium.Shared.Users.UserFollowRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Interfaces
{
    public interface IUserFollowService
    {
        // Takip Etme / Takipten Çıkma
        Task<ReturnRM<string>> FollowUserAsync(CreateUserFollowRM createUserFollowRM);
        Task<ReturnRM<string>> UnfollowUserAsync(string followerId, string followedId);

        // Takipçi & Takip Edilen Kullanıcıları Getirme
        Task<ReturnRM<IEnumerable<AppUserRM>>> GetFollowersAsync(string userId);
        Task<ReturnRM<IEnumerable<AppUserRM>>> GetFollowingAsync(string userId);

        // Takip Durumu Kontrolü
        Task<ReturnRM<bool>> IsUserFollowingAsync(string followerId, string followedId);

        // Takipçi & Takip Sayısını Getirme
        Task<ReturnRM<int>> GetFollowerCountAsync(string userId);
        Task<ReturnRM<int>> GetFollowingCountAsync(string userId);

       
    }


}
