using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop_Apple_HNT.Models;
using Shop_Apple_HNT.Repository;

namespace Shop_Apple_HNT.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SanPhamController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SanPhamController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.SanPhams
                .OrderByDescending(p => p.Id)
                .Include(p => p.Brand)
                .Include(p => p.DanhMuc)
                .ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DanhMucs = new SelectList(_dataContext.DanhMucs, "ID", "Ten");
            ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Ten");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SanPhamModel sanpham)
        {
            ViewBag.DanhMucs = new SelectList(_dataContext.DanhMucs, "ID", "Ten", sanpham.DanhMucId);
            ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Ten", sanpham.BrandId);

            if (ModelState.IsValid)
            {
                sanpham.Slug = sanpham.Ten.Replace(" ", "-");

                var slug = await _dataContext.SanPhams.FirstOrDefaultAsync(p => p.Slug == sanpham.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Sản phẩm đã tồn tại");
                    return View(sanpham);
                }

                if (sanpham.TaiHinh != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/products");

                    if (!Directory.Exists(uploadDir))
                        Directory.CreateDirectory(uploadDir);

                    string hinhTen = Guid.NewGuid() + "_" + sanpham.TaiHinh.FileName;
                    string filePath = Path.Combine(uploadDir, hinhTen);

                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        await sanpham.TaiHinh.CopyToAsync(fs);
                    }

                    sanpham.Hinh = hinhTen;
                }
                else
                {
                    sanpham.Hinh = "no-image.png";
                }

                _dataContext.Add(sanpham);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Thêm sản phẩm thành công";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Model đang bị lỗi";
            return View(sanpham);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var sanpham = await _dataContext.SanPhams.FindAsync(id);

            ViewBag.DanhMucs = new SelectList(_dataContext.DanhMucs, "ID", "Ten", sanpham.DanhMucId);
            ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Ten", sanpham.BrandId);

            return View(sanpham);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SanPhamModel sanpham)
        {
            ViewBag.DanhMucs = new SelectList(_dataContext.DanhMucs, "ID", "Ten", sanpham.DanhMucId);
            ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Ten", sanpham.BrandId);

            if (ModelState.IsValid)
            {
                sanpham.Slug = sanpham.Ten.Replace(" ", "-");

                if (sanpham.TaiHinh != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/products");

                    if (!Directory.Exists(uploadDir))
                        Directory.CreateDirectory(uploadDir);

                    string hinhTen = Guid.NewGuid() + "_" + sanpham.TaiHinh.FileName;
                    string filePath = Path.Combine(uploadDir, hinhTen);

                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        await sanpham.TaiHinh.CopyToAsync(fs);
                    }

                    sanpham.Hinh = hinhTen;
                }

                _dataContext.Update(sanpham);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Cập nhật sản phẩm thành công";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Model đang bị lỗi";
            return View(sanpham);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var sanpham = await _dataContext.SanPhams.FindAsync(id);

            if (sanpham == null) return NotFound();

            if (!string.IsNullOrEmpty(sanpham.Hinh) && sanpham.Hinh != "no-image.png")
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/products");
                string fileOld = Path.Combine(uploadDir, sanpham.Hinh);

                if (System.IO.File.Exists(fileOld))
                    System.IO.File.Delete(fileOld);
            }

            _dataContext.SanPhams.Remove(sanpham);
            await _dataContext.SaveChangesAsync();

            TempData["success"] = "Xóa sản phẩm thành công";
            return RedirectToAction("Index");
        }
    }
}
