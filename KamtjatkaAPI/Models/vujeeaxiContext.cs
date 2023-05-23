using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KamtjatkaAPI.Models
{
    public partial class vujeeaxiContext : DbContext
    {
        public vujeeaxiContext()
        {
        }

        public vujeeaxiContext(DbContextOptions<vujeeaxiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<AppointmentCategory> AppointmentCategories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Finance> Finances { get; set; }
        public virtual DbSet<FinanceCategory> FinanceCategories { get; set; }
        public virtual DbSet<KamtjatkaInfo> KamtjatkaInfos { get; set; }
        public virtual DbSet<PgStatStatement> PgStatStatements { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomBooking> RoomBookings { get; set; }
        public virtual DbSet<RoomCategory> RoomCategories { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }

        public virtual DbSet<Roles> Roles { get; set; }

        public virtual DbSet<Messages> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=dumbo.db.elephantsql.com;Database=vujeeaxi;Port=5432;User Id=vujeeaxi;Password=cAZW3QOqk0SeqDKYfIC-sRIW0htmsx7f;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("btree_gin")
                .HasPostgresExtension("btree_gist")
                .HasPostgresExtension("citext")
                .HasPostgresExtension("cube")
                .HasPostgresExtension("dblink")
                .HasPostgresExtension("dict_int")
                .HasPostgresExtension("dict_xsyn")
                .HasPostgresExtension("earthdistance")
                .HasPostgresExtension("fuzzystrmatch")
                .HasPostgresExtension("hstore")
                .HasPostgresExtension("intarray")
                .HasPostgresExtension("ltree")
                .HasPostgresExtension("pg_stat_statements")
                .HasPostgresExtension("pg_trgm")
                .HasPostgresExtension("pgcrypto")
                .HasPostgresExtension("pgrowlocks")
                .HasPostgresExtension("pgstattuple")
                .HasPostgresExtension("plv8")
                .HasPostgresExtension("tablefunc")
                .HasPostgresExtension("unaccent")
                .HasPostgresExtension("uuid-ossp")
                .HasPostgresExtension("xml2")
                .HasAnnotation("Relational:Collation", "en_US.UTF-8");
          
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.ToTable("administrator", "bpr");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("first_name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("phone");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("surname");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleid");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("appointment", "bpr");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AdministratorId).HasColumnName("administrator_id");

                entity.Property(e => e.AppointmentCategoryId).HasColumnName("appointment_category_id");

                entity.Property(e => e.Cancelled).HasColumnName("cancelled");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DateCreated).HasColumnName("date_created");

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.EndTimeExpected).HasColumnName("end_time_expected");

                entity.Property(e => e.StartTime).HasColumnName("start_time");


                entity.HasOne(d => d.Administrator)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.AdministratorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointment_administrator");

                entity.HasOne(d => d.AppointmentCategory)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.AppointmentCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointment_appointment_category");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointment_customer");
            });

            modelBuilder.Entity<AppointmentCategory>(entity =>
            {
                entity.ToTable("appointment_category", "bpr");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer", "bpr");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AccountCreation).HasColumnName("account_creation");

                entity.Property(e => e.City)
                    .HasMaxLength(64)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(64)
                    .HasColumnName("country");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("first_name");

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(64)
                    .HasColumnName("id_number");

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("nationality");

                entity.Property(e => e.PassportNumber)
                    .HasMaxLength(64)
                    .HasColumnName("passport_number");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(64)
                    .HasColumnName("phone_number");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(64)
                    .HasColumnName("postal_code");

                entity.Property(e => e.Registered).HasColumnName("registered");

                entity.Property(e => e.StreetName)
                    .HasMaxLength(64)
                    .HasColumnName("street_name");

                entity.Property(e => e.StreetNumber)
                    .HasMaxLength(64)
                    .HasColumnName("street_number");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.ToTable("facility", "bpr");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .HasColumnName("description");

                entity.Property(e => e.KamtjatkaInfoId).HasColumnName("kamtjatka_info_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name");

                entity.HasOne(d => d.KamtjatkaInfo)
                    .WithMany(p => p.Facilities)
                    .HasForeignKey(d => d.KamtjatkaInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("facility_kamtjatka_info");
            });

            modelBuilder.Entity<Finance>(entity =>
            {
                entity.ToTable("finance", "bpr");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmountOfMoney)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("amount_of_money");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.DueDate).HasColumnName("due_date");

                entity.Property(e => e.FinanceCategoryId).HasColumnName("finance_category_id");

                entity.Property(e => e.IsPaid)
                    .HasColumnName("is_paid")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Finances)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("finance_customer_id_fkey");

                entity.HasOne(d => d.FinanceCategory)
                    .WithMany(p => p.Finances)
                    .HasForeignKey(d => d.FinanceCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("finance_finance_category_id_fkey");
            });

            modelBuilder.Entity<FinanceCategory>(entity =>
            {
                entity.ToTable("finance_category", "bpr");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<KamtjatkaInfo>(entity =>
            {
                entity.ToTable("kamtjatka_info", "bpr");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AdministratorId).HasColumnName("administrator_id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("country");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("phone_number");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("postal_code");

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("street_name");

                entity.Property(e => e.StreetNumber)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("street_number");

                entity.HasOne(d => d.Administrator)
                    .WithMany(p => p.KamtjatkaInfos)
                    .HasForeignKey(d => d.AdministratorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("kamtjatka_info_administrator");
            });

            modelBuilder.Entity<PgStatStatement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_stat_statements");

                entity.Property(e => e.BlkReadTime).HasColumnName("blk_read_time");

                entity.Property(e => e.BlkWriteTime).HasColumnName("blk_write_time");

                entity.Property(e => e.Calls).HasColumnName("calls");

                entity.Property(e => e.Dbid)
                    .HasColumnType("oid")
                    .HasColumnName("dbid");

                entity.Property(e => e.LocalBlksDirtied).HasColumnName("local_blks_dirtied");

                entity.Property(e => e.LocalBlksHit).HasColumnName("local_blks_hit");

                entity.Property(e => e.LocalBlksRead).HasColumnName("local_blks_read");

                entity.Property(e => e.LocalBlksWritten).HasColumnName("local_blks_written");

                entity.Property(e => e.MaxTime).HasColumnName("max_time");

                entity.Property(e => e.MeanTime).HasColumnName("mean_time");

                entity.Property(e => e.MinTime).HasColumnName("min_time");

                entity.Property(e => e.Query).HasColumnName("query");

                entity.Property(e => e.Queryid).HasColumnName("queryid");

                entity.Property(e => e.Rows).HasColumnName("rows");

                entity.Property(e => e.SharedBlksDirtied).HasColumnName("shared_blks_dirtied");

                entity.Property(e => e.SharedBlksHit).HasColumnName("shared_blks_hit");

                entity.Property(e => e.SharedBlksRead).HasColumnName("shared_blks_read");

                entity.Property(e => e.SharedBlksWritten).HasColumnName("shared_blks_written");

                entity.Property(e => e.StddevTime).HasColumnName("stddev_time");

                entity.Property(e => e.TempBlksRead).HasColumnName("temp_blks_read");

                entity.Property(e => e.TempBlksWritten).HasColumnName("temp_blks_written");

                entity.Property(e => e.TotalTime).HasColumnName("total_time");

                entity.Property(e => e.Userid)
                    .HasColumnType("oid")
                    .HasColumnName("userid");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("room", "bpr");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("number");

                entity.Property(e => e.RoomCategoryId).HasColumnName("room_category_id");

                entity.HasOne(d => d.RoomCategory)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room_room_category");
            });

            modelBuilder.Entity<RoomBooking>(entity =>
            {
                entity.ToTable("room_booking", "bpr");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.EndRentDate).HasColumnName("end_rent_date");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.StartRentDate).HasColumnName("start_rent_date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RoomBookings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room_booking_customer");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomBookings)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room_booking_room");
            });

            modelBuilder.Entity<RoomCategory>(entity =>
            {
                entity.ToTable("room_category", "bpr");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("category_name");

                entity.Property(e => e.Consumption)
                    .HasMaxLength(64)
                    .HasColumnName("consumption");

                entity.Property(e => e.Deposit)
                    .HasMaxLength(64)
                    .HasColumnName("deposit");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.LongDescription)
                    .HasMaxLength(20000)
                    .HasColumnName("long_description");

                entity.Property(e => e.Moveinprice)
                    .HasMaxLength(64)
                    .HasColumnName("moveinprice");

                entity.Property(e => e.NumberOfRooms).HasColumnName("number_of_rooms");

                entity.Property(e => e.PictureLink)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("picture_link");

                entity.Property(e => e.RentPrice)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("rent_price");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedule", "bpr");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AdministratorId).HasColumnName("administrator_id");

                entity.Property(e => e.From).HasColumnName("from");

                entity.Property(e => e.To).HasColumnName("to");

                entity.HasOne(d => d.Administrator)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.AdministratorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("schedule_administrator");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles", "bpr");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");


                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.ToTable("messages", "bpr");
                entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("email");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("subject");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(225)
                    .HasColumnName("message");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
