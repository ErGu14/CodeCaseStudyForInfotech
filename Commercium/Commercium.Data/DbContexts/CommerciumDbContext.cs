using Commercium.Entity;
using Commercium.Entity.Businness;
using Commercium.Entity.Search;
using Commercium.Entity.Tags;
using Commercium.Entity.User;
using Commercium.Entity.User.Account;
using Commercium.Shared.Enums;
using Commercium.Shared.Other.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Data.DbContexts
{
    public class CommerciumDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public CommerciumDbContext(DbContextOptions options)
            : base(options)
        { }

        #region DbSets

        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<BusinessProfile> BusinessProfiles { get; set; }
        public DbSet<BusinessProfileCustomization> BusinessProfileCustomizations { get; set; }
        public DbSet<BusinessProfileTag> BusinessProfileTags { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<SearchHistory> SearchHistories { get; set; }
        public DbSet<SearchResult> SearchResults { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceTag> ServiceTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserFollow> UserFollows { get; set; }
        public DbSet<UserProfileCustomization> UserProfileCustomizations { get; set; }

        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Ürün Örnek Verisi
            builder.Entity<Product>().HasData(
     new Product
     {
         ProductId = 101,
         Name = "Ürün A",
         Description = "Yüksek kaliteli elektronik ürün.",
         Price = 500m,
         ClickCount = 150,
         LikeCount = 80,
         BusinessProfileId = 1,
         ViewCount = 200,
         CreatedDate = DateTime.Now.AddDays(-10)
     },
     new Product
     {
         ProductId = 102,
         Name = "Ürün B",
         Description = "Modern teknoloji ile üretilmiş ürün.",
         Price = 750m,
         ClickCount = 200,
         LikeCount = 120,
         BusinessProfileId = 1,
         ViewCount = 250,
         CreatedDate = DateTime.Now.AddDays(-5)
     },
     new Product
     {
         ProductId = 103,
         Name = "Ürün C",
         Description = "Yeni nesil moda ürünü.",
         Price = 600m,
         ClickCount = 110,
         LikeCount = 50,
         BusinessProfileId = 2,
         ViewCount = 100,
         CreatedDate = DateTime.Now.AddDays(-7)
     }
 );




            #endregion

            #region Kategori Örnek Verisi
            builder.Entity<Category>().HasData(
    new Category
    {
        CategoryId = 1,
        Name = "Elektronik"
    },
    new Category
    {
        CategoryId = 2,
        Name = "Moda"
    },
    new Category
    {
        CategoryId = 3,
        Name = "Ev & Yaşam"
    }
);


            #endregion

            #region Ürün Kategori Örnek Verisi
            builder.Entity<ProductCategory>().HasData(
      new ProductCategory { ProductId = 101, CategoryId = 1 },
      new ProductCategory { ProductId = 102, CategoryId = 1 },
      new ProductCategory { ProductId = 103, CategoryId = 2 }
     
  );



            #endregion

            #region Favori ve Ürünler Yapılandırması
            builder.Entity<Favorite>()
    .HasOne(f => f.Product)
    .WithMany()
    .HasForeignKey(f => f.ProductId)
    .OnDelete(DeleteBehavior.NoAction);  // DELETE işlemi için NoAction uygula


            builder.Entity<Favorite>()
     .HasOne(f => f.Service)
     .WithMany()
     .HasForeignKey(f => f.ServiceId)
     .OnDelete(DeleteBehavior.NoAction);  // DELETE işlemi için NoAction uygula


            builder.Entity<ProductCategory>()
    .HasOne(pc => pc.Product)
    .WithMany(p => p.ProductCategories)
    .HasForeignKey(pc => pc.ProductId)
    .OnDelete(DeleteBehavior.Cascade);  // Veya NoAction, SetNull gibi davranışlar belirlenebilir.

            #endregion

            #region Bildirim Yapılandırması
            builder.Entity<Notification>()
    .HasOne(n => n.BusinessProfile)
    .WithMany(bp => bp.Notifications)
    .HasForeignKey(n => n.BusinessProfileId)
    .OnDelete(DeleteBehavior.Restrict); // Kısıtlayıcı davranış: Silmeye engel ol




            #endregion

            #region Conversation Yapılandırması
            // Foreign Key ilişkilerini tanımlarken
            builder.Entity<Conversation>()
                .HasOne(c => c.Sender)
                .WithMany()  // Eğer Sender'a bağlı bir koleksiyon varsa, onu da belirtin
                .HasForeignKey(c => c.SenderId)
                .OnDelete(DeleteBehavior.NoAction);  // DELETE sırasında işlem yapılmasın

             builder.Entity<Conversation>()
                .HasOne(c => c.Receiver)
                .WithMany()  // Eğer Receiver'a bağlı bir koleksiyon varsa, onu da belirtin
                .HasForeignKey(c => c.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);  // DELETE sırasında işlem yapılmasın
            #endregion

            #region ActivityLog Yapılandırması
            builder.Entity<ActivityLog>()
            .HasOne(a => a.Service)
            .WithMany()  // Eğer Service'e bağlı bir koleksiyon varsa, onu da belirtin
            .HasForeignKey(a => a.ServiceId) // Foreign Key burada tanımlanır
            .OnDelete(DeleteBehavior.NoAction);  // Cascade işlemlerini engellemek için


            #endregion

            #region UserFollow Yapılandırması
            builder.Entity<UserFollow>()
        .HasOne(uf => uf.Follower)
        .WithMany()  // Eğer Follower'a bağlı bir koleksiyon varsa, onu da belirtin
        .HasForeignKey(uf => uf.FollowerId)
        .OnDelete(DeleteBehavior.NoAction);  // ON DELETE NO ACTION ile cascade engellenir

            builder.Entity<UserFollow>()
                .HasOne(uf => uf.Followed)
                .WithMany()  // Eğer Followed'a bağlı bir koleksiyon varsa, onu da belirtin
                .HasForeignKey(uf => uf.FollowedId)
                .OnDelete(DeleteBehavior.NoAction);  // ON DELETE NO ACTION ile cascade engellenir
            #endregion

            #region Message Yapılandırması
            builder.Entity<Message>()
        .HasOne(m => m.Sender)  // SenderId ilişkisini kuruyoruz
        .WithMany()  // Sender'a bağlı bir koleksiyon varsa, onu da belirtin
        .HasForeignKey(m => m.SenderId)
        .OnDelete(DeleteBehavior.NoAction);  // ON DELETE NO ACTION ile cascade engellenir

            builder.Entity<Message>()
                .HasOne(m => m.Receiver)  // ReceiverId ilişkisini kuruyoruz
                .WithMany()  // Receiver'a bağlı bir koleksiyon varsa, onu da belirtin
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);  // ON DELETE NO ACTION ile cascade engellenir
            #endregion

            #region ProductCategory (Ürün ve Kategori İlişkisi)


            builder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            builder.Entity<ProductCategory>()
               .HasOne(pc => pc.Product)
              .WithMany(p => p.ProductCategories)
               .HasForeignKey(pc => pc.ProductId);

            builder.Entity<ProductCategory>()
               .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
               .HasForeignKey(pc => pc.CategoryId);

            #endregion

            #region ProductTag (Ürün ve Etiket İlişkisi)

            builder.Entity<ProductTag>()
                .HasKey(pt => new { pt.ProductId, pt.TagId });

            builder.Entity<ProductTag>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductTags)
                .HasForeignKey(pt => pt.ProductId);

            builder.Entity<ProductTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.ProductTags)
                .HasForeignKey(pt => pt.TagId);

            #endregion

            #region ServiceTag (Hizmet ve Etiket İlişkisi)

            builder.Entity<ServiceTag>()
                .HasKey(st => new { st.ServiceId, st.TagId });

            builder.Entity<ServiceTag>()
                .HasOne(st => st.Service)
                .WithMany(s => s.ServiceTags)
                .HasForeignKey(st => st.ServiceId);

            builder.Entity<ServiceTag>()
                .HasOne(st => st.Tag)
                .WithMany(t => t.ServiceTags)
                .HasForeignKey(st => st.TagId);

            #endregion

            #region BusinessProfileTag (İşletme Profili ve Etiket İlişkisi)

            builder.Entity<BusinessProfileTag>()
                .HasKey(bpt => new { bpt.BusinessProfileId, bpt.TagId });  // İki anahtar kullanılıyor

            builder.Entity<BusinessProfileTag>()
                .HasOne(bpt => bpt.BusinessProfile)  // BusinessProfile ile ilişkiyi belirtiyoruz
                .WithMany(bp => bp.BusinessProfileTags)  // BusinessProfile içinde birden fazla BusinessProfileTag olabilir
                .HasForeignKey(bpt => bpt.BusinessProfileId);  // Foreign key olarak BusinessProfileId kullanıyoruz

            builder.Entity<BusinessProfileTag>()
                .HasOne(bpt => bpt.Tag)  // Tag ile ilişkiyi belirtiyoruz
                .WithMany(t => t.BusinessProfileTags)  // Tag içinde birden fazla BusinessProfileTag olabilir
                .HasForeignKey(bpt => bpt.TagId);  // Foreign key olarak TagId kullanıyoruz






            #endregion

            #region UserFollow (Kullanıcı Takibi)

            builder.Entity<UserFollow>()
                .HasKey(uf => new { uf.FollowerId, uf.FollowedId });

            builder.Entity<UserFollow>()
                .HasOne(uf => uf.Follower)
                .WithMany(f => f.Follows)
                .HasForeignKey(uf => uf.FollowerId);

            builder.Entity<UserFollow>()
                .HasOne(uf => uf.Followed)
                .WithMany(f => f.FollowedBy)
                .HasForeignKey(uf => uf.FollowedId);

            #endregion

            #region Decimal Configuration

            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Campaign>()
                .Property(c => c.DiscountPercentage)
                .HasColumnType("decimal(18,2)"); // Kampanya indirim yüzdesi için



            #endregion

            #region Users & Roles Example Datas (kullanıcılar ve roller örnek veriler)
            builder.Entity<AppRole>().HasData(
                        new AppRole
                        {
                            Id = "1e01f984-8836-4e4b-902a-d60fa23b1833",
                            Name = "User",
                            NormalizedName = "USER",
                            Description = "Standart kullanıcılar için bir rol."
                        },
                        new AppRole
                        {
                            Id = "d4b8c6bc-0182-4c29-8c88-8e68bc8a7b2b",
                            Name = "Seller",
                            NormalizedName = "SELLER",
                            Description = "Satıcılar için bir rol."
                        },
                        new AppRole
                        {
                            Id = "fa5c0d5b-8b9b-4377-a2ba-d5765a8ed25c",
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            Description = "Yönetici rolü, tüm yetkilere sahip."
                        },
                        new AppRole
                        {
                            Id = "ab5cd8c9-8f8e-48b2-83c1-b96e5f98413a",
                            Name = "BusinessOwner",
                            NormalizedName = "BUSINESSOWNER",
                            Description = "İşletme sahipleri için bir rol."
                        }
                    );

            builder.Entity<AppUser>().HasData(
                        // User Rolü
                        new AppUser
                        {
                            Id = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b",
                            FirstName = "Ahmet",
                            MiddleName = "",
                            LastName = "Yıldız",
                            Gender = Gender.PreferNotToSay,
                            DateOfBirth = new DateTime(1988, 12, 13),
                            Email = "ahmetyilmaz41@outlook.com",
                            NormalizedEmail = "AHMETYILMAZ41@OUTLOOK.COM",
                            EmailConfirmed = true,
                            PhoneNumber = "5346530901",
                            PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "41NewyorK41.!"),
                        },

                        // Seller Rolü
                        new AppUser
                        {
                            Id = "f8c9debe-935b-432a-b8a2-7c417f7767b1",
                            FirstName = "Mehmet",
                            MiddleName = "",
                            LastName = "Güler",
                            Gender = Gender.Male,
                            DateOfBirth = new DateTime(1992, 5, 24),
                            Email = "mehmetguler@hotmail.com",
                            NormalizedEmail = "MEHMETGULER@HOTMAIL.COM",
                            EmailConfirmed = true,
                            PhoneNumber = "5551234567",
                            PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Mehmet123!@"),
                        },

                        // Admin Rolü
                        new AppUser
                        {
                            Id = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3",
                            FirstName = "Ayşe",
                            MiddleName = "Fidan",
                            LastName = "Yılmaz",
                            Gender = Gender.Female,
                            DateOfBirth = new DateTime(1985, 4, 17),
                            Email = "ayseyilmaz@admin.com",
                            NormalizedEmail = "AYSEYILMAZ@ADMIN.COM",
                            EmailConfirmed = true,
                            PhoneNumber = "5327654321",
                            PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Admin123!@"),
                        },

                        // BusinessOwner Rolü
                        new AppUser
                        {
                            Id = "d04b2879-cff4-4d92-8e3f-97acdc6c0e42",
                            FirstName = "Ali",
                            MiddleName = "",
                            LastName = "Çelik",
                            Gender = Gender.Male,
                            DateOfBirth = new DateTime(1990, 2, 1),
                            Email = "alicelik@business.com",
                            NormalizedEmail = "ALICELIK@BUSINESS.COM",
                            EmailConfirmed = true,
                            PhoneNumber = "5364567890",
                            PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "BusinessOwner1234!@"),
                        }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                // User rolü için ilişki
                new IdentityUserRole<string> { UserId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b", RoleId = "1e01f984-8836-4e4b-902a-d60fa23b1833" },  // User role
            
                // Seller rolü için ilişki
                new IdentityUserRole<string> { UserId = "f8c9debe-935b-432a-b8a2-7c417f7767b1", RoleId = "d4b8c6bc-0182-4c29-8c88-8e68bc8a7b2b" },  // Seller role
            
                // Admin rolü için ilişki
                new IdentityUserRole<string> { UserId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3", RoleId = "fa5c0d5b-8b9b-4377-a2ba-d5765a8ed25c" },  // Admin role
            
                // BusinessOwner rolü için ilişki
                new IdentityUserRole<string> { UserId = "d04b2879-cff4-4d92-8e3f-97acdc6c0e42", RoleId = "ab5cd8c9-8f8e-48b2-83c1-b96e5f98413a" }   // BusinessOwner role
            );


            #endregion

            #region ActivityLog Örnek Verisi
            builder.Entity<ActivityLog>().HasData(
     new ActivityLog
     {
         ActivityLogId = 1,
         ActivityType = ActivityType.View,
         ActivityDate = DateTime.Now,
         Details = "Service viewed",
         EntityId = 1,
         EntityType = EntityType.Service,
         UserId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b",
         EntityName = "Web Design Service",
         ServiceId = 1, // Burada geçerli bir ServiceId kullandığınızdan emin olun
     }
 );

            #endregion

            #region Konuşma Örnek Verisi
            builder.Entity<Conversation>().HasData(
      new Conversation
      {
          ConversationId = 1,
          SenderId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b",
          ReceiverId = "f8c9debe-935b-432a-b8a2-7c417f7767b1",
          LastMessageDate = DateTime.Now.AddDays(-2)
      },
      new Conversation
      {
          ConversationId = 2,
          SenderId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3",
          ReceiverId = "d04b2879-cff4-4d92-8e3f-97acdc6c0e42",
          LastMessageDate = DateTime.Now.AddDays(-1)
      }
  );
            #endregion

            #region Favoriler Örnek Verisi
            builder.Entity<Favorite>().HasData(
     // 1. Favori: Kullanıcı ve Ürün arasında
     new Favorite
     {
         FavoriteId = 1,
         UserId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b",
         ProductId = 101,  // Ürün ile ilişkilendir
         ServiceId = null, // Servis olmadığı için null
     },

     // 2. Favori: Kullanıcı ve Hizmet arasında
     new Favorite
     {
         FavoriteId = 2,
         UserId = "f8c9debe-935b-432a-b8a2-7c417f7767b1",
         ProductId = null,  // Ürün olmadığı için null
         ServiceId = 1,   // Hizmet ile ilişkilendir
     },

     // 3. Favori: Kullanıcı, Ürün ve Hizmet arasında
     new Favorite
     {
         FavoriteId = 3,
         UserId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3",
         ProductId = 102,  // Ürün ile ilişkilendir
         ServiceId = 2,  // Hizmet ile ilişkilendir
     },

     // 4. Favori: İşletme Sahibi ve Hizmet arasında
     new Favorite
     {
         FavoriteId = 4,
         UserId = "d04b2879-cff4-4d92-8e3f-97acdc6c0e42",
         ProductId = null,  // Ürün olmadığı için null
         ServiceId = 2,   // Hizmet ile ilişkilendir
     },

     // 5. Favori: Kullanıcı ve Ürün arasında
     new Favorite
     {
         FavoriteId = 5,
         UserId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b",
         ProductId = 103,  // Ürün ile ilişkilendir
         ServiceId = null, // Servis olmadığı için null
     }
 );


            #endregion

            #region Mesaj Örnek Verisi
            builder.Entity<Message>().HasData(
     new Message
     {
         MessageId = 1,
         SenderId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b",
         ReceiverId = "f8c9debe-935b-432a-b8a2-7c417f7767b1",
         Content = "Merhaba, nasıl yardımcı olabilirim?",
         SentDate = DateTime.Now.AddDays(-2),
         IsRead = false,
         ConversationId = 1  // Message'a uygun ConversationId'yi ekliyoruz
     },
     new Message
     {
         MessageId = 2,
         SenderId = "f8c9debe-935b-432a-b8a2-7c417f7767b1",
         ReceiverId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b",
         Content = "Merhaba! Ürün hakkında bilgi almak istiyorum.",
         SentDate = DateTime.Now.AddDays(-2),
         IsRead = true,
         ConversationId = 1  // Message'a uygun ConversationId'yi ekliyoruz
     }
 );
            #endregion

            #region Bildirim Örnek Verisi
            builder.Entity<Notification>().HasData(
    // 1. Bildirim: Ürün beğenildi
    new Notification
    {
        NotificationId = 1,
        UserId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b",
        NotificationType = NotificationType.ProductLike,
        Message = "Ürünün beğenildi.",
        DateCreated = DateTime.Now.AddDays(-2),
        IsRead = false,
        ProductId = 101,  // Ürün ile ilişkilendir
        ServiceId = null, // Servis olmadığı için null
        BusinessProfileId = null, // İşletme Profili olmadığı için null
    },

    // 2. Bildirim: Ürüne yorum yapıldı
    new Notification
    {
        NotificationId = 2,
        UserId = "f8c9debe-935b-432a-b8a2-7c417f7767b1",
        NotificationType = NotificationType.ProductComment,
        Message = "Ürüne yorum yapıldı.",
        DateCreated = DateTime.Now.AddDays(-1),
        IsRead = true,
        ProductId = 102,  // Ürün ile ilişkilendir
        ServiceId = null, // Servis olmadığı için null
        BusinessProfileId = null, // İşletme Profili olmadığı için null
    },

    // 3. Bildirim: Kampanya güncellendi
    new Notification
    {
        NotificationId = 3,
        UserId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3",
        NotificationType = NotificationType.CampaignUpdate,
        Message = "Kampanya güncellendi.",
        DateCreated = DateTime.Now.AddDays(-3),
        IsRead = false,
        ProductId = null, // Ürün olmadığı için null
        ServiceId = null, // Servis olmadığı için null
        BusinessProfileId = 1,  // İşletme Profili ile ilişkilendir
    },

    // 4. Bildirim: Yeni mesajınız var
    new Notification
    {
        NotificationId = 4,
        UserId = "d04b2879-cff4-4d92-8e3f-97acdc6c0e42",
        NotificationType = NotificationType.MessageReceived,
        Message = "Yeni mesajınız var.",
        DateCreated = DateTime.Now.AddDays(-1),
        IsRead = true,
        ProductId = null, // Ürün olmadığı için null
        ServiceId = null, // Servis olmadığı için null
        BusinessProfileId = null, // İşletme Profili olmadığı için null
    },

    // 5. Bildirim: Profil güncellendi
    new Notification
    {
        NotificationId = 5,
        UserId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b",
        NotificationType = NotificationType.ProfileUpdate,
        Message = "Profiliniz güncellendi.",
        DateCreated = DateTime.Now.AddDays(-5),
        IsRead = false,
        ProductId = null, // Ürün olmadığı için null
        ServiceId = null, // Servis olmadığı için null
        BusinessProfileId = null, // İşletme Profili olmadığı için null
    }
);

            #endregion

            #region Yorum Örnek Verisi
            builder.Entity<Review>().HasData(
    new Review
    {
        ReviewId = 1,
        ProductId = 101,
        Rating = 5,
        Comment = "Harika ürün, çok memnun kaldım!",
        DateCreated = DateTime.Now.AddDays(-8),
        UserId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b"  // Ahmet'in UserId'si
    },
    new Review
    {
        ReviewId = 2,
        ProductId = 101,
        Rating = 4,
        Comment = "Fiyat/performans açısından iyi bir ürün.",
        DateCreated = DateTime.Now.AddDays(-5),
        UserId = "f8c9debe-935b-432a-b8a2-7c417f7767b1"  // Mehmet'in UserId'si
    },
    new Review
    {
        ReviewId = 3,
        ProductId = 102,
        Rating = 4,
        Comment = "Ürün kaliteli ama biraz pahalı.",
        DateCreated = DateTime.Now.AddDays(-3),
        UserId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3"  // Ayşe'nin UserId'si
    }
);

            #endregion

            #region Kullanıcı Takip Örnek Verisi
            builder.Entity<UserFollow>().HasData(
                // 1. Takip: Ahmet Yıldız, Mehmet Güler'i takip ediyor
                new UserFollow
                {
                    FollowerId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b",  // Takip Eden (Ahmet)
                    FollowedId = "f8c9debe-935b-432a-b8a2-7c417f7767b1"   // Takip Edilen (Mehmet)
                },
                // 2. Takip: Mehmet Güler, Ayşe Yılmaz'ı takip ediyor
                new UserFollow
                {
                    FollowerId = "f8c9debe-935b-432a-b8a2-7c417f7767b1",  // Takip Eden (Mehmet)
                    FollowedId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3"   // Takip Edilen (Ayşe)
                },
                // 3. Takip: Ayşe Yılmaz, Ali Çelik'i takip ediyor
                new UserFollow
                {
                    FollowerId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3",  // Takip Eden (Ayşe)
                    FollowedId = "d04b2879-cff4-4d92-8e3f-97acdc6c0e42"   // Takip Edilen (Ali)
                },
                // 4. Takip: Ali Çelik, Ahmet Yıldız'ı takip ediyor
                new UserFollow
                {
                    FollowerId = "d04b2879-cff4-4d92-8e3f-97acdc6c0e42",  // Takip Eden (Ali)
                    FollowedId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b"   // Takip Edilen (Ahmet)
                }
            );
            #endregion

            #region Kullanıcı Profil Özelleştirme Örnek Verisi
            builder.Entity<UserProfileCustomization>().HasData(
                // 1. Kullanıcı Profil Özelleştirmesi: Ahmet
                new UserProfileCustomization
                {
                    UserProfileCustomizationId = 1,
                    CustomProfileImage = "https://example.com/profile1.jpg",
                    CustomBackgroundImage = "https://example.com/background1.jpg",
                    CustomDescription = "Ahmet'in özel profil açıklaması.",
                    UserId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b"  // Ahmet'in UserId'si
                },

                // 2. Kullanıcı Profil Özelleştirmesi: Mehmet
                new UserProfileCustomization
                {
                    UserProfileCustomizationId = 2,
                    CustomProfileImage = "https://example.com/profile2.jpg",
                    CustomBackgroundImage = "https://example.com/background2.jpg",
                    CustomDescription = "Mehmet'in özelleştirilmiş profili.",
                    UserId = "f8c9debe-935b-432a-b8a2-7c417f7767b1"  // Mehmet'in UserId'si
                },

                // 3. Kullanıcı Profil Özelleştirmesi: Ayşe
                new UserProfileCustomization
                {
                    UserProfileCustomizationId = 3,
                    CustomProfileImage = "https://example.com/profile3.jpg",
                    CustomBackgroundImage = "https://example.com/background3.jpg",
                    CustomDescription = "Ayşe'nin özel açıklaması.",
                    UserId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3"  // Ayşe'nin UserId'si
                },

                // 4. Kullanıcı Profil Özelleştirmesi: Ali
                new UserProfileCustomization
                {
                    UserProfileCustomizationId = 4,
                    CustomProfileImage = "https://example.com/profile4.jpg",
                    CustomBackgroundImage = "https://example.com/background4.jpg",
                    CustomDescription = "Ali'nin özel açıklaması.",
                    UserId = "d04b2879-cff4-4d92-8e3f-97acdc6c0e42"  // Ali'nin UserId'si
                }
            );
            #endregion

            #region İşletme Profili Örnek Verisi
            builder.Entity<BusinessProfile>().HasData(
    new BusinessProfile
    {
        BusinessProfileId = 1,
        BusinessName = "Ahmet'in Teknoloji Mağazası",
        BusinessDescription = "Yüksek kaliteli elektronik ürünler.",
        ContactInfo = "info@ahmetteknoloji.com",
        Location = "İstanbul, Kadıköy",
        ClickCount = 150,
        LikeCount = 50,
        OwnerId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b"
    },
    new BusinessProfile
    {
        BusinessProfileId = 2,
        BusinessName = "Mehmet'in Moda Mağazası",
        BusinessDescription = "Son trendlere uygun giyim ve aksesuarlar.",
        ContactInfo = "info@mehmetmoda.com",
        Location = "Ankara, Çankaya",
        ClickCount = 100,
        LikeCount = 30,
        OwnerId = "f8c9debe-935b-432a-b8a2-7c417f7767b1"
    }
);


            #endregion

            #region İşletme Profili Etiketi Örnek Verisi
            builder.Entity<BusinessProfileTag>().HasData(
                // 1. Etiket: Ahmet'in Teknoloji Mağazası, Elektronik Etiketi
                new BusinessProfileTag
                {
                    BusinessProfileId = 1,  // Ahmet'in Teknoloji Mağazası
                    TagId = 1  // Elektronik etiketi
                },

                // 2. Etiket: Ahmet'in Teknoloji Mağazası, Teknoloji Etiketi
                new BusinessProfileTag
                {
                    BusinessProfileId = 1,  // Ahmet'in Teknoloji Mağazası
                    TagId = 2  // Teknoloji etiketi
                },

                // 3. Etiket: Mehmet'in Moda Mağazası, Moda Etiketi
                new BusinessProfileTag
                {
                    BusinessProfileId = 2,  // Mehmet'in Moda Mağazası
                    TagId = 3  // Moda etiketi
                },

                // 4. Etiket: Mehmet'in Moda Mağazası, Aksesuar Etiketi
                new BusinessProfileTag
                {
                    BusinessProfileId = 2,  // Mehmet'in Moda Mağazası
                    TagId = 4  // Aksesuar etiketi
                }
            );
            #endregion

            #region İşletme Profili Özelleştirme Örnek Verisi
            builder.Entity<BusinessProfileCustomization>().HasData(
                // 1. İşletme Profili Özelleştirmesi: Ahmet'in Teknoloji Mağazası
                new BusinessProfileCustomization
                {
                    BusinessProfileCustomizationId = 1,
                    CustomProfileImage = "https://example.com/businessprofile1.jpg",
                    CustomBackgroundImage = "https://example.com/businessbackground1.jpg",
                    CustomDescription = "Ahmet'in teknoloji mağazası için özel açıklama.",
                    BusinessProfileId = 1  // Ahmet'in Teknoloji Mağazası ile ilişkilendir
                },

                // 2. İşletme Profili Özelleştirmesi: Mehmet'in Moda Mağazası
                new BusinessProfileCustomization
                {
                    BusinessProfileCustomizationId = 2,
                    CustomProfileImage = "https://example.com/businessprofile2.jpg",
                    CustomBackgroundImage = "https://example.com/businessbackground2.jpg",
                    CustomDescription = "Mehmet'in moda mağazası için özelleştirilmiş profil.",
                    BusinessProfileId = 2  // Mehmet'in Moda Mağazası ile ilişkilendir
                }
            );
            #endregion

            #region Kampanya Örnek Verisi
            builder.Entity<Campaign>().HasData(
                // 1. Kampanya: Yaz İndirimi
                new Campaign
                {
                    CampaignId = 1,
                    Title = "Yaz İndirimi",
                    Description = "Yaz aylarına özel %20 indirim fırsatı!",
                    StartDate = DateTime.Now.AddDays(-5),
                    EndDate = DateTime.Now.AddDays(10),
                    DiscountPercentage = 20m,
                    ClickCount = 150,
                    LikeCount = 50,
                    ViewCount = 200,
                    BusinessProfileId = 1  // Ahmet'in Teknoloji Mağazası ile ilişkilendir
                },

                // 2. Kampanya: Kış İndirimi
                new Campaign
                {
                    CampaignId = 2,
                    Title = "Kış İndirimi",
                    Description = "Kış sezonu için %15 indirim fırsatları!",
                    StartDate = DateTime.Now.AddDays(-2),
                    EndDate = DateTime.Now.AddDays(15),
                    DiscountPercentage = 15m,
                    ClickCount = 100,
                    LikeCount = 30,
                    ViewCount = 180,
                    BusinessProfileId = 2  // Mehmet'in Moda Mağazası ile ilişkilendir
                }
            );


            #endregion

            #region Hizmet Örnek Verisi
            builder.Entity<Service>().HasData(
      new Service
      {
          ServiceId = 1,
          ServiceName = "Web Tasarım Hizmeti",
          Description = "Profesyonel web tasarım hizmetleri sunuyoruz.",
          Price = 500m,
          ClickCount = 150,
          LikeCount = 80,
          BusinessProfileId = 1  // Ahmet'in Teknoloji Mağazası ile ilişkilendir
      },
      new Service
      {
          ServiceId = 2,
          ServiceName = "SEO Hizmeti",
          Description = "Web sitenizin SEO analizini yapıyoruz ve iyileştiriyoruz.",
          Price = 300m,
          ClickCount = 200,
          LikeCount = 120,
          BusinessProfileId = 2  // Mehmet'in Moda Mağazası ile ilişkilendir
      }
  );


            #endregion
           

            #region Arama Geçmişi Örnek Verisi
            builder.Entity<SearchHistory>().HasData(
                // 1. Arama Geçmişi: Elektronik ürünler
                new SearchHistory
                {
                    SearchHistoryId = 1,
                    UserId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b",  // Ahmet'in UserId'si
                    SearchQuery = "Elektronik ürünler",
                    SearchDate = DateTime.Now.AddDays(-2)
                },

                // 2. Arama Geçmişi: Moda ürünleri
                new SearchHistory
                {
                    SearchHistoryId = 2,
                    UserId = "f8c9debe-935b-432a-b8a2-7c417f7767b1",  // Mehmet'in UserId'si
                    SearchQuery = "Moda ürünleri",
                    SearchDate = DateTime.Now.AddDays(-1)
                },

                // 3. Arama Geçmişi: SEO hizmeti
                new SearchHistory
                {
                    SearchHistoryId = 3,
                    UserId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3",  // Ayşe'nin UserId'si
                    SearchQuery = "SEO hizmeti",
                    SearchDate = DateTime.Now.AddDays(-3)
                },

                // 4. Arama Geçmişi: Ev & Yaşam ürünleri
                new SearchHistory
                {
                    SearchHistoryId = 4,
                    UserId = "d04b2879-cff4-4d92-8e3f-97acdc6c0e42",  // Ali'nin UserId'si
                    SearchQuery = "Ev & Yaşam ürünleri",
                    SearchDate = DateTime.Now.AddDays(-1)
                }
            );
            #endregion

            #region Arama Sonucu Örnek Verisi
            builder.Entity<SearchResult>().HasData(
                // 1. Arama Sonucu: Elektronik ürünler
                new SearchResult
                {
                    SearchResultId = 1,
                    SearchQuery = "Elektronik ürünler",
                    ProductId = 101,  // Ürün A ile ilişkilendir
                    ServiceId = null,  // Hizmet olmadığı için null
                    BusinessProfileId = 1,  // Ahmet'in Teknoloji Mağazası ile ilişkilendir
                    SearchDate = DateTime.Now.AddDays(-2)
                },

                // 2. Arama Sonucu: Moda ürünleri
                new SearchResult
                {
                    SearchResultId = 2,
                    SearchQuery = "Moda ürünleri",
                    ProductId = 102,  // Ürün B ile ilişkilendir
                    ServiceId = null,  // Hizmet olmadığı için null
                    BusinessProfileId = 2,  // Mehmet'in Moda Mağazası ile ilişkilendir
                    SearchDate = DateTime.Now.AddDays(-1)
                },

                // 3. Arama Sonucu: SEO hizmeti
                new SearchResult
                {
                    SearchResultId = 3,
                    SearchQuery = "SEO hizmeti",
                    ProductId = null,  // Ürün olmadığı için null
                    ServiceId = 2,  // SEO hizmeti ile ilişkilendir
                    BusinessProfileId = 1,  // Ahmet'in Teknoloji Mağazası ile ilişkilendir
                    SearchDate = DateTime.Now.AddDays(-3)
                }

               
            );
            #endregion

            #region Ürün Etiket Örnek Verisi
            builder.Entity<ProductTag>().HasData(
    new ProductTag { ProductId = 101, TagId = 1 },  // Elektronik etiketini ilişkilendiriyoruz
    new ProductTag { ProductId = 102, TagId = 1 },  // Elektronik etiketini ilişkilendiriyoruz
    new ProductTag { ProductId = 103, TagId = 2 }  // Moda etiketini ilişkilendiriyoruz
    
);

            #endregion

            #region Hizmet Etiket Örnek Verisi
            builder.Entity<ServiceTag>().HasData(
                // 1. Hizmet: Elektronik etiketini ilişkilendiriyoruz
                new ServiceTag { ServiceId = 1, TagId = 1 },  // SEO Hizmeti -> Elektronik etiketi

                // 2. Hizmet: SEO etiketini ilişkilendiriyoruz
                new ServiceTag { ServiceId = 2, TagId = 2 }  // SEO Hizmeti -> SEO etiketi

               
            );
            #endregion

            #region Etiket Örnek Verisi
            builder.Entity<Tag>().HasData(
                // 1. Etiket: Elektronik
                new Tag
                {
                    TagId = 1,
                    Name = "Elektronik"
                },

                // 2. Etiket: Moda
                new Tag
                {
                    TagId = 2,
                    Name = "Moda"
                },

                // 3. Etiket: Web Tasarım
                new Tag
                {
                    TagId = 3,
                    Name = "Web Tasarım"
                },

                // 4. Etiket: SEO
                new Tag
                {
                    TagId = 4,
                    Name = "SEO"
                },

                // 5. Etiket: Yeni Ürün
                new Tag
                {
                    TagId = 5,
                    Name = "Yeni Ürün"
                },

                // 6. Etiket: Teknoloji
                new Tag
                {
                    TagId = 6,
                    Name = "Teknoloji"
                }
            );
            #endregion



            base.OnModelCreating(builder);
        }
        #endregion

    }
}