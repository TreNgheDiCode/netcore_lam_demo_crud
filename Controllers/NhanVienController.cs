using Lam_Demo.Data;
using Lam_Demo.Models;
using Lam_Demo.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lam_Demo.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly DataContext context;

        public NhanVienController(DataContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var nhanViens = await context.NhanViens.ToListAsync();
            return View("IndexNhanVien", nhanViens);
        }

        public IActionResult Create()
        {
            var nhanVien = new NhanVien();
            return View("CreateNhanVien", nhanVien);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                await context.AddAsync(nhanVien);

                var res = context.SaveChanges() > 0 ? true : false;

                if (res)
                {
                    return RedirectToAction("Index");
                } else
                {
                    return View("CreateNhanVien",nhanVien);
                }
            }

            return View("CreateNhanVien", nhanVien);
        }

        public async Task<IActionResult> Update(string id)
        {
            var nhanVien = await context.NhanViens.FirstOrDefaultAsync(i => i.Id == id);

            if (nhanVien == null) return View("Error");

            var nhanVienVM = new UpdateNhanVienViewModel
            {
                CanCuocCongDan = nhanVien.CanCuocCongDan,
                HoTen = nhanVien.HoTen,
                DiaChi = nhanVien.DiaChi,
                GioiTinh = nhanVien.GioiTinh,
                NgaySinh = nhanVien.NgaySinh,
                PhoneNumber = nhanVien.PhoneNumber,
                LuongCoBan = nhanVien.LuongCoBan,
                LuongTheoGio = nhanVien.LuongTheoGio
            };

            return View("UpdateNhanVien", nhanVienVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, UpdateNhanVienViewModel nhanVienVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return RedirectToAction("Update", nhanVienVM);

            }

            var existNhanVien = await context.NhanViens.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);

            if (existNhanVien != null)
            {
                existNhanVien.CanCuocCongDan = nhanVienVM.CanCuocCongDan;
                existNhanVien.HoTen = nhanVienVM.HoTen;
                existNhanVien.DiaChi = nhanVienVM.DiaChi;
                existNhanVien.GioiTinh = nhanVienVM.GioiTinh;
                existNhanVien.NgaySinh = nhanVienVM.NgaySinh;
                existNhanVien.PhoneNumber = nhanVienVM.PhoneNumber;
                existNhanVien.LuongCoBan = nhanVienVM.LuongCoBan;
                existNhanVien.LuongTheoGio = nhanVienVM.LuongTheoGio;

                context.Update(existNhanVien);
                var res = context.SaveChanges() > 0 ? true : false;

                if (res)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("UpdateNhanVien", nhanVienVM);
                }
            }

            return View("UpdateNhanVien", nhanVienVM);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var nhanVien = await context.NhanViens.FirstOrDefaultAsync(i => i.Id == id);
            if (nhanVien == null) return View("Error");
            return View("DeleteNhanVien", nhanVien);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteNhanVien(string id)
        {
            var nhanVien = await context.NhanViens.FirstOrDefaultAsync(i => i.Id == id);
            if (nhanVien == null) return View("Error");

            context.Remove(nhanVien);
            var res = context.SaveChanges() > 0 ? true : false;

            if (res)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("DeleteNhanVien", nhanVien);
            }
        }
    }
}
