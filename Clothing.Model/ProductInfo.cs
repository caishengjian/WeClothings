namespace Clothing.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductInfo")]
    public partial class ProductInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductInfo()
        {
            OrderBillChi = new HashSet<OrderBillChi>();
            ProductReview = new HashSet<ProductReview>();
            ShopCart = new HashSet<ShopCart>();
            Stock = new HashSet<Stock>();
        }

        [Key]
        [StringLength(8)]
        public string code { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "text")]
        public string describe { get; set; }

        public decimal? zprice { get; set; }

        public decimal? yprice { get; set; }

        [StringLength(50)]
        public string contents { get; set; }

        [StringLength(50)]
        public string images { get; set; }

        [StringLength(10)]
        public string isPackage { get; set; }

        [StringLength(4)]
        public string ProductSortId { get; set; }

        public DateTime? time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderBillChi> OrderBillChi { get; set; }

        public virtual ProductSort ProductSort { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductReview> ProductReview { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShopCart> ShopCart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
