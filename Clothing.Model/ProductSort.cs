namespace Clothing.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductSort")]
    public partial class ProductSort
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductSort()
        {
            ProductInfo = new HashSet<ProductInfo>();
        }

        [Key]
        [StringLength(4)]
        public string code { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(4)]
        public string fid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductInfo> ProductInfo { get; set; }
    }
}
