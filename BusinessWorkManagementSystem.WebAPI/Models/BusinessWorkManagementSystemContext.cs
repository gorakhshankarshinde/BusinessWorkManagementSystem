using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusinessWorkManagementSystem;

public partial class BusinessWorkManagementSystemContext : DbContext
{
    public BusinessWorkManagementSystemContext()
    {
    }

    public BusinessWorkManagementSystemContext(DbContextOptions<BusinessWorkManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCountry> TblCountries { get; set; }

    public virtual DbSet<TblUserMaster> TblUserMasters { get; set; }

    public virtual DbSet<TblUserType> TblUserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
    
    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-E3QEKAH;Database=BusinessWorkManagementSystem;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCountry>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_Country");

            entity.HasIndex(e => e.IsoCode, "UQ__Tbl_Coun__8AA63E2EF170CC83").IsUnique();

            entity.Property(e => e.CountryId).ValueGeneratedOnAdd();
            entity.Property(e => e.CountryName).HasMaxLength(100);
            entity.Property(e => e.IsoCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISO_Code");
        });

        modelBuilder.Entity<TblUserMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_UserMaster");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.UserEmailAddress).HasMaxLength(500);
            entity.Property(e => e.UserFirstName).HasMaxLength(100);
            entity.Property(e => e.UserId).ValueGeneratedOnAdd();
            entity.Property(e => e.UserLastName).HasMaxLength(100);
            entity.Property(e => e.UserMobileNumber)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<TblUserType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_UserType");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.UserType).HasMaxLength(50);
            entity.Property(e => e.UserTypeId).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
