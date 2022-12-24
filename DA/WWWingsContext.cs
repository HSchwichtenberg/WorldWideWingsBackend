using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

// Kontextklasse mit ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues
// Autor der T4-Vorlage: Dr. Holger Schwichtenberg, 8.9.2022
// Generiert mit EF Core 7.0.0 am 12/05/2022 21:11:32 von ITV\HS

namespace DA;

public partial class WWWingsContext : DbContext
{
 public static string ConnectionString { get; set; } = "Server=D120;Database=WWWingsV1_EN;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=false";

 public WWWingsContext()
 {
  // this.Log();
 }

 public WWWingsContext(DbContextOptions<WWWingsContext> options)
     : base(options)
 {
 }

 public virtual DbSet<Airport> Airport { get; set; }

 public virtual DbSet<Employee> Employee { get; set; }

 public virtual DbSet<Flight> Flight { get; set; }

 public virtual DbSet<Passenger> Passenger { get; set; }

 public virtual DbSet<Person> Person { get; set; }

 public virtual DbSet<Pilot> Pilot { get; set; }

 public virtual DbSet<V_Booking_DETAILS> V_Booking_DETAILS { get; set; }

 public virtual DbSet<V_DepartureStatistics> V_DepartureStatistics { get; set; }

 public virtual DbSet<V_Employee_DETAILS> V_Employee_DETAILS { get; set; }

 public virtual DbSet<V_FlightsFromRome> V_FlightsFromRome { get; set; }

 public virtual DbSet<V_Passenger_DETAILS> V_Passenger_DETAILS { get; set; }

 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
     => optionsBuilder.UseSqlServer(ConnectionString);

 protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
  modelBuilder.Entity<Airport>(entity =>
  {

   // Set Change Tracking Strategy
   var s = ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues; // Snapshot, ChangedNotifications, ChangingAndChangedNotifications, ChangingAndChangedNotificationsWithOriginalValues
   Console.WriteLine("Airport: " + s);
   entity.HasChangeTrackingStrategy(s);

   entity.HasKey(e => e.Name);

   entity.ToTable("Airport", "Properties", tb => tb.HasComment("An Airport with is Geo-Coordinate (WGS 84, SRID 4326)"));

   entity.Property(e => e.Name)
             .HasMaxLength(30)
             .IsFixedLength();
  });

  modelBuilder.Entity<Employee>(entity =>
  {

   // Set Change Tracking Strategy
   var s = ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues; // Snapshot, ChangedNotifications, ChangingAndChangedNotifications, ChangingAndChangedNotificationsWithOriginalValues
   Console.WriteLine("Employee: " + s);
   entity.HasChangeTrackingStrategy(s);

   entity.HasKey(e => e.PersonID);

   entity.ToTable("Employee", "People", tb => tb.HasComment("An Employee is a specialization of a Person."));

   entity.Property(e => e.PersonID).ValueGeneratedNever();
   entity.Property(e => e.HireDate).HasColumnType("datetime");

   entity.HasOne(d => d.Person).WithOne(p => p.Employee)
             .HasForeignKey<Employee>(d => d.PersonID)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK_MI_Employee_PE_Person");

   entity.HasOne(d => d.Supervisor_Person).WithMany(p => p.InverseSupervisor_Person)
             .HasForeignKey(d => d.Supervisor_PersonID)
             .HasConstraintName("FK_Employee_Employee");
  });

