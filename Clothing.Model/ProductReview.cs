namespace Clothing.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductReview")]
    public partial class ProductReview
    {
        public int id { get; set; }

        public int? cid { get; set; }

        [StringLength(8)]
        public string pid { get; set; }

        [StringLength(50)]
        public string contents { get; set; }

        [StringLength(10)]
        public string start { get; set; }

        [StringLength(50)]
        public string images { get; set; }

        public DateTime? time { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ProductInfo ProductInfo { get; set; }
    }
}
