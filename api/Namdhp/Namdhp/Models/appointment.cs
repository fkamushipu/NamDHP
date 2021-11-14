namespace Namdhp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("appointment")]
    public partial class appointment
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

       // [StringLength(50)]
        public string reason { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public int user_id { get; set; }
        public DateTime? date_created { get; set; }

    }
}
