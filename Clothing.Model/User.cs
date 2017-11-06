namespace Clothing.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(16)]
        public string pwd { get; set; }

        [StringLength(11)]
        public string phone { get; set; }

        public DateTime? createtime { get; set; }
    }
}
