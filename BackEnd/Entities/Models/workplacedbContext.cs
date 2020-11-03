using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Models
{
    public partial class workplacedbContext : DbContext
    {
        public workplacedbContext()
        {
        }

        public workplacedbContext(DbContextOptions<workplacedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Detailpermission> Detailpermission { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Relationshipuserpermission> Relationshipuserpermission { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Workspace> Workspace { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=1212;database=workplacedb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.HasIndex(e => e.ParentId)
                    .HasName("parentID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId)
                    .HasColumnName("parentID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("department_ibfk_1");
            });

            modelBuilder.Entity<Detailpermission>(entity =>
            {
                entity.ToTable("detailpermission");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("permissionID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ActionCode)
                    .IsRequired()
                    .HasColumnName("actionCode")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ActionName)
                    .HasColumnName("actionName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CheckAction)
                    .HasColumnName("checkAction")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("permissionID")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.Detailpermission)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("detailpermission_ibfk_1");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location");

                entity.HasIndex(e => e.ParentId)
                    .HasName("parentID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId)
                    .HasColumnName("parentID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("location_ibfk_1");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("permission");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Relationshipuserpermission>(entity =>
            {
                entity.ToTable("relationshipuserpermission");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("permissionID");

                entity.HasIndex(e => e.UserId)
                    .HasName("userID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("permissionID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Suspended)
                    .HasColumnName("suspended")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.Relationshipuserpermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("relationshipuserpermission_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Relationshipuserpermission)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("relationshipuserpermission_ibfk_1");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("reservation");

                entity.HasIndex(e => e.UserId)
                    .HasName("userID");

                entity.HasIndex(e => e.WorkspaceId)
                    .HasName("workspaceID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BeginTime).HasColumnName("beginTime");

                entity.Property(e => e.EndTime).HasColumnName("endTime");

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.WorkspaceId)
                    .HasColumnName("workspaceID")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reservation_ibfk_1");

                entity.HasOne(d => d.Workspace)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.WorkspaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reservation_ibfk_2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("departmentID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasColumnName("displayName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PassWord)
                    .IsRequired()
                    .HasColumnName("passWord")
                    .HasMaxLength(10000)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Workspace>(entity =>
            {
                entity.ToTable("workspace");

                entity.HasIndex(e => e.LocationId)
                    .HasName("locationID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.LocationId)
                    .HasColumnName("locationID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(1)");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Workspace)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("workspace_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
