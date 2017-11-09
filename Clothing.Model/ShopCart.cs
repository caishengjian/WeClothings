namespace Clothing.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShopCart")]
    public partial class ShopCart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(8)]
        public string pcode { get; set; }

        public int? num { get; set; }

        [StringLength(50)]
        public string cid { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime time { get; set; }

        public bool? ischeck { get; set; }

        public decimal? price { get; set; }

        public decimal? sumprice { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ProductInfo ProductInfo { get; set; }
    }
}
