namespace Clothing.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            OrderBillFat = new HashSet<OrderBillFat>();
            ProductReview = new HashSet<ProductReview>();
            SearchHistory = new HashSet<SearchHistory>();
            ShopCart = new HashSet<ShopCart>();
        }

        [Key]
        [StringLength(50)]
        public string cid { get; set; }

        [StringLength(50)]
        public string openid { get; set; }

        [StringLength(50)]
        public string nickname { get; set; }

        [StringLength(50)]
        public string tel { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        [StringLength(50)]
        public string image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderBillFat> OrderBillFat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductReview> ProductReview { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SearchHistory> SearchHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShopCart> ShopCart { get; set; }
    }
}
