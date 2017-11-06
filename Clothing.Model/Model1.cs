namespace Clothing.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Favorite> Favorite { get; set; }
        public virtual DbSet<FeedBack> FeedBack { get; set; }
        public virtual DbSet<Notice> Notice { get; set; }
        public virtual DbSet<OrderBillChi> OrderBillChi { get; set; }
        public virtual DbSet<OrderBillFat> OrderBillFat { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<ProductImage> ProductImage { get; set; }
        public virtual DbSet<ProductInfo> ProductInfo { get; set; }
        public virtual DbSet<ProductReview> ProductReview { get; set; }
        public virtual DbSet<ProductSort> ProductSort { get; set; }
        public virtual DbSet<ReviewImages> ReviewImages { get; set; }
        public virtual DbSet<SearchHistory> SearchHistory { get; set; }
        public virtual DbSet<ShopCart> ShopCart { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<SystemConfig> SystemConfig { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.OrderBillFat)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.cusid);

            modelBuilder.Entity<OrderBillFat>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .HasMany(e => e.OrderBillFat)
                .WithOptional(e => e.Payment)
                .HasForeignKey(e => e.paymethod);

            modelBuilder.Entity<Payment>()
                .HasOptional(e => e.Payment1)
                .WithRequired(e => e.Payment2);

            modelBuilder.Entity<ProductInfo>()
                .Property(e => e.describe)
                .IsUnicode(false);

            modelBuilder.Entity<ProductInfo>()
                .Property(e => e.isPackage)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ProductInfo>()
                .HasMany(e => e.OrderBillChi)
                .WithRequired(e => e.ProductInfo)
                .HasForeignKey(e => e.pid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductInfo>()
                .HasMany(e => e.ProductReview)
                .WithOptional(e => e.ProductInfo)
                .HasForeignKey(e => e.pid);

            modelBuilder.Entity<ProductInfo>()
                .HasMany(e => e.ShopCart)
                .WithOptional(e => e.ProductInfo)
                .HasForeignKey(e => e.pcode);

            modelBuilder.Entity<ProductInfo>()
                .HasMany(e => e.Stock)
                .WithOptional(e => e.ProductInfo)
                .HasForeignKey(e => e.pid);

            modelBuilder.Entity<ProductReview>()
                .Property(e => e.start)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ProductSort>()
                .HasMany(e => e.ProductInfo)
                .WithOptional(e => e.ProductSort)
                .HasForeignKey(e => e.ProductSortId);

            modelBuilder.Entity<ReviewImages>()
                .Property(e => e.Imgname)
                .IsUnicode(false);
        }
    }
}
