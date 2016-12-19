namespace DriverETACloud.Entities.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DriverETACloud.Entities.Models;

    public partial class DriverEtaContext : DbContext
    {
        public DriverEtaContext()
            : base("name=DriverEtaContext")
        {
        }

        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<TripActivity> TripActivities { get; set; }
        public virtual DbSet<TripDriverAssignment> TripDriverAssignments { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<Driver>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<Driver>()
                .HasMany(e => e.TripActivities)
                .WithRequired(e => e.Driver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Driver>()
                .HasMany(e => e.TripDriverAssignments)
                .WithRequired(e => e.Driver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TripActivity>()
                .Property(e => e.ActivityCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TripActivity>()
                .Property(e => e.ActivityLocation)
                .IsFixedLength();

            modelBuilder.Entity<TripActivity>()
                .Property(e => e.TrailerID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TripActivity>()
                .Property(e => e.LastChangeUserID)
                .IsFixedLength();

            modelBuilder.Entity<TripDriverAssignment>()
                .Property(e => e.LastChangeUserID)
                .IsFixedLength();

            modelBuilder.Entity<Trip>()
                .Property(e => e.OriginLocation)
                .IsFixedLength();

            modelBuilder.Entity<Trip>()
                .Property(e => e.DestinationLocation)
                .IsFixedLength();

            modelBuilder.Entity<Trip>()
                .Property(e => e.TripType)
                .IsFixedLength();

            modelBuilder.Entity<Trip>()
                .Property(e => e.TripStatus)
                .IsFixedLength();

            modelBuilder.Entity<Trip>()
                .HasMany(e => e.TripActivities)
                .WithRequired(e => e.Trip)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trip>()
                .HasMany(e => e.TripDriverAssignments)
                .WithRequired(e => e.Trip)
                .WillCascadeOnDelete(false);
        }
    }
}
