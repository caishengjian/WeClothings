namespace Clothing.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notice")]
    public partial class Notice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nid { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        [StringLength(50)]
        public string contents { get; set; }

        public int? postuid { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime time { get; set; }
    }
}
