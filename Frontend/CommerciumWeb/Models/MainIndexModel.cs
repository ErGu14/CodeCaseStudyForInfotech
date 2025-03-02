namespace CommerciumWeb.Models
{
    public class MainIndexModel
    {
        public UserModel User { get; set; } // Kullanıcının kendi profili
        public IEnumerable<UserModel> FollowingUsers { get; set; } // Kullanıcının takip ettiği kişiler
        public IEnumerable<BusinessProfileModel> BusinessProfiles { get; set; } // Kullanıcının takip ettiği işletmeler
        public IEnumerable<ProductModel> Products { get; set; } // Kullanıcının ilgilenebileceği veya takip ettiği işletmelere ait ürünler
        public IEnumerable<CampaignModel> Campaigns { get; set; } // Kullanıcının ilgilenebileceği kampanyalar
        public IEnumerable<FavoriteModel> Favorites { get; set; } // Kullanıcının favorilerine eklediği ürünler/hizmetler
        public IEnumerable<NotificationModel> Notifications { get; set; } // Kullanıcının son bildirimleri
    }
}
