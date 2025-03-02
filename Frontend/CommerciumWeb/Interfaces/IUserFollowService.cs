using CommerciumWeb.Models;

namespace CommerciumWeb.Interfaces
{
    public interface IUserFollowService
    {
        Task<ReturnModel<string>> FollowUserAsync(UserFollowModel followModel);
        Task<ReturnModel<string>> UnfollowUserAsync(string followerId, string followedId);
        Task<ReturnModel<IEnumerable<UserModel>>> GetFollowersAsync(string userId);
        Task<ReturnModel<IEnumerable<UserModel>>> GetFollowingAsync(string userId);
        Task<ReturnModel<bool>> IsUserFollowingAsync(string followerId, string followedId);
        Task<ReturnModel<int>> GetFollowerCountAsync(string userId);
        Task<ReturnModel<int>> GetFollowingCountAsync(string userId);
    }
}
