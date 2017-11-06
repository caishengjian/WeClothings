namespace Clothing.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banner")]
    public partial class Banner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(50)]
        public string image { get; set; }

        [StringLength(50)]
        public string link { get; set; }

        [StringLength(50)]
        public string memo { get; set; }

        public int? postuid { get; set; }

        public DateTime? time { get; set; }
    }
}