  modelBuilder.Entity<Flight>(entity =>
  {

   // Set Change Tracking Strategy
   var s = ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues; // Snapshot, ChangedNotifications, ChangingAndChangedNotifications, ChangingAndChangedNotificationsWithOriginalValues
   Console.WriteLine("Flight: " + s);
   entity.HasChangeTrackingStrategy(s);

   entity.HasKey(e => e.FlightNo);

   entity.ToTable("Flight", "Operation", tb => tb.HasComment("A flight from a Departure City to a Destination City"));

   entity.Property(e => e.FlightNo)
             .ValueGeneratedNever()
             .HasComment("Flight-ID");
   entity.Property(e => e.Airline)
             .HasMaxLength(3)
             .HasComment("2-Letter-Code according to https://de.wikipedia.org/wiki/Liste_der_IATA-Airline-Codes or custom 3-Letter-Code e.g. WWW for World Wide Wings und NCB for Never-Come-Back-Airline :-)");
   entity.Property(e => e.Departure)
             .IsRequired()
             .HasMaxLength(30)
             .HasComment("Name of Departure City (max 30 Letters)");
   entity.Property(e => e.Destination)
             .IsRequired()
             .HasMaxLength(30)
             .HasComment("Name of Destination City (max 30 Letters)");
   entity.Property(e => e.FlightDate)
             .HasComment("Date and Time of planned Depature")
             .HasColumnType("datetime");
   entity.Property(e => e.FreeSeats).HasComment("Number of free Seats on this Flight");
   entity.Property(e => e.Memo)
             .IsUnicode(false)
             .HasComment("Internal Memo, unlimited length");
   entity.Property(e => e.NonSmokingFlight).HasComment("Nowadays, all flights are Non-Smoking");
   entity.Property(e => e.Pilot_PersonID).HasComment("PersonID of the single Pilot (No Co-Pilots :-| )");
   entity.Property(e => e.Seats).HasComment("Total Number of Seats on this Flight");
   entity.Property(e => e.Strikebound).HasComment("A strikebound Flight is not operating because the Pilot and/or other Employees are refusing to work.");
   entity.Property(e => e.Timestamp)
             .IsRowVersion()
             .IsConcurrencyToken()
             .HasComment("Rowversion for Concurrecy Check");
   entity.Property(e => e.Utilization).HasComment("FreeSeats / Seats (calculated in DBMS)");

   entity.HasOne(d => d.Pilot_Person).WithMany(p => p.Flight)
             .HasForeignKey(d => d.Pilot_PersonID)
             .HasConstraintName("FK_FL_Flight_PI_Pilot");

   entity.HasMany(d => d.Passenger_Person).WithMany(p => p.Flight_FlightNo)
             .UsingEntity<Dictionary<string, object>>(
                 "Flight_Passenger",
                 r => r.HasOne<Passenger>().WithMany()
                     .HasForeignKey("Passenger_PersonID")
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_Flight_Passenger_Passenger"),
                 l => l.HasOne<Flight>().WithMany()
                     .HasForeignKey("Flight_FlightNo")
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_Flight_Passenger_Flight"),
                 j =>
                 {
                  j.HasKey("Flight_FlightNo", "Passenger_PersonID").IsClustered(false);
                  j.ToTable("Flight_Passenger", "Operation", tb => tb.HasComment("Booking: Association of a Passenger to a Flight"));
                 });
  });

  modelBuilder.Entity<Passenger>(entity =>
  {

   // Set Change Tracking Strategy
   var s = ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues; // Snapshot, ChangedNotifications, ChangingAndChangedNotifications, ChangingAndChangedNotificationsWithOriginalValues
   Console.WriteLine("Passenger: " + s);
   entity.HasChangeTrackingStrategy(s);

   entity.HasKey(e => e.PersonID);

   entity.ToTable("Passenger", "People", tb => tb.HasComment("A Passenger is a specialization of a Person."));

   entity.Property(e => e.PersonID).ValueGeneratedNever();
   entity.Property(e => e.CustomerSince).HasColumnType("datetime");
   entity.Property(e => e.PassengerStatus)
             .HasMaxLength(1)
             .IsFixedLength();

   entity.HasOne(d => d.Person).WithOne(p => p.Passenger)
             .HasForeignKey<Passenger>(d => d.PersonID)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK_PS_Passenger_PE_Person");
  });

  modelBuilder.Entity<Person>(entity =>
  {

   // Set Change Tracking Strategy
   var s = ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues; // Snapshot, ChangedNotifications, ChangingAndChangedNotifications, ChangingAndChangedNotificationsWithOriginalValues
   Console.WriteLine("Person: " + s);
   entity.HasChangeTrackingStrategy(s);

   entity.ToTable("Person", "People", tb => tb.HasComment("Basic Data of a Person (Person is abstract, used as Passenger, Employee or Pilot)"));

   entity.Property(e => e.Birthday).HasColumnType("datetime");
   entity.Property(e => e.City).HasMaxLength(30);
   entity.Property(e => e.Country).HasMaxLength(2);
   entity.Property(e => e.EMail).HasMaxLength(50);
   entity.Property(e => e.GivenName)
             .IsRequired()
             .HasMaxLength(50);
   entity.Property(e => e.Memo).IsUnicode(false);

   entity.Property(e => e.Surname)
             .IsRequired()
             .HasMaxLength(50);
  });

  modelBuilder.Entity<Pilot>(entity =>
  {

   // Set Change Tracking Strategy
   var s = ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues; // Snapshot, ChangedNotifications, ChangingAndChangedNotifications, ChangingAndChangedNotificationsWithOriginalValues
   Console.WriteLine("Pilot: " + s);
   entity.HasChangeTrackingStrategy(s);

   entity.HasKey(e => e.PersonID);

   entity.ToTable("Pilot", "People", tb => tb.HasComment("A Pilot is a specialization of an Employees"));

   entity.Property(e => e.PersonID).ValueGeneratedNever();
   entity.Property(e => e.FlightSchool).HasMaxLength(50);
   entity.Property(e => e.LicenseDate).HasColumnType("datetime");
   entity.Property(e => e.LicenseType)
             .HasMaxLength(1)
             .IsFixedLength();

   entity.HasOne(d => d.Person).WithOne(p => p.Pilot)
             .HasForeignKey<Pilot>(d => d.PersonID)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK_PI_Pilot_MI_Employee");
  });

