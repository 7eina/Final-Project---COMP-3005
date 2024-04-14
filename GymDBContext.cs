using System;
using System.Collections.Generic;
using GymApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GymApp;

public partial class GymDBContext : DbContext
{
    public GymDBContext()
    {
    }

    public GymDBContext(DbContextOptions<GymDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminStaff> AdminStaffs { get; set; }

    public virtual DbSet<Availability> Availabilities { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Equipment> Equipments { get; set; }

    public virtual DbSet<HealthMetric> HealthMetrics { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=GymDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminStaff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admin_staff_pkey");

            entity.ToTable("admin_staff");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .HasColumnName("address");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .HasColumnName("fname");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .HasColumnName("lname");
            entity.Property(e => e.Phone)
                .HasMaxLength(14)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.StartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_date");
        });

        modelBuilder.Entity<Availability>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("availabilities_pkey");

            entity.ToTable("availabilities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvailableFrom)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("available_from");
            entity.Property(e => e.AvailableTo)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("available_to");
            entity.Property(e => e.TrainerId).HasColumnName("trainer_id");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Availabilities)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_trainer");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bookings_pkey");

            entity.ToTable("bookings");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminStaffId).HasColumnName("admin_staff_id");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.EndTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_time");
            entity.Property(e => e.IsClass).HasColumnName("is_class");
            entity.Property(e => e.IsSession).HasColumnName("is_session");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.Method)
                .HasMaxLength(30)
                .HasColumnName("method");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.SessionId).HasColumnName("session_id");
            entity.Property(e => e.StartTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_time");
            entity.Property(e => e.TrainerId).HasColumnName("trainer_id");

            entity.HasOne(d => d.AdminStaff).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.AdminStaffId)
                .HasConstraintName("fk_admin_staff");

            entity.HasOne(d => d.Class).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("fk_class");

            entity.HasOne(d => d.Member).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("fk_member");

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("fk_room");

            entity.HasOne(d => d.Session).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("fk_session");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("fk_trainer");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("classes_pkey");

            entity.ToTable("classes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capacity)
                .HasPrecision(2)
                .HasColumnName("capacity");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DifficultyLevel)
                .HasPrecision(1)
                .HasDefaultValueSql("1")
                .HasColumnName("difficulty_level");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("equipments_pkey");

            entity.ToTable("equipments");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.AdminStaffId).HasColumnName("admin_staff_id");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.LastMaintenanceDate).HasColumnName("last_maintenance_date");
            entity.Property(e => e.MaintenanceDuedate).HasColumnName("maintenance_duedate");
            entity.Property(e => e.MaintenanceInfo).HasColumnName("maintenance_info");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");
            entity.Property(e => e.RoomId).HasColumnName("room_id");

            entity.HasOne(d => d.AdminStaff).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.AdminStaffId)
                .HasConstraintName("fk_admin_staff");

            entity.HasOne(d => d.Room).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("fk_room");
        });

        modelBuilder.Entity<HealthMetric>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("health_metrics_pkey");

            entity.ToTable("health_metrics");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BloodPressDown)
                .HasPrecision(3)
                .HasColumnName("blood_press_down");
            entity.Property(e => e.BloodPressUp)
                .HasPrecision(3)
                .HasColumnName("blood_press_up");
            entity.Property(e => e.CholesterolLevel)
                .HasPrecision(5, 2)
                .HasColumnName("cholesterol_level");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.HeartRate)
                .HasPrecision(3)
                .HasColumnName("heart_rate");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.WeightKg)
                .HasPrecision(5, 2)
                .HasColumnName("weight_kg");

            entity.HasOne(d => d.Member).WithMany(p => p.HealthMetrics)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("fk_member");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("members_pkey");

            entity.ToTable("members");

            entity.HasIndex(e => e.Email, "members_email_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .HasColumnName("email");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .HasColumnName("fname");
            entity.Property(e => e.HeightCm)
                .HasPrecision(5, 2)
                .HasColumnName("height_cm");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .HasColumnName("lname");
            entity.Property(e => e.Phone)
                .HasMaxLength(14)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.WeightGoalEndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("weight_goal_end_date");
            entity.Property(e => e.WeightGoalEndKg)
                .HasPrecision(6, 3)
                .HasColumnName("weight_goal_end_kg");
            entity.Property(e => e.WeightGoalStartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("weight_goal_start_date");
            entity.Property(e => e.WeightGoalStartKg)
                .HasPrecision(6, 3)
                .HasColumnName("weight_goal_start_kg");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payments_pkey");

            entity.ToTable("payments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminStaffId).HasColumnName("admin_staff_id");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.PayMethod)
                .HasMaxLength(30)
                .HasColumnName("pay_method");
            entity.Property(e => e.ServiceType)
                .HasMaxLength(50)
                .HasColumnName("service_type");

            entity.HasOne(d => d.AdminStaff).WithMany(p => p.Payments)
                .HasForeignKey(d => d.AdminStaffId)
                .HasConstraintName("fk_admin_staff");

            entity.HasOne(d => d.Member).WithMany(p => p.Payments)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("fk_member");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rooms_pkey");

            entity.ToTable("rooms");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capacity)
                .HasPrecision(2)
                .HasColumnName("capacity");
            entity.Property(e => e.Location)
                .HasMaxLength(40)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sessions_pkey");

            entity.ToTable("sessions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DifficultyLevel)
                .HasPrecision(1)
                .HasColumnName("difficulty_level");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("trainers_pkey");

            entity.ToTable("trainers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .HasColumnName("address");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .HasColumnName("fname");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .HasColumnName("lname");
            entity.Property(e => e.Phone)
                .HasMaxLength(14)
                .IsFixedLength()
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
