using Microsoft.AspNetCore.Mvc;
using Web.Data;
using Web.ViewModels;

namespace Web.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly WebContext db;
        public SanPhamController (WebContext context)
        {
            db = context;
        }
        public IActionResult Index( int? loai)
        {
            var sanPhams = db.SanPhams.AsQueryable();
            if (loai.HasValue)
            {
                sanPhams = sanPhams.Where(p => p.MaLoai == loai.Value);
            }
            var result = sanPhams.Select(p => new SanPhamVM
            {
                MaSP = p.MaHh,
                TenSP = p.TenHh,
                DonGia = p.DonGia ?? 0,
                Hinh = p.Hinh ?? "",
                MoTa = p.MoTa ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai
            });
            return View(result);
        }
        public IActionResult Search (string? query)
        {
            var sanPhams = db.SanPhams.AsQueryable();
            if (query != null)
            {
                sanPhams = sanPhams.Where(p => p.TenHh.Contains(query));
            }
            var result = sanPhams.Select(p => new SanPhamVM
            {
                MaSP = p.MaHh,
                TenSP = p.TenHh,
                DonGia = p.DonGia ?? 0,
                Hinh = p.Hinh ?? "",
                MoTa = p.MoTa ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai
            });
            return View(result);
        }
    }
}
