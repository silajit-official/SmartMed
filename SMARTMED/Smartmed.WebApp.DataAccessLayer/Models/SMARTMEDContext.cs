using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Smartmed.WebApp.DataAccessLayer.Models
{
    public partial class SMARTMEDContext : DbContext
    {
        public SMARTMEDContext()
        {
        }

        public SMARTMEDContext(DbContextOptions<SMARTMEDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActivePatient> ActivePatient { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Credential> Credential { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<NonActivePatient> NonActivePatient { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source =(localdb)\\mssqllocaldb;Initial Catalog=SMARTMED;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivePatient>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__active_p__CA1FE46419044B83");

                entity.ToTable("active_patient");

                entity.Property(e => e.BedNumber)
                    .HasColumnName("bed_number")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Bill)
                    .HasColumnName("bill")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.DateOfArrival)
                    .HasColumnName("Date_of_arrival")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorId).HasColumnName("doctorId");

                entity.Property(e => e.ExpectedDateOfDischarge)
                    .HasColumnName("expected_date_of_discharge")
                    .HasColumnType("date");

                entity.Property(e => e.MedicineCost)
                    .HasColumnName("medicine_cost")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.MedicineName)
                    .HasColumnName("medicine_name")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasColumnName("phone_no")
                    .HasColumnType("numeric(12, 0)");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.ActivePatient)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__active_pa__docto__4AB81AF0");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__bill__DDDF64468B61D57E");

                entity.ToTable("bill");

                entity.Property(e => e.Sno).HasColumnName("sno");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.BedNumber)
                    .HasColumnName("bed_number")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Dates)
                    .HasColumnName("dates")
                    .HasColumnType("date");

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__credenti__AB6E6165F9F46B02");

                entity.ToTable("credential");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobRole)
                    .HasColumnName("Job_Role")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasColumnType("numeric(12, 0)");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("doctor");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.CertifiedIn)
                    .HasColumnName("certified_in")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorName)
                    .HasColumnName("doctor_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasColumnName("phone_no")
                    .HasColumnType("numeric(12, 0)");
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__expense__DDDF6446570BC0F6");

                entity.ToTable("expense");

                entity.Property(e => e.Sno).HasColumnName("sno");

                entity.Property(e => e.Dates)
                    .HasColumnName("dates")
                    .HasColumnType("date");

                entity.Property(e => e.Expense1)
                    .HasColumnName("expense")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Field)
                    .HasColumnName("field")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__income__DDDF64460E6F1E73");

                entity.ToTable("income");

                entity.Property(e => e.Sno).HasColumnName("sno");

                entity.Property(e => e.Dates)
                    .HasColumnName("dates")
                    .HasColumnType("date");

                entity.Property(e => e.Field)
                    .HasColumnName("field")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Income1)
                    .HasColumnName("income")
                    .HasColumnType("numeric(10, 0)");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.HasKey(e => e.MedicineName)
                    .HasName("PK__medicine__BF6CFE39FE2EF80F");

                entity.ToTable("medicine");

                entity.Property(e => e.MedicineName)
                    .HasColumnName("medicine_name")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnName("expiry_date")
                    .HasColumnType("date");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("numeric(8, 0)");
            });

            modelBuilder.Entity<NonActivePatient>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("PK__non_acti__A29291303CACEAF6");

                entity.ToTable("non_active_patient");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("unique_id")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfArrival)
                    .HasColumnName("Date_of_arrival")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorId).HasColumnName("doctorId");

                entity.Property(e => e.ExpectedDateOfDischarge)
                    .HasColumnName("expected_date_of_discharge")
                    .HasColumnType("date");

                entity.Property(e => e.MedicineName)
                    .HasColumnName("medicine_name")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.NonActivePatient)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__non_activ__docto__37A5467C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
