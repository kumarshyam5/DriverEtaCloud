namespace DriverETACloud.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trip
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trip()
        {
            TripActivities = new HashSet<TripActivity>();
            TripDriverAssignments = new HashSet<TripDriverAssignment>();
        }

        public int TripID { get; set; }

        [Required]
        [StringLength(30)]
        public string OriginLocation { get; set; }

        [Required]
        [StringLength(30)]
        public string DestinationLocation { get; set; }

        [Required]
        [StringLength(10)]
        public string TripType { get; set; }

        [Required]
        [StringLength(10)]
        public string TripStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TripActivity> TripActivities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TripDriverAssignment> TripDriverAssignments { get; set; }
    }
}
