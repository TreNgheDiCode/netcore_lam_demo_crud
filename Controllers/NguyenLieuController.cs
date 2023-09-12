using Lam_Demo.Data;
using Lam_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lam_Demo.Controllers
{
    public class NguyenLieuController : Controller
    {
        private readonly DataContext context;

        public NguyenLieuController(DataContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var nguyenLieus = await context.NguyenLieus.ToListAsync();
            return View("IndexNguyenLieu", nguyenLieus);
        }

        public IActionResult Create()
        {
            var nguyenLieu = new NguyenLieu();
            return View("CreateNguyenLieu", nguyenLieu);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NguyenLieu nguyenLieu)
        {
            if (ModelState.IsValid)
            {
                await context.AddAsync(nguyenLieu);

                var res = context.SaveChanges() > 0 ? true : false;

                if (res)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("CreateNguyenLieu", nguyenLieu);
                }
            }

            return View("CreateNguyenLieu", nguyenLieu);
        }

        public async Task<IActionResult> Update(int id)
        {
            var nguyenLieu = await context.NguyenLieus.FirstOrDefaultAsync(i => i.MaNguyenLieu == id);

            if (nguyenLieu == null) return View("Error");

            return View("UpdateNguyenLieu", nguyenLieu);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, NguyenLieu nguyenLieu)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return RedirectToAction("Update", nguyenLieu);

            }

            var existNguyenLieu = await context.NguyenLieus.AsNoTracking().FirstOrDefaultAsync(i => i.MaNguyenLieu == id);

            if (existNguyenLieu != null)
            {
                existNguyenLieu.TenNguyenLieu = nguyenLieu.TenNguyenLieu;
                existNguyenLieu.NgaySanXuat = nguyenLieu.NgaySanXuat;
                existNguyenLieu.NgayHetHan = nguyenLieu.NgayHetHan;
                existNguyenLieu.NgayNhap = nguyenLieu.NgayNhap;
                existNguyenLieu.SoLuongConLai = nguyenLieu.SoLuongConLai;
                existNguyenLieu.GiaNhap = nguyenLieu.GiaNhap;
                existNguyenLieu.Hang = nguyenLieu.Hang;

                context.Update(existNguyenLieu);
                var res = context.SaveChanges() > 0 ? true : false;

                if (res)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("UpdateNguyenLieu", nguyenLieu);
                }
            }

            return View("UpdateNguyenLieu", nguyenLieu);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var nguyenLieu = await context.NguyenLieus.FirstOrDefaultAsync(i => i.MaNguyenLieu == id);
            if (nguyenLieu == null) return View("Error");
            return View("DeleteNguyenLieu", nguyenLieu);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteNguyenLieu(int id)
        {
            var nguyenLieu = await context.NguyenLieus.FirstOrDefaultAsync(i => i.MaNguyenLieu == id);
            if (nguyenLieu == null) return View("Error");

            context.Remove(nguyenLieu);
            var res = context.SaveChanges() > 0 ? true : false;

            if (res)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("DeleteNguyenLieu", nguyenLieu);
            }
        }
    }
}
