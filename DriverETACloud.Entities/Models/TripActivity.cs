namespace DriverETACloud.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TripActivity")]
    public partial class TripActivity
    {
        [Key]
        public int ActivityID { get; set; }

        [Required]
        [StringLength(3)]
        public string ActivityCode { get; set; }

        [StringLength(40)]
        public string ActivityLocation { get; set; }

        public DateTime ActivityDate { get; set; }

        [StringLength(10)]
        public string TrailerID { get; set; }

        [Required]
        [StringLength(10)]
        public string LastChangeUserID { get; set; }

        public DateTime LastChangeTimeStamp { get; set; }

        public int DriverID { get; set; }

        public int TripID { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual Trip Trip { get; set; }
    }
}
