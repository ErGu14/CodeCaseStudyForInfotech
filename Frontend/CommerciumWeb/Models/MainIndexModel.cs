namespace CommerciumWeb.Models
{
    public class MainIndexModel
    {
        public UserModel User { get; set; } 
        public IEnumerable<UserModel> FollowingUsers { get; set; } 
        public IEnumerable<BusinessProfileModel> BusinessProfiles { get; set; } 
        public IEnumerable<ProductModel> Products { get; set; } 
        public IEnumerable<CategoryModel> Categories { get; set; } 
        public IEnumerable<CampaignModel> Campaigns { get; set; } 
        public IEnumerable<FavoriteModel> Favorites { get; set; } 
        public IEnumerable<NotificationModel> Notifications { get; set; } 
    }
}
