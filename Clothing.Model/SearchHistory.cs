namespace Clothing.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SearchHistory")]
    public partial class SearchHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? cid { get; set; }

        [StringLength(50)]
        public string contents { get; set; }

        public DateTime? time { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