  modelBuilder.Entity<V_Booking_DETAILS>(entity =>
  {

   // Set Change Tracking Strategy
   var s = ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues; // Snapshot, ChangedNotifications, ChangingAndChangedNotifications, ChangingAndChangedNotificationsWithOriginalValues
   Console.WriteLine("V_Booking_DETAILS: " + s);
   entity.HasChangeTrackingStrategy(s);

   entity
             .HasNoKey()
             .ToView("V_Booking_DETAILS", "Operation");

   entity.Property(e => e.Departure)
             .IsRequired()
             .HasMaxLength(30);
   entity.Property(e => e.Destination)
             .IsRequired()
             .HasMaxLength(30);
   entity.Property(e => e.FlightDate).HasColumnType("datetime");
   entity.Property(e => e.Fullname)
             .IsRequired()
             .HasMaxLength(101);
  });

  modelBuilder.Entity<V_DepartureStatistics>(entity =>
  {

   // Set Change Tracking Strategy
   var s = ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues; // Snapshot, ChangedNotifications, ChangingAndChangedNotifications, ChangingAndChangedNotificationsWithOriginalValues
   Console.WriteLine("V_DepartureStatistics: " + s);
   entity.HasChangeTrackingStrategy(s);

   entity
             .HasNoKey()
             .ToView("V_DepartureStatistics", "Operation");

   entity.Property(e => e.departure)
             .IsRequired()
             .HasMaxLength(30);
  });

  modelBuilder.Entity<V_Employee_DETAILS>(entity =>
  {

   // Set Change Tracking Strategy
   var s = ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues; // Snapshot, ChangedNotifications, ChangingAndChangedNotifications, ChangingAndChangedNotificationsWithOriginalValues
   Console.WriteLine("V_Employee_DETAILS: " + s);
   entity.HasChangeTrackingStrategy(s);

   entity
             .HasNoKey()
             .ToView("V_Employee_DETAILS", "People");

   entity.Property(e => e.Birthday).HasColumnType("datetime");
   entity.Property(e => e.Country).HasMaxLength(2);
   entity.Property(e => e.EMail).HasMaxLength(50);
   entity.Property(e => e.GivenName)
             .IsRequired()
             .HasMaxLength(50);
   entity.Property(e => e.HireDate).HasColumnType("datetime");
   entity.Property(e => e.SurName)
             .IsRequired()
             .HasMaxLength(50);
  });

  modelBuilder.Entity<V_FlightsFromRome>(entity =>
  {

   // Set Change Tracking Strategy
   var s = ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues; // Snapshot, ChangedNotifications, ChangingAndChangedNotifications, ChangingAndChangedNotificationsWithOriginalValues
   Console.WriteLine("V_FlightsFromRome: " + s);
   entity.HasChangeTrackingStrategy(s);

   entity
             .HasNoKey()
             .ToView("V_FlightsFromRome", "Operation");

   entity.Property(e => e.Departure)
             .IsRequired()
             .HasMaxLength(30);
   entity.Property(e => e.Destination)
             .IsRequired()
             .HasMaxLength(30);
   entity.Property(e => e.FlightDate).HasColumnType("datetime");
   entity.Property(e => e.Memo).IsUnicode(false);
  });

  modelBuilder.Entity<V_Passenger_DETAILS>(entity =>
  {

   // Set Change Tracking Strategy
   var s = ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues; // Snapshot, ChangedNotifications, ChangingAndChangedNotifications, ChangingAndChangedNotificationsWithOriginalValues
   Console.WriteLine("V_Passenger_DETAILS: " + s);
   entity.HasChangeTrackingStrategy(s);

   entity
             .HasNoKey()
             .ToView("V_Passenger_DETAILS", "Operation");

   entity.Property(e => e.Birthday).HasColumnType("datetime");
   entity.Property(e => e.Country).HasMaxLength(2);
   entity.Property(e => e.CustomerSince).HasColumnType("datetime");
   entity.Property(e => e.EMail).HasMaxLength(50);
   entity.Property(e => e.Fullname)
             .IsRequired()
             .HasMaxLength(101);
   entity.Property(e => e.GivenName)
             .IsRequired()
             .HasMaxLength(50);
   entity.Property(e => e.PassengerStatus)
             .HasMaxLength(1)
             .IsFixedLength();
   entity.Property(e => e.Surname)
             .IsRequired()
             .HasMaxLength(50);
  });

  OnModelCreatingPartial(modelBuilder);
 }

 partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
