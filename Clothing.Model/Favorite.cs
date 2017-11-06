namespace Clothing.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Favorite")]
    public partial class Favorite
    {
        public int id { get; set; }

        public int? pid { get; set; }

        public int? cid { get; set; }

        public DateTime? time { get; set; }
    }
}
