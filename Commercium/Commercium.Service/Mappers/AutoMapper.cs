using AutoMapper;

using Commercium.Entity.Businness;

using Commercium.Entity.Search;
using Commercium.Entity.Tags;

using Commercium.Shared.Users.AccountRMs;
using Commercium.Shared.Users.ActivityLogRMs;
using Commercium.Shared.Businness.BusinessProfileRMs;
using Commercium.Shared.Businness.BusinessProfileCustomizationRMs;
using Commercium.Shared.Businness.BusinessProfileTagRMs;
using Commercium.Shared.Businness.ServiceRMs;

using Commercium.Shared.ProductRMs;

using Commercium.Shared.Users.UserFollowRMs;
using Commercium.Shared.Users.UserProfileCustomizationRMs;
using Commercium.Entity.User.Account;
using Commercium.Entity.User;
using Commercium.Entity;
using Commercium.Shared.ProductCategoryRMs;
using Commercium.Shared.Search.SearchRMs;
using Commercium.Shared.Tags.ProductTagRMs;
using Commercium.Shared.Tags.ServiceTagRMs;
using Commercium.Shared.Tags.TagRMs;
using Commercium.Shared.Users.MessageRMs;
using Commercium.Shared.Users.NotificationRMs;
using Commercium.Shared.Users.ReviewRMs;
using Commercium.Shared.Businness.CampaignRMs;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        // Kullanıcı İşlemleri
        CreateMap<AppUser, AppUserRM>().ReverseMap();

        // Aktivite Logları
        CreateMap<ActivityLog, ActivityLogRM>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ReverseMap();
        CreateMap<ActivityLog, CreateActivityLogRM>().ReverseMap();

        // İşletme Profili
        CreateMap<BusinessProfile, BusinessProfileRM>()
            .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Owner))
            .ReverseMap();
        CreateMap<BusinessProfileCustomization, BusinessProfileCustomizationRM>().ReverseMap();
        CreateMap<BusinessProfileTag, BusinessProfileTagRM>()
            .ForMember(dest => dest.BusinessProfile, opt => opt.MapFrom(src => src.BusinessProfile))
            .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Tag))
            .ReverseMap();

        // Hizmetler
        CreateMap<Service, ServiceRM>()
            .ForMember(dest => dest.BusinessProfile, opt => opt.MapFrom(src => src.BusinessProfile))
            .ReverseMap();

        // Mesajlaşma
        CreateMap<Conversation, ConversationRM>()
            .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Sender))
            .ForMember(dest => dest.Receiver, opt => opt.MapFrom(src => src.Receiver))
            .ReverseMap();
        CreateMap<Message, MessageRM>()
            .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Sender))
            .ForMember(dest => dest.Receiver, opt => opt.MapFrom(src => src.Receiver))
            .ReverseMap();
        CreateMap<Message, CreateMessageRM>().ReverseMap();
        CreateMap<Message, UpdateMessageRM>().ReverseMap();

        // Bildirimler
        CreateMap<Notification, NotificationRM>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
            .ForMember(dest => dest.Service, opt => opt.MapFrom(src => src.Service))
            .ForMember(dest => dest.BusinessProfile, opt => opt.MapFrom(src => src.BusinessProfile))
            .ReverseMap();
        CreateMap<Notification, CreateNotificationRM>().ReverseMap();

        // Ürünler
        CreateMap<Product, ProductRM>()
            .ForMember(dest => dest.BusinessProfile, opt => opt.MapFrom(src => src.BusinessProfile))
            .ReverseMap();
        CreateMap<ProductCategory, ProductCategoryRM>().ReverseMap();
        CreateMap<ProductTag, ProductTagRM>()
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
            .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Tag))
            .ReverseMap();

        // Yorumlar
        CreateMap<Review, ReviewRM>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
            .ForMember(dest => dest.Service, opt => opt.MapFrom(src => src.Service))
            .ReverseMap();
        CreateMap<Review, CreateReviewRM>().ReverseMap();
        CreateMap<Review, UpdateReviewRM>().ReverseMap();

        // Arama & Geçmiş
        CreateMap<SearchHistory, SearchHistoryRM>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ReverseMap();
        CreateMap<SearchResult, SearchResultRM>()
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
            .ForMember(dest => dest.Service, opt => opt.MapFrom(src => src.Service))
            .ForMember(dest => dest.BusinessProfile, opt => opt.MapFrom(src => src.BusinessProfile))
            .ReverseMap();

        // Etiketler
        CreateMap<Tag, TagRM>().ReverseMap();
        CreateMap<Tag, TagRM>()
    .ForMember(dest => dest.TagId, opt => opt.MapFrom(src => src.TagId))
    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
    .ReverseMap();

        CreateMap<ServiceTag, ServiceTagRM>()
            .ForMember(dest => dest.Service, opt => opt.MapFrom(src => src.Service))
            .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Tag))
            .ReverseMap();
        CreateMap<BusinessProfileTagRM, BusinessProfileTag>().ReverseMap();
        CreateMap<BusinessProfileTag, BusinessProfileTagRM>()
    .ForMember(dest => dest.TagId, opt => opt.MapFrom(src => src.Tag.TagId))  // TagId'yi Tag'den alıyoruz
    .ForMember(dest => dest.Tag.Name, opt => opt.MapFrom(src => src.Tag.Name))  // TagName'i Tag'den alıyoruz
    .ReverseMap();
       

        CreateMap<ProductTag, ProductTagRM>().ReverseMap();

        // Kullanıcı Takip
        CreateMap<UserFollow, UserFollowRM>()
            .ForMember(dest => dest.Follower, opt => opt.MapFrom(src => src.Follower))
            .ForMember(dest => dest.Followed, opt => opt.MapFrom(src => src.Followed))
            .ReverseMap();
        CreateMap<UserFollow, CreateUserFollowRM>().ReverseMap();

        // Kullanıcı Profil Özelleştirme
        CreateMap<UserProfileCustomization, UserProfileCustomizationRM>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ReverseMap();
        CreateMap<UserProfileCustomization, CreateUserProfileCustomizationRM>().ReverseMap();
        CreateMap<UserProfileCustomization, UpdateUserProfileCustomizationRM>().ReverseMap();

        // Kampanya
        CreateMap<Campaign, CampaignRM>()
        .ForMember(dest => dest.BusinessProfile, opt => opt.MapFrom(src => src.BusinessProfile))
        .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
        .ForMember(dest => dest.ClickCount, opt => opt.MapFrom(src => src.ClickCount))
        .ForMember(dest => dest.LikeCount, opt => opt.MapFrom(src => src.LikeCount))
        .ForMember(dest => dest.ViewCount, opt => opt.MapFrom(src => src.ViewCount))
        .ReverseMap();

        CreateMap<Campaign, CreateCampaignRM>()
            .ForMember(dest => dest.ProductIds, opt => opt.MapFrom(src => src.Products.Select(p => p.ProductId)))
            .ReverseMap();

        CreateMap<Campaign, UpdateCampaignRM>()
            .ForMember(dest => dest.ProductIds, opt => opt.MapFrom(src => src.Products.Select(p => p.ProductId)))
            .ReverseMap();
    }
}
