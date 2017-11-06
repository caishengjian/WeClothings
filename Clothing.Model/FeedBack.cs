namespace Clothing.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeedBack")]
    public partial class FeedBack
    {
        public int id { get; set; }

        public int? cid { get; set; }

        [StringLength(50)]
        public string content { get; set; }

        public DateTime? time { get; set; }

        [StringLength(50)]
        public string tel { get; set; }
    }
}
