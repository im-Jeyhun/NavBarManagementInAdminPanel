using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.ViewModels.Admin.Navbar.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Controllers.Admin
{
    public class NavbarController : Controller
    {
        private readonly DataContext _dataContext;
        public NavbarController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet("List", Name = "admin-navbar-list")]
        public async Task<IActionResult> ListAsync()
        {

            var model = await _dataContext.Navbars.
                Select(n => new ListItemViewModelForAP(n.Id, n.Name, n.Url, n.IsMain, n.RowNumber, n.IsFooter, n.IsHeader)).
                ToListAsync();

            return View("~/Views/Admin/Navbar/List.cshtml", model);
        }

        [HttpGet("add", Name = "admin-navbar-add")]
        public IActionResult Add()
        {

            return View("~/Views/Admin/Navbar/Add.cshtml");
        }

        [HttpPost("add", Name = "admin-navbar-add")]
        public async Task<IActionResult> Add(AddViewModel model)
        {
            if (!ModelState.IsValid) return View("~/Views/Admin/Navbar/Add.cshtml", model);

            var navbar = new Navbar
            {
                Name = model.Name,
                Url = model.Url,
                IsMain = model.IsMain,
                RowNumber = model.RowNumber,
                IsFooter = model.IsFooter,
                IsHeader = model.IsHeader
            };

            await _dataContext.Navbars.AddAsync(navbar);
            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-navbar-list");

        }

        [HttpGet("update/{id}", Name = "admin-navbar-update")]
        public async Task<IActionResult> UpdateAsync(int id)
        {

            var navbar = await _dataContext.Navbars.FirstOrDefaultAsync(n => n.Id == id);
            if (navbar is null) return NotFound();

            var navBar = new UpdateViewModel
            {
                Id = navbar.Id,
                Name = navbar.Name,
                Url = navbar.Url,
                RowNumber = navbar.RowNumber,
                IsMain = navbar.IsMain,
                IsHeader = navbar.IsHeader,
                IsFooter = navbar.IsFooter
            };

            return View("~/Views/Admin/Navbar/Update.cshtml", navBar);
        }

        [HttpPost("update/{id}", Name = "admin-navbar-update")]
        public async Task<IActionResult> UpdateAsync(UpdateViewModel model)
        {

            var navbar = await _dataContext.Navbars.FirstOrDefaultAsync(n => n.Id == model.Id);
            if (navbar is null) return NotFound();

            if(!ModelState.IsValid) return View("~/Views/Admin/Navbar/Upda.cshtml");

            navbar.Name = model.Name;
            navbar.Url = model.Url;
            navbar.RowNumber = model.RowNumber;
            navbar.IsMain = model.IsMain;
            navbar.IsHeader = model.IsHeader;
            navbar.IsFooter = model.IsFooter;

           await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-navbar-list");
        }

        [HttpPost("delete/{id}", Name = "admin-navbar-delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var navbar = await _dataContext.Navbars.FirstOrDefaultAsync(n => n.Id == id);
            if (navbar is null) return NotFound();

           

            _dataContext.Navbars.Remove(navbar);
            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-navbar-list");
        }
    }

}

