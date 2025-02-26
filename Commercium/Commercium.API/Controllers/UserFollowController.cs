using Commercium.Service.Interfaces;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.UserFollowRMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commercium.API.Controllers
{
    [ApiController]
    [Route("api/user-follow")]
    public class UserFollowController : CustomizingController
    {
        private readonly IUserFollowService _userFollowService;

        public UserFollowController(IUserFollowService userFollowService)
        {
            _userFollowService = userFollowService;
        }

        // Kullanıcı Takip Etme - User ve SalesRepresentative erişebilir
        [Authorize(Roles = "User, SalesRepresentative")]
        [HttpPost("follow")]
        public async Task<IActionResult> FollowUser([FromBody] CreateUserFollowRM createUserFollowRM)
        {
            var response = await _userFollowService.FollowUserAsync(createUserFollowRM);
            return CreateReturn(response);
        }

        // Kullanıcı Takipten Çıkma - User ve SalesRepresentative erişebilir
        [Authorize(Roles = "User, SalesRepresentative")]
        [HttpPost("unfollow")]
        public async Task<IActionResult> UnfollowUser([FromQuery] string followerId, [FromQuery] string followedId)
        {
            var response = await _userFollowService.UnfollowUserAsync(followerId, followedId);
            return CreateReturn(response);
        }

        // Kullanıcının Takipçilerini Getirme - User ve Admin erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpGet("followers/{userId}")]
        public async Task<IActionResult> GetFollowers(string userId)
        {
            var response = await _userFollowService.GetFollowersAsync(userId);
            return CreateReturn(response);
        }

        // Kullanıcının Takip Ettiklerini Getirme - User ve Admin erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpGet("following/{userId}")]
        public async Task<IActionResult> GetFollowing(string userId)
        {
            var response = await _userFollowService.GetFollowingAsync(userId);
            return CreateReturn(response);
        }

        // Kullanıcının Takip Durumunu Kontrol Etme - User ve Admin erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpGet("is-following")]
        public async Task<IActionResult> IsUserFollowing([FromQuery] string followerId, [FromQuery] string followedId)
        {
            var response = await _userFollowService.IsUserFollowingAsync(followerId, followedId);
            return CreateReturn(response);
        }

        // Kullanıcının Takipçi Sayısını Getirme - User ve Admin erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpGet("follower-count/{userId}")]
        public async Task<IActionResult> GetFollowerCount(string userId)
        {
            var response = await _userFollowService.GetFollowerCountAsync(userId);
            return CreateReturn(response);
        }

        // Kullanıcının Takip Edilen Sayısını Getirme - User ve Admin erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpGet("following-count/{userId}")]
        public async Task<IActionResult> GetFollowingCount(string userId)
        {
            var response = await _userFollowService.GetFollowingCountAsync(userId);
            return CreateReturn(response);
        }
    }

}
