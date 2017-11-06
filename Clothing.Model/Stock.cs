namespace Clothing.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stock")]
    public partial class Stock
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? num { get; set; }

        [StringLength(8)]
        public string pid { get; set; }

        public int? billid { get; set; }

        public DateTime? time { get; set; }

        public virtual ProductInfo ProductInfo { get; set; }
    }
}
