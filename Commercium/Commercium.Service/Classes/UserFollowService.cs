using AutoMapper;
using Commercium.Data.Interfaces;
using Commercium.Entity.User.Account;
using Commercium.Entity.User;
using Commercium.Service.Interfaces;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.AccountRMs;
using Commercium.Shared.Users.UserFollowRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Classes
{
    public class UserFollowService : IUserFollowService
    {
        private readonly IGenericManager<UserFollow> _userFollowManager;
        private readonly IGenericManager<AppUser> _userManager;
        private readonly ITransactionManager _transactionManager;
        private readonly IMapper _mapper;

        public UserFollowService(
            IGenericManager<UserFollow> userFollowManager,
            IGenericManager<AppUser> userManager,
            ITransactionManager transactionManager,
            IMapper mapper)
        {
            _userFollowManager = userFollowManager;
            _userManager = userManager;
            _transactionManager = transactionManager;
            _mapper = mapper;
        }

        // Takip Etme
        public async Task<ReturnRM<string>> FollowUserAsync(CreateUserFollowRM createUserFollowRM)
        {
            // Kullanıcının zaten takipte olup olmadığını kontrol et
            var existingFollow = await _userFollowManager.GetAsync(
                uf => uf.FollowerId == createUserFollowRM.FollowerId && uf.FollowedId == createUserFollowRM.FollowedId
            );

            if (existingFollow != null)
            {
                return ReturnRM<string>.Fail("Kullanıcı zaten takip ediliyor.", 400);
            }

            // Takip işlemine başla
            var userFollow = new UserFollow
            {
                FollowerId = createUserFollowRM.FollowerId,
                FollowedId = createUserFollowRM.FollowedId
            };

            try
            {
                // Takip ekle
                await _userFollowManager.AddAsync(userFollow);
                await _transactionManager.SaveAsync();  // Değişiklikleri kaydet
            }
            catch (Exception ex)
            {
                return ReturnRM<string>.Fail(ex.Message, 500);  // Hata durumu
            }

            return ReturnRM<string>.Success("Kullanıcı başarıyla takip edildi.", 201);  // Başarılı dönüş
        }

        // Takipten Çıkma
        public async Task<ReturnRM<string>> UnfollowUserAsync(string followerId, string followedId)
        {
            // Takip var mı diye kontrol et
            var follow = await _userFollowManager.GetAsync(
                uf => uf.FollowerId == followerId && uf.FollowedId == followedId
            );

            if (follow == null)
            {
                return ReturnRM<string>.Fail("Takip bulunamadı.", 404);
            }

            try
            {
                // Takipten çıkma işlemi
                _userFollowManager.Delete(follow);
                await _transactionManager.SaveAsync();  // Değişiklikleri kaydet
            }
            catch (Exception ex)
            {
                return ReturnRM<string>.Fail(ex.Message, 500);  // Hata durumu
            }

            return ReturnRM<string>.Success("Takip başarıyla sonlandırıldı.", 200);  // Başarılı dönüş
        }

        // Takipçileri Getirme
        public async Task<ReturnRM<IEnumerable<AppUserRM>>> GetFollowersAsync(string userId)
        {
            var followers = await _userFollowManager.GetAllAsync(uf => uf.FollowedId == userId);
            var followerUsers = new List<AppUserRM>();

            foreach (var follow in followers)
            {
                var user = _userManager.GetByIdAsync(follow.FollowerId);  // Kullanıcıyı al
                followerUsers.Add(_mapper.Map<AppUserRM>(user));  // AutoMapper kullanarak dönüşüm yapıyoruz
            }

            return ReturnRM<IEnumerable<AppUserRM>>.Success(followerUsers, 200);  // Takipçileri döndür
        }

        // Takip Edilen Kullanıcıları Getirme
        public async Task<ReturnRM<IEnumerable<AppUserRM>>> GetFollowingAsync(string userId)
        {
            var following = await _userFollowManager.GetAllAsync(uf => uf.FollowerId == userId);
            var followedUsers = new List<AppUserRM>();

            foreach (var follow in following)
            {
                var user = _userManager.GetByIdAsync(follow.FollowedId);  // Takip edilen kullanıcıyı al
                followedUsers.Add(_mapper.Map<AppUserRM>(user));  // AutoMapper kullanarak dönüşüm yapıyoruz
            }

            return ReturnRM<IEnumerable<AppUserRM>>.Success(followedUsers, 200);  // Takip edilenleri döndür
        }

        // Takip Durumu Kontrolü
        public async Task<ReturnRM<bool>> IsUserFollowingAsync(string followerId, string followedId)
        {
            var follow = await _userFollowManager.GetAsync(
                uf => uf.FollowerId == followerId && uf.FollowedId == followedId
            );

            return ReturnRM<bool>.Success(follow != null, 200);  // Takip var mı?
        }

        // Takipçi Sayısını Getirme
        public async Task<ReturnRM<int>> GetFollowerCountAsync(string userId)
        {
            var followerCount = await _userFollowManager.CountAsync(uf => uf.FollowedId == userId);
            return ReturnRM<int>.Success(followerCount, 200);  // Takipçi sayısını döndür
        }

        // Takip Edilen Sayısını Getirme
        public async Task<ReturnRM<int>> GetFollowingCountAsync(string userId)
        {
            var followingCount = await _userFollowManager.CountAsync(uf => uf.FollowerId == userId);
            return ReturnRM<int>.Success(followingCount, 200);  // Takip edilen sayısını döndür
        }

        
    }




}
