using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.ViewComponents
{
    [ViewComponent(Name = "NavbarFooter")]
    public class NavbarFooterViewComponent : ViewComponent
    {
        private readonly DataContext _dataContext;
        public NavbarFooterViewComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

    
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _dataContext.Navbars.Include(n => n.SubNavbars.OrderBy(sn => sn.RowNumber)).Where(n => n.IsFooter).OrderBy(n => n.RowNumber).ToList();

            return View("~/Views/Shared/Components/NavbarFooter.cshtml", model);
        }
    }
}
