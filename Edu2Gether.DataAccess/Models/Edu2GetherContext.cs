using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Edu2Gether.DataAccess.Models
{
    public partial class Edu2GetherContext : DbContext
    {
        public Edu2GetherContext()
        {
        }

        public Edu2GetherContext(DbContextOptions<Edu2GetherContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Mentee> Mentees { get; set; }
        public virtual DbSet<Mentor> Mentors { get; set; }
        public virtual DbSet<MentorMajor> MentorMajors { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Slot> Slots { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=54.255.199.121,1433;Initial Catalog=Edu2Gether;User ID=sa;Password=ReallyStrongPassword123@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.CanceledBy).IsUnicode(false);

                entity.Property(e => e.MenteeId).IsUnicode(false);

                entity.Property(e => e.MentorId).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Course");

                entity.HasOne(d => d.Mentee)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.MenteeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Mentee");

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.SlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Slot");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Approver).IsUnicode(false);

                entity.Property(e => e.ClassUrl).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.IsActived).IsUnicode(false);

                entity.Property(e => e.MentorId).IsUnicode(false);

                entity.Property(e => e.VideoUrl).IsUnicode(false);

                entity.HasOne(d => d.Mentor)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.MentorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Mentor");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Subject");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.Property(e => e.Image).IsUnicode(false);
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.MenteeId });

                entity.Property(e => e.MenteeId).IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mark_Course");

                entity.HasOne(d => d.Mentee)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.MenteeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mark_Mentee");
            });

            modelBuilder.Entity<Mentee>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Mentee)
                    .HasForeignKey<Mentee>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mentee_User");
            });

            modelBuilder.Entity<Mentor>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.Evidence).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.WebsiteUrl).IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Mentor)
                    .HasForeignKey<Mentor>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mentor_User");
            });

            modelBuilder.Entity<MentorMajor>(entity =>
            {
                entity.HasKey(e => new { e.MentorId, e.MajorId });

                entity.Property(e => e.MentorId).IsUnicode(false);

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.MentorMajors)
                    .HasForeignKey(d => d.MajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MentorMajor_Major");

                entity.HasOne(d => d.Mentor)
                    .WithMany(p => p.MentorMajors)
                    .HasForeignKey(d => d.MentorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MentorMajor_Mentor");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Status).IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Booking");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MentorId).IsUnicode(false);

                entity.HasOne(d => d.Mentor)
                    .WithMany(p => p.Slots)
                    .HasForeignKey(d => d.MentorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Slot_Mentor");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Image).IsUnicode(false);

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("FK_Subject_Major1");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Status).IsUnicode(false);

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction_Payment");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.WalletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction_Wallet");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.IsActived).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Wallets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wallet_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
