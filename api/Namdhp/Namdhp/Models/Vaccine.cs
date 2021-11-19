namespace Namdhp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vaccine")]
    public partial class Vaccine
    {
        [StringLength(500)]
        public string vaccine_name { get; set; }

        [StringLength(500)]
        public string manufacture { get; set; }

        [StringLength(500)]
        public string side_effects { get; set; }

        [Column(TypeName = "image")]
        public byte[] image { get; set; }

        [StringLength(500)]
        public string general_information { get; set; }

        public int id { get; set; }

        public DateTime? date_created { get; set; }
        public DateTime? date_updated { get; set; }

    }
}
