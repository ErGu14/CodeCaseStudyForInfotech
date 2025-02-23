using Commercium.Entity;
using Commercium.Entity.Businness;
using Commercium.Entity.Search;
using Commercium.Entity.Tags;
using Commercium.Entity.User;
using Commercium.Entity.User.Account;
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
        public DbSet<Media> Media { get; set; }
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
            base.OnModelCreating(builder);

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
                .HasKey(bpt => new { bpt.BusinessProfileId, bpt.TagId });  

            builder.Entity<BusinessProfileTag>()
                .HasOne(bpt => bpt.BusinessProfile)
                .WithMany(bp => bp.BusinessProfileTags)
                .HasForeignKey(bpt => bpt.BusinessProfileId);

            builder.Entity<BusinessProfileTag>()
                .HasOne(bpt => bpt.Tag)
                .WithMany(t => t.BusinessProfileTags)
                .HasForeignKey(bpt => bpt.TagId);

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
        }
        #endregion

    }
}