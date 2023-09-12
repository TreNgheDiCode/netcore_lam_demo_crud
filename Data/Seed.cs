using Lam_Demo.Models;

namespace Lam_Demo.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();

                context?.Database.EnsureCreated();

                if (!context.NhanViens.Any())
                {
                    context.NhanViens.AddRange(new List<NhanVien>()
                    {
                        new NhanVien()
                        {
                            CanCuocCongDan="0123456789",
                            HoTen="Phùng Quang Long",
                            GioiTinh="Nam",
                            DiaChi="Quận 10, Tp. HCM",
                            PhoneNumber="0123456789",
                            LuongCoBan=100000,
                            LuongTheoGio=100000
                        },
                        new NhanVien()
                        {
                            CanCuocCongDan="0123456789",
                            HoTen="Trần Hoàng Ngọc Lam",
                            GioiTinh="Nữ",
                            DiaChi="Quận 10, Tp. HCM",
                            PhoneNumber="0123456789",
                            LuongCoBan=100000,
                            LuongTheoGio=100000
                        },
                    });
                }

                if (!context.NguyenLieus.Any())
                {
                    context.NguyenLieus.AddRange(new List<NguyenLieu>()
                    {
                        new NguyenLieu()
                        {
                            TenNguyenLieu="Sản phẩm A",
                            NgaySanXuat= new DateTime(2023, 9, 10, 22, 0, 0, DateTimeKind.Utc),
                            NgayHetHan = new DateTime(2023, 9, 12, 22, 0, 0, DateTimeKind.Utc),
                            NgayNhap = new DateTime(2023, 9, 11, 22, 0, 0, DateTimeKind.Utc),
                            SoLuongConLai=10
                        },
                        new NguyenLieu()
                        {
                            TenNguyenLieu="Sản phẩm B",
                            NgaySanXuat= new DateTime(2023, 9, 10, 22, 0, 0, DateTimeKind.Utc),
                            NgayHetHan = new DateTime(2023, 9, 12, 22, 0, 0, DateTimeKind.Utc),
                            NgayNhap = new DateTime(2023, 9, 11, 22, 0, 0, DateTimeKind.Utc),
                            SoLuongConLai=5
                        }
                    });;
                }

                context.SaveChanges();
            }
        }
    }
}
