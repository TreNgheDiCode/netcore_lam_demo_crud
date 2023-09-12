using System.ComponentModel.DataAnnotations;

namespace Lam_Demo.Models
{
    public class NguyenLieu
    {
        // Mã nguyên liệu, tên nguyên liệu, ngày sản xuất, ngày hết hạn, ngày nhập, giá nhập, hãng, số lượng còn lại.
        [Key]
        public int MaNguyenLieu { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên nguyên liệu")]
        public string? TenNguyenLieu { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày sản xuất")]
        public DateTime? NgaySanXuat { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày hết hạn")]
        public DateTime? NgayHetHan { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày nhập")]
        public DateTime? NgayNhap { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số lượng còn lại")]
        public int? SoLuongConLai { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá nhập")]
        public double? GiaNhap { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập hãng")]
        public string? Hang { get; set; }
    }
}
