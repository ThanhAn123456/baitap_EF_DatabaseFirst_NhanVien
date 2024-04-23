using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace baitap_EF_DatabaseFirst_NhanVien.Models;

public partial class QuanLyNhanVienContext : DbContext
{
    public QuanLyNhanVienContext()
    {
    }

    public QuanLyNhanVienContext(DbContextOptions<QuanLyNhanVienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CongTy> CongTies { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhongBan> PhongBans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=AN;Initial Catalog=QuanLyNhanVien;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CongTy>(entity =>
        {
            entity.HasKey(e => e.MaCongTy).HasName("PK__CongTy__E452D3DBD1864E28");

            entity.ToTable("CongTy");

            entity.Property(e => e.MaCongTy).HasMaxLength(50);
            entity.Property(e => e.TenCongTy).HasMaxLength(100);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70AD26F1818");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(50)
                .HasColumnName("MaNV");
            entity.Property(e => e.DienThoai).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.MaPb)
                .HasMaxLength(50)
                .HasColumnName("MaPB");

            entity.HasOne(d => d.MaPbNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaPb)
                .HasConstraintName("FK__NhanVien__MaPB__4222D4EF");
        });

        modelBuilder.Entity<PhongBan>(entity =>
        {
            entity.HasKey(e => e.MaPb).HasName("PK__PhongBan__2725E7E49D070B53");

            entity.ToTable("PhongBan");

            entity.Property(e => e.MaPb)
                .HasMaxLength(50)
                .HasColumnName("MaPB");
            entity.Property(e => e.MaCongTy).HasMaxLength(50);
            entity.Property(e => e.TenPb)
                .HasMaxLength(100)
                .HasColumnName("TenPB");

            entity.HasOne(d => d.MaCongTyNavigation).WithMany(p => p.PhongBans)
                .HasForeignKey(d => d.MaCongTy)
                .HasConstraintName("FK__PhongBan__MaCong__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
