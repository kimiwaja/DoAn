using Microsoft.AspNetCore.Mvc;
using Web.Data;
using Web.ViewModels;

namespace Web.ViewComponents
{

    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly WebContext db;
        public MenuLoaiViewComponent(WebContext context) => db = context;

        public IViewComponentResult Invoke()
        {
            var data = db.Loais.Select(lo => new MenuLoaiVM
            {
                MaLoai = lo.MaLoai,
                TenLoai = lo.TenLoai,

            }).OrderBy(p => p.TenLoai);

            return View(data);
        }
    }
}

