namespace Clothing.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderBillFat")]
    public partial class OrderBillFat
    {
        [Key]
        public Guid code { get; set; }

        public int? cusid { get; set; }

        [StringLength(10)]
        public string status { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime time { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalPrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OrderPrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ExpressPrice { get; set; }

        public bool? checkuser { get; set; }

        [StringLength(50)]
        public string memo { get; set; }

        public int? paymethod { get; set; }

        public DateTime? ftime { get; set; }

        public DateTime? stime { get; set; }

        public DateTime? ztime { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
