using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Lam_Demo.Models
{
    public class NhanVien : IdentityUser
    {
        // Cccd, họ tên, giới tính, địa chỉ, số điện thoại, lương cơ bản, lương theo giờ.
        [Required(ErrorMessage ="Vui lòng nhập căn cước công dân")]
        public string CanCuocCongDan { get; set; } = "";
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string? HoTen { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string? DiaChi { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        public string GioiTinh { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn ngày sinh")]
        public DateTime NgaySinh { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập lương cơ bản")]
        public double? LuongCoBan { get; set; } = 0;
        [Required(ErrorMessage = "Vui lòng nhập lương theo giờ")]
        public double? LuongTheoGio { get; set; } = 0;
    }
}
