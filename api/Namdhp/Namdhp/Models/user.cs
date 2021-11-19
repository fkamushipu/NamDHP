namespace Namdhp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
       

        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string last_name { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(500)]
        public string password { get; set; }

        public DateTime? date_of_birth { get; set; }

        [StringLength(50)]
        public string gender { get; set; }

        [StringLength(50)]
        public string cellphone { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public bool? pregnancy_status { get; set; }

        public bool? lactating_status { get; set; }

        [StringLength(50)]
        public string marital_status { get; set; }

        [StringLength(50)]
        public string guardian_name { get; set; }

        [StringLength(50)]
        public string guardian_contact { get; set; }
        
        public int vaccine_type_id { get; set; }

        public bool? vaccination_status{ get; set; }

        [StringLength(50)]
        public string known_allergies { get; set; }

        public DateTime? date_created { get; set; }

        public DateTime? date_updated { get; set; }


    }
}
