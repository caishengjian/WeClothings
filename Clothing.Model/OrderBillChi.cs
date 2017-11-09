namespace Clothing.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderBillChi")]
    public partial class OrderBillChi
    {
        [Key]
        [Column(Order = 0)]
        public Guid code { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string pid { get; set; }

        [StringLength(50)]
        public string cid { get; set; }

        public int? num { get; set; }

        public decimal? price { get; set; }

        public bool? isReview { get; set; }

        public virtual ProductInfo ProductInfo { get; set; }
    }
}
