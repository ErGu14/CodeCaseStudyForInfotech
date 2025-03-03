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
        public CommerciumDbContext(DbContextOptions<CommerciumDbContext> options)
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
           ProductId = 1,
           Name = "Gaming Laptop",
           imgUrl = "/images/product.jpg",
           Description = "Yüksek performanslı oyuncu laptopu.",
           Price = 25000.00m,
           ClickCount = 0,
           LikeCount = 0,
           ViewCount = 0,
           CreatedDate = DateTime.UtcNow,
           BusinessProfileId = 1 
       },
       new Product
       {
           ProductId = 2,
           Name = "Kablosuz Kulaklık",
           imgUrl = "/images/product.jpg",
           Description = "Bluetooth bağlantılı yüksek ses kalitesi sunan kulaklık.",
           Price = 1500.00m,
           ClickCount = 0,
           LikeCount = 0,
           ViewCount = 0,
           CreatedDate = DateTime.UtcNow,
           BusinessProfileId = 1
       },

      
       new Product
       {
           ProductId = 3,
           Name = "Tablet Pro 2025",
           imgUrl = "/images/product.jpg",
           Description = "Yüksek çözünürlüklü ekran ve uzun pil ömrü ile profesyonel tablet.",
           Price = 12000.00m,
           ClickCount = 0,
           LikeCount = 0,
           ViewCount = 0,
           CreatedDate = DateTime.UtcNow,
           BusinessProfileId = 1
       },
       new Product
       {
           ProductId = 4,
           Name = "Mekanik Klavye",
           imgUrl = "/images/product.jpg",
           Description = "RGB ışıklı, mekanik anahtarlı gaming klavye.",
           Price = 2500.00m,
           ClickCount = 0,
           LikeCount = 0,
           ViewCount = 0,
           CreatedDate = DateTime.UtcNow,
           BusinessProfileId = 1
       },

       
       new Product
       {
           ProductId = 5,
           Name = "Akıllı Telefon X",
           imgUrl = "/images/product.jpg",
           Description = "Üst düzey performans sunan en yeni akıllı telefon modeli.",
           Price = 18000.00m,
           ClickCount = 0,
           LikeCount = 0,
           ViewCount = 0,
           CreatedDate = DateTime.UtcNow,
           BusinessProfileId = 1
       },
       new Product
       {
           ProductId = 6,
           Name = "Telefon Kılıfı",
           imgUrl = "/images/product.jpg",
           Description = "Dayanıklı silikon kılıf, farklı renk seçenekleriyle.",
           Price = 250.00m,
           ClickCount = 0,
           LikeCount = 0,
           ViewCount = 0,
           CreatedDate = DateTime.UtcNow,
           BusinessProfileId = 1
       },

       
       new Product
       {
           ProductId = 7,
           Name = "Hyaluronik Asit Serum",
           imgUrl = "/images/product.jpg",
           Description = "Yoğun nemlendirme sağlayan hyaluronik asit içeren serum.",
           Price = 500.00m,
           ClickCount = 0,
           LikeCount = 0,
           ViewCount = 0,
           CreatedDate = DateTime.UtcNow,
           BusinessProfileId = 2 // BeautyGlow mağazası
       },
       new Product
       {
           ProductId = 8,
           Name = "Güneş Koruyucu Krem SPF 50",
           imgUrl = "/images/product.jpg",
           Description = "Yüksek koruma sağlayan güneş kremi.",
           Price = 450.00m,
           ClickCount = 0,
           LikeCount = 0,
           ViewCount = 0,
           CreatedDate = DateTime.UtcNow,
           BusinessProfileId = 2
       },

      
       new Product
       {
           ProductId = 9,
           Name = "Mat Likit Ruj",
           imgUrl = "/images/product.jpg",
           Description = "Uzun süre kalıcı, mat bitişli likit ruj.",
           Price = 300.00m,
           ClickCount = 0,
           LikeCount = 0,
           ViewCount = 0,
           CreatedDate = DateTime.UtcNow,
           BusinessProfileId = 2
       },
       new Product
       {
           ProductId = 10,
           Name = "Fondöten",
           imgUrl = "/images/product.jpg",
           Description = "Doğal bitişli, cilt tonunu eşitleyen fondöten.",
           Price = 600.00m,
           ClickCount = 0,
           LikeCount = 0,
           ViewCount = 0,
           CreatedDate = DateTime.UtcNow,
           BusinessProfileId = 2
       }
   );





            #endregion

            #region Kategori Örnek Verisi
            builder.Entity<Category>().HasData(
     new Category
     {
         CategoryId = 1,
         Name = "Teknoloji"
     },
     new Category
     {
         CategoryId = 2,
         Name = "Bilgisayar & Tablet"
     },
     new Category
     {
         CategoryId = 3,
         Name = "Telefon & Aksesuar"
     },
     new Category
     {
         CategoryId = 4,
         Name = "Cilt Bakımı"
     },
     new Category
     {
         CategoryId = 5,
         Name = "Makyaj"
     }
 );



            #endregion

            #region Ürün Kategori Örnek Verisi
            builder.Entity<ProductCategory>().HasData(
    new ProductCategory { ProductId = 1, CategoryId = 1 },
    new ProductCategory { ProductId = 2, CategoryId = 1 },

    new ProductCategory { ProductId = 3, CategoryId = 2 },
    new ProductCategory { ProductId = 4, CategoryId = 2 },

    new ProductCategory { ProductId = 5, CategoryId = 3 },
    new ProductCategory { ProductId = 6, CategoryId = 3 },

    new ProductCategory { ProductId = 7, CategoryId = 4 },
    new ProductCategory { ProductId = 8, CategoryId = 4 },

    new ProductCategory { ProductId = 9, CategoryId = 5 },
    new ProductCategory { ProductId = 10, CategoryId = 5 }
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
          ActivityType = ActivityType.Click,
          ActivityDate = DateTime.UtcNow.AddDays(-5),
          Details = "Gaming Laptop ürününe tıklandı.",
          EntityId = 1,
          EntityType = EntityType.Product,
          UserId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b",
          EntityName = "Gaming Laptop",
          ProductId = 1
      },
      new ActivityLog
      {
          ActivityLogId = 2,
          ActivityType = ActivityType.Like,
          ActivityDate = DateTime.UtcNow.AddDays(-3),
          Details = "Telefon Kılıfı ürünü beğenildi.",
          EntityId = 6,
          EntityType = EntityType.Product,
          UserId = "f8c9debe-935b-432a-b8a2-7c417f7767b1",
          EntityName = "Telefon Kılıfı",
          ProductId = 6
      },
      new ActivityLog
      {
          ActivityLogId = 3,
          ActivityType = ActivityType.View,
          ActivityDate = DateTime.UtcNow.AddDays(-2),
          Details = "Hyaluronik Asit Serum görüntülendi.",
          EntityId = 7,
          EntityType = EntityType.Product,
          UserId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3",
          EntityName = "Hyaluronik Asit Serum",
          ProductId = 7
      },
      new ActivityLog
      {
          ActivityLogId = 4,
          ActivityType = ActivityType.Register,
          ActivityDate = DateTime.UtcNow.AddDays(-10),
          Details = "Yeni kullanıcı kaydoldu.",
          EntityId = 1,
          EntityType = EntityType.User,
          UserId = "d04b2879-cff4-4d92-8e3f-97acdc6c0e42",
          EntityName = "Ali Çelik"
      },
      new ActivityLog
      {
          ActivityLogId = 5,
          ActivityType = ActivityType.Login,
          ActivityDate = DateTime.UtcNow.AddDays(-1),
          Details = "Ahmet Yıldız giriş yaptı.",
          EntityId = 1,
          EntityType = EntityType.User,
          UserId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b",
          EntityName = "Ahmet Yıldız"
      }
  );

            #endregion

            #region Konuşma Örnek Verisi
            builder.Entity<Conversation>().HasData(
     new Conversation
     {
         ConversationId = 1,
         SenderId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b", // Ahmet Yıldız
         ReceiverId = "f8c9debe-935b-432a-b8a2-7c417f7767b1", // Mehmet Güler
         LastMessageDate = DateTime.UtcNow.AddDays(-1)
     },
     new Conversation
     {
         ConversationId = 2,
         SenderId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3", // Ayşe Fidan Yılmaz
         ReceiverId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b", // Ahmet Yıldız
         LastMessageDate = DateTime.UtcNow.AddDays(-2)
     },
     new Conversation
     {
         ConversationId = 3,
         SenderId = "f8c9debe-935b-432a-b8a2-7c417f7767b1", // Mehmet Güler
         ReceiverId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3", // Ayşe Fidan Yılmaz
         LastMessageDate = DateTime.UtcNow.AddDays(-3)
     }
 );

            #endregion

            #region Favoriler Örnek Verisi
            builder.Entity<Favorite>().HasData(
      new Favorite
      {
          FavoriteId = 1,
          UserId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b", // Ahmet Yıldız
          ProductId = 1, // Gaming Laptop
          ServiceId = null
      },
      new Favorite
      {
          FavoriteId = 2,
          UserId = "f8c9debe-935b-432a-b8a2-7c417f7767b1", // Mehmet Güler
          ProductId = 2, // Kablosuz Kulaklık
          ServiceId = null
      },
      new Favorite
      {
          FavoriteId = 3,
          UserId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3", // Ayşe Fidan Yılmaz
          ProductId = 7, // Hyaluronik Asit Serum
          ServiceId = null
      },
      new Favorite
      {
          FavoriteId = 4,
          UserId = "d04b2879-cff4-4d92-8e3f-97acdc6c0e42", // Ali Çelik
          ProductId = 5, // Akıllı Telefon X
          ServiceId = null
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
        Content = "Merhaba, Gaming Laptop hakkında daha fazla bilgi alabilir miyim?",
        SentDate = DateTime.UtcNow.AddDays(-2),
        IsRead = false,
        FileUrl = "/images/product.jpg",
        ConversationId = 1
    },
    new Message
    {
        MessageId = 2,
        SenderId = "f8c9debe-935b-432a-b8a2-7c417f7767b1",
        ReceiverId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b",
        Content = "Tabii, Gaming Laptop hakkında her türlü bilgiyi verebilirim. Hangi özelliklere bakıyorsunuz?",
        SentDate = DateTime.UtcNow.AddDays(-1),
        IsRead = false,
        FileUrl = "/images/product.jpg",
        ConversationId = 1
    },
    new Message
    {
        MessageId = 3,
        SenderId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3",
        ReceiverId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b",
        Content = "Merhaba Ahmet, cilt bakım ürünlerimiz hakkında bilgi almak ister misiniz?",
        SentDate = DateTime.UtcNow.AddDays(-3),
        IsRead = true,
        ConversationId = 2
    },
    new Message
    {
        MessageId = 4,
        SenderId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b",
        ReceiverId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3",
        Content = "Evet, ilgileniyorum. Hangi ürünleri önerirsiniz?",
        SentDate = DateTime.UtcNow.AddDays(-2),
        IsRead = false,
        ConversationId = 2
    },
    new Message
    {
        MessageId = 5,
        SenderId = "f8c9debe-935b-432a-b8a2-7c417f7767b1",
        ReceiverId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3",
        Content = "Merhaba Ayşe, telefon kılıfını almak istiyorum, hangi renkleri önerirsin?",
        SentDate = DateTime.UtcNow.AddDays(-1),
        IsRead = false,
        FileUrl = "/images/product.jpg",
        ConversationId = 3
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
           ProductId = 1,  // Gaming Laptop ile ilişkilendir
           ServiceId = null,
           BusinessProfileId = null,
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
           ProductId = 2,  // Kablosuz Kulaklık ile ilişkilendir
           ServiceId = null,
           BusinessProfileId = null,
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
           ProductId = null,
           ServiceId = null,
           BusinessProfileId = 1,  // TechWorld işletme profili ile ilişkilendir
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
           ProductId = null,
           ServiceId = null,
           BusinessProfileId = null,
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
           ProductId = null,
           ServiceId = null,
           BusinessProfileId = null,
       }
   );


            #endregion

            #region Yorum Örnek Verisi
            builder.Entity<Review>().HasData(
    new Review
    {
        ReviewId = 1,
        Rating = 5,
        Comment = "Gaming Laptop gerçekten harika, yüksek performans ve uzun pil ömrü ile çok beğendim!",
        DateCreated = DateTime.UtcNow.AddDays(-5),
        ProductId = 1,
        ServiceId = null,
        UserId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b"
    },
    new Review
    {
        ReviewId = 2,
        Rating = 4,
        Comment = "Kablosuz Kulaklık güzel ama biraz daha ses yalıtımı olabilirdi.",
        DateCreated = DateTime.UtcNow.AddDays(-4),
        ProductId = 2,
        ServiceId = null,
        UserId = "f8c9debe-935b-432a-b8a2-7c417f7767b1"
    },
    new Review
    {
        ReviewId = 3,
        Rating = 3,
        Comment = "Tablet Pro 2025 fena değil ancak ekranı biraz daha parlak olabilirdi.",
        DateCreated = DateTime.UtcNow.AddDays(-3),
        ProductId = 3,
        ServiceId = null,
        UserId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3"
    },
    new Review
    {
        ReviewId = 4,
        Rating = 5,
        Comment = "Telefon Kılıfı çok sağlam ve şık. Telefonu koruma konusunda çok başarılı.",
        DateCreated = DateTime.UtcNow.AddDays(-2),
        ProductId = 6,
        ServiceId = null,
        UserId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b"
    },
    new Review
    {
        ReviewId = 5,
        Rating = 4,
        Comment = "Cilt bakımında gerçekten iyi sonuçlar aldım, fakat biraz daha nemlendirici olabilir.",
        DateCreated = DateTime.UtcNow.AddDays(-1),
        ProductId = 7,
        ServiceId = null,
        UserId = "f8c9debe-935b-432a-b8a2-7c417f7767b1"
    },
    new Review
    {
        ReviewId = 6,
        Rating = 2,
        Comment = "Makyaj seti beklediğimi vermedi. Kalıcılığı çok düşük.",
        DateCreated = DateTime.UtcNow.AddDays(-7),
        ProductId = 9,
        ServiceId = null,
        UserId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3"
    },
    new Review
    {
        ReviewId = 7,
        Rating = 5,
        Comment = "Hyaluronik Asit Serum mükemmel. Cildim çok daha parlak ve nemli oldu.",
        DateCreated = DateTime.UtcNow.AddDays(-6),
        ProductId = 7,
        ServiceId = null,
        UserId = "d04b2879-cff4-4d92-8e3f-97acdc6c0e42"
    }
);


            #endregion

            #region Kullanıcı Takip Örnek Verisi
            builder.Entity<UserFollow>().HasData(
     new UserFollow
     {
         FollowerId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b", // Ahmet Yıldız
         FollowedId = "f8c9debe-935b-432a-b8a2-7c417f7767b1"  // Mehmet Güler
     },
     new UserFollow
     {
         FollowerId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b", // Ahmet Yıldız
         FollowedId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3"  // Ayşe Fidan Yılmaz
     },
     new UserFollow
     {
         FollowerId = "f8c9debe-935b-432a-b8a2-7c417f7767b1", // Mehmet Güler
         FollowedId = "d04b2879-cff4-4d92-8e3f-97acdc6c0e42"  // Ali Çelik
     },
     new UserFollow
     {
         FollowerId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3", // Ayşe Fidan Yılmaz
         FollowedId = "f8c9debe-935b-432a-b8a2-7c417f7767b1"  // Mehmet Güler
     }
 );

            #endregion

            #region Kullanıcı Profil Özelleştirme Örnek Verisi
            builder.Entity<UserProfileCustomization>().HasData(
       new UserProfileCustomization
       {
           UserProfileCustomizationId = 1,
           UserId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b", // Ahmet Yıldız
           CustomProfileImage = "/images/user1.jpg",
           CustomBackgroundImage = "/images/businnesBackground.png",
           CustomDescription = "Kişisel teknoloji meraklısı, oyun bilgisayarları ve aksesuarları hakkında bilgi sahibi."
       },
       new UserProfileCustomization
       {
           UserProfileCustomizationId = 2,
           UserId = "f8c9debe-935b-432a-b8a2-7c417f7767b1", // Mehmet Güler
           CustomProfileImage = "/images/user2.jpg",
           CustomBackgroundImage = "/images/businnesBackground.png",
           CustomDescription = "Satış uzmanı, kulaklıklar ve telefon aksesuarları konusunda uzman."
       },
       new UserProfileCustomization
       {
           UserProfileCustomizationId = 3,
           UserId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3", // Ayşe Fidan Yılmaz
           CustomProfileImage = "/images/user4.jpg",
           CustomBackgroundImage = "/images/businnesBackground.png",
           CustomDescription = "Cilt bakımına meraklı, makyaj ürünleri ve kişisel bakım konusunda bilgi sahibiyim."
       },
       new UserProfileCustomization
       {
           UserProfileCustomizationId = 4,
           UserId = "d04b2879-cff4-4d92-8e3f-97acdc6c0e42", // Ali Çelik
           CustomProfileImage = "/images/user3.jpg",
           CustomBackgroundImage = "/images/businnesBackground.png",
           CustomDescription = "İşletme sahibi, teknoloji ürünleri ve kişisel bakım ürünleri satışı yapıyorum."
       }
   );

            #endregion

            #region İşletme örnek verileri
            builder.Entity<BusinessProfile>().HasData(
                new BusinessProfile
                {
                    BusinessProfileId = 1,
                    BusinessName = "TechWorld",
                    BusinessDescription = "En yeni teknolojik ürünleri bulabileceğiniz mağaza.",
                    ContactInfo = "techworld@business.com - 0212 123 45 67",
                    Location = "İstanbul, Türkiye",
                    ClickCount = 0,
                    LikeCount = 0,
                    OwnerId = "d04b2879-cff4-4d92-8e3f-97acdc6c0e42", // Ali Çelik (BusinessOwner)
                },
                new BusinessProfile
                {
                    BusinessProfileId = 2,
                    BusinessName = "BeautyGlow",
                    BusinessDescription = "Kozmetik ve cilt bakım ürünleri üzerine uzmanlaşmış bir mağaza.",
                    ContactInfo = "beautyglow@business.com - 0216 765 43 21",
                    Location = "Ankara, Türkiye",
                    ClickCount = 0,
                    LikeCount = 0,
                    OwnerId = "d04b2879-cff4-4d92-8e3f-97acdc6c0e42", // Ali Çelik (BusinessOwner)
                }
            );

            #endregion

            #region İşletme Profili Özelleştirme Örnek Verisi
            builder.Entity<BusinessProfileCustomization>().HasData(
                    new BusinessProfileCustomization
                    {
                        BusinessProfileCustomizationId = 1,
                        BusinessProfileId = 1,
                        CustomProfileImage = "/images/businnesProfile.png",
                        CustomBackgroundImage = "/images/businnesBackground.png",
                        CustomDescription = "Teknoloji severler için en yeni ürünleri sunuyoruz."
                    },
                    new BusinessProfileCustomization
                    {
                        BusinessProfileCustomizationId = 2,
                        BusinessProfileId = 2,
                        CustomProfileImage = "/images/businnesProfile.png",
                        CustomBackgroundImage = "/images/businnesBackground.png",
                        CustomDescription = "Cilt bakımında en kaliteli ürünleri sizin için seçiyoruz."
                    }
                );

            #endregion

            #region Kampanya Örnek Verisi
            builder.Entity<Campaign>().HasData(
      new Campaign
      {
          CampaignId = 1,
          Title = "Bahar İndirimi",
          Description = "Tüm teknolojik ürünlerde %15 indirim!",
          StartDate = new DateTime(2025, 3, 10),
          EndDate = new DateTime(2025, 3, 20),
          DiscountPercentage = 15.00m,
          ClickCount = 0,
          LikeCount = 0,
          ViewCount = 0,
          BusinessProfileId = 1 // TechWorld mağazası
      },
      new Campaign
      {
          CampaignId = 2,
          Title = "Cilt Bakım Günleri",
          Description = "Seçili cilt bakım ürünlerinde %20 indirim fırsatı!",
          StartDate = new DateTime(2025, 4, 1),
          EndDate = new DateTime(2025, 4, 15),
          DiscountPercentage = 20.00m,
          ClickCount = 0,
          LikeCount = 0,
          ViewCount = 0,
          BusinessProfileId = 2 // BeautyGlow mağazası
      }
  );



            #endregion

            #region Hizmet Örnek Verisi
            builder.Entity<Service>().HasData(
       new Service
       {
           ServiceId = 1,
           ServiceName = "Laptop Teknik Servisi",
           Description = "Her marka laptop için profesyonel teknik servis hizmeti.",
           Price = 250.00m,
           ClickCount = 0,
           LikeCount = 0,
           BusinessProfileId = 1 // TechWorld mağazası
       },
       new Service
       {
           ServiceId = 2,
           ServiceName = "Telefon Tamiri",
           Description = "Ekran değişimi, batarya değişimi ve diğer tamir hizmetleri.",
           Price = 150.00m,
           ClickCount = 0,
           LikeCount = 0,
           BusinessProfileId = 1 // TechWorld mağazası
       },
       new Service
       {
           ServiceId = 3,
           ServiceName = "Cilt Analizi",
           Description = "Cilt tipinize uygun bakım önerileri ile analiz hizmeti.",
           Price = 100.00m,
           ClickCount = 0,
           LikeCount = 0,
           BusinessProfileId = 2 // BeautyGlow mağazası
       },
       new Service
       {
           ServiceId = 4,
           ServiceName = "Profesyonel Makyaj",
           Description = "Özel günler için profesyonel makyaj hizmeti.",
           Price = 300.00m,
           ClickCount = 0,
           LikeCount = 0,
           BusinessProfileId = 2 // BeautyGlow mağazası
       }
   );



            #endregion


            #region Arama Geçmişi Örnek Verisi
            builder.Entity<SearchHistory>().HasData(
     new SearchHistory
     {
         SearchHistoryId = 1,
         UserId = "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b", // Ahmet Yıldız (User)
         SearchQuery = "Gaming Laptop",
         SearchDate = DateTime.UtcNow.AddDays(-5)
     },
     new SearchHistory
     {
         SearchHistoryId = 2,
         UserId = "f8c9debe-935b-432a-b8a2-7c417f7767b1", // Mehmet Güler (Seller)
         SearchQuery = "Kablosuz Kulaklık",
         SearchDate = DateTime.UtcNow.AddDays(-3)
     },
     new SearchHistory
     {
         SearchHistoryId = 3,
         UserId = "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3", // Ayşe Fidan Yılmaz (Admin)
         SearchQuery = "Hyaluronik Asit Serum",
         SearchDate = DateTime.UtcNow.AddDays(-2)
     },
     new SearchHistory
     {
         SearchHistoryId = 4,
         UserId = "d04b2879-cff4-4d92-8e3f-97acdc6c0e42", // Ali Çelik (BusinessOwner)
         SearchQuery = "Akıllı Telefon X",
         SearchDate = DateTime.UtcNow.AddDays(-1)
     }
 );

            #endregion

            #region Arama Sonucu Örnek Verisi
            builder.Entity<SearchResult>().HasData(
     new SearchResult
     {
         SearchResultId = 1,
         SearchQuery = "Gaming Laptop",
         ProductId = 1,
         BusinessProfileId = 1,
         SearchDate = DateTime.UtcNow.AddDays(-5)
     },
     new SearchResult
     {
         SearchResultId = 2,
         SearchQuery = "Kablosuz Kulaklık",
         ProductId = 2,
         BusinessProfileId = 1,
         SearchDate = DateTime.UtcNow.AddDays(-3)
     },
     new SearchResult
     {
         SearchResultId = 3,
         SearchQuery = "Hyaluronik Asit Serum",
         ProductId = 7,
         BusinessProfileId = 2,
         SearchDate = DateTime.UtcNow.AddDays(-2)
     },
     new SearchResult
     {
         SearchResultId = 4,
         SearchQuery = "Akıllı Telefon X",
         ProductId = 5,
         BusinessProfileId = 1,
         SearchDate = DateTime.UtcNow.AddDays(-1)
     }
 );

            #endregion

            #region Ürün Etiket Örnek Verisi
            builder.Entity<ProductTag>().HasData(
    new ProductTag { ProductId = 1, TagId = 1 },
    new ProductTag { ProductId = 1, TagId = 2 },
    new ProductTag { ProductId = 2, TagId = 3 },
    new ProductTag { ProductId = 2, TagId = 4 },
    new ProductTag { ProductId = 3, TagId = 2 },
    new ProductTag { ProductId = 4, TagId = 5 },
    new ProductTag { ProductId = 5, TagId = 6 },
    new ProductTag { ProductId = 6, TagId = 7 },
    new ProductTag { ProductId = 7, TagId = 8 },
    new ProductTag { ProductId = 8, TagId = 9 },
    new ProductTag { ProductId = 9, TagId = 10 },
    new ProductTag { ProductId = 10, TagId = 11 }
);


            #endregion

            #region Hizmet Etiket Örnek Verisi
            builder.Entity<ServiceTag>().HasData(
      new ServiceTag { ServiceId = 1, TagId = 1 },
      new ServiceTag { ServiceId = 1, TagId = 2 },
      new ServiceTag { ServiceId = 2, TagId = 3 },
      new ServiceTag { ServiceId = 2, TagId = 4 },
      new ServiceTag { ServiceId = 3, TagId = 8 },
      new ServiceTag { ServiceId = 3, TagId = 9 },
      new ServiceTag { ServiceId = 4, TagId = 10 },
      new ServiceTag { ServiceId = 4, TagId = 11 }
  );

            #endregion

            #region Etiket Örnek Verisi
            builder.Entity<Tag>().HasData(
      new Tag { TagId = 1, Name = "Gaming" },
      new Tag { TagId = 2, Name = "Laptop" },
      new Tag { TagId = 3, Name = "Bluetooth" },
      new Tag { TagId = 4, Name = "Kulaklık" },
      new Tag { TagId = 5, Name = "Klavye" },
      new Tag { TagId = 6, Name = "Akıllı Telefon" },
      new Tag { TagId = 7, Name = "Aksesuar" },
      new Tag { TagId = 8, Name = "Cilt Bakımı" },
      new Tag { TagId = 9, Name = "Serum" },
      new Tag { TagId = 10, Name = "Makyaj" },
      new Tag { TagId = 11, Name = "Fondöten" }
  );

            #endregion



            base.OnModelCreating(builder);
        }
        #endregion

    }
}