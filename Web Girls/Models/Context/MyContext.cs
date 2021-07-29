namespace Web_Girls.Models.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyContext : DbContext
    {
        public MyContext()
            : base("name=MyContext1")
        {
        }

        public virtual DbSet<BCH_CD> BCH_CD { get; set; }
        public virtual DbSet<BCH_HPN> BCH_HPN { get; set; }
        public virtual DbSet<CapBac> CapBacs { get; set; }
        public virtual DbSet<CapLaiMatKhau> CapLaiMatKhaus { get; set; }
        public virtual DbSet<ChiBo> ChiBoes { get; set; }
        public virtual DbSet<ChucDanh> ChucDanhs { get; set; }
        public virtual DbSet<CongDoan> CongDoans { get; set; }
        public virtual DbSet<DangUy> DangUys { get; set; }
        public virtual DbSet<DanhHieu> DanhHieux { get; set; }
        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<HoanCanhGD> HoanCanhGDs { get; set; }
        public virtual DbSet<HoiPhuNu> HoiPhuNus { get; set; }
        public virtual DbSet<HoiVien> HoiViens { get; set; }
        public virtual DbSet<LaoDongSangTao> LaoDongSangTaos { get; set; }
        public virtual DbSet<LichSuCapBac> LichSuCapBacs { get; set; }
        public virtual DbSet<LichSuChucDanh> LichSuChucDanhs { get; set; }
        public virtual DbSet<LichSuDanhHieu> LichSuDanhHieux { get; set; }
        public virtual DbSet<LichSuTrinhDo> LichSuTrinhDoes { get; set; }
        public virtual DbSet<LoaiDangVien> LoaiDangViens { get; set; }
        public virtual DbSet<LoaiHoiVien> LoaiHoiViens { get; set; }
        public virtual DbSet<LoaiLDST> LoaiLDSTs { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ToChucDoanThe> ToChucDoanThes { get; set; }
        public virtual DbSet<TrinhDo> TrinhDoes { get; set; }
        public virtual DbSet<HoiVien_LDST> HoiVien_LDST { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BCH_CD>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<BCH_HPN>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<CapLaiMatKhau>()
                .Property(e => e.TenDN)
                .IsUnicode(false);

            modelBuilder.Entity<CapLaiMatKhau>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<HoanCanhGD>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<HoiVien>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<HoiVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<HoiVien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<LichSuCapBac>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<LichSuChucDanh>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<LichSuDanhHieu>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<LichSuTrinhDo>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenDN)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<HoiVien_LDST>()
                .Property(e => e.MaHV)
                .IsUnicode(false);
        }
    }
}
