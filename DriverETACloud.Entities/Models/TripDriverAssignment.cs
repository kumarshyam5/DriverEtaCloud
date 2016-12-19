namespace DriverETACloud.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TripDriverAssignment")]
    public partial class TripDriverAssignment
    {
        public int ID { get; set; }

        public int DriverID { get; set; }

        public int TripID { get; set; }

        [StringLength(20)]
        public string LastChangeUserID { get; set; }

        public DateTime? LastChangeTimeStamp { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual Trip Trip { get; set; }
    }
}
