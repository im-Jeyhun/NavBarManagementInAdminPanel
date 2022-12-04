using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.ViewComponents
{
    [ViewComponent(Name = "Navbar")]
    public class NavbarHeaderViewComponent : ViewComponent
    {
        private readonly DataContext _dataContext;
        public NavbarHeaderViewComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _dataContext.Navbars.Include(n => n.SubNavbars.OrderBy(sn => sn.RowNumber)).Where(n => n.IsHeader).OrderBy(n => n.RowNumber).ToList();

            return View("~/Views/Shared/Components/Navbar.cshtml" , model);
        }

        //public async Task<IViewComponentResult> Invoke2Async()
        //{
        //    var model = _dataContext.Navbars.Include(n => n.SubNavbars.OrderBy(sn => sn.RowNumber)).Where(n => n.IsFooter).OrderBy(n => n.RowNumber).ToList();

        //    return View("~/Views/Shared/Components/NavbarFooter.cshtml", model);
        //}
    }
}
