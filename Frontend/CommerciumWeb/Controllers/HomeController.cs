using CommerciumWeb.Models;
using CommerciumWeb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CommerciumWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICampaignService _campaignService;
        private readonly IBusinessService _businessService;
        private readonly IFavoriteService _favoriteService;
        private readonly INotificationService _notificationService;
        private readonly IUserFollowService _userFollowService;
        private readonly IAccountService _userService;

        public HomeController(IProductService productService,
                              ICampaignService campaignService,
                              IBusinessService businessService,
                              IFavoriteService favoriteService,
                              INotificationService notificationService,
                              IUserFollowService userFollowService,
                              IAccountService userService)
        {
            _productService = productService;
            _campaignService = campaignService;
            _businessService = businessService;
            _favoriteService = favoriteService;
            _notificationService = notificationService;
            _userFollowService = userFollowService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var userId = User.Identity.Name;

                var user = await _userService.GetUserAsync(userId);
                if (user == null)
                {
                    return RedirectToAction("Login", "Auth");
                }

                var followingUsers = await _userFollowService.GetFollowingAsync(userId);

                var businessProfiles = await _businessService.GetAllBusinessesAsync();

                var products = await _productService.GetAllProductsAsync();

                var campaigns = await _campaignService.GetAllCampaignsAsync();

                var favorites = await _favoriteService.GetUserFavoritesAsync(userId);

                var notifications = await _notificationService.GetUserNotificationsAsync(userId);

                var model = new MainIndexModel
                {
                    User = user.Data,
                    FollowingUsers = followingUsers.Data,
                    BusinessProfiles = businessProfiles.Data,
                    Products = products.Data,
                    Campaigns = campaigns.Data,
                    Favorites = favorites.Data,
                    Notifications = notifications.Data
                };

                return View(model);
            }
            catch (Exception ex)
            {
                
                return View("Error", new { errorMessage = ex.Message });
            }
        }
    }
}
