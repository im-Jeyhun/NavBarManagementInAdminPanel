using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.ViewModels.Admin.Navbar.Client;
using DemoApplication.ViewModels.Admin.SubNavbar.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Controllers.Admin
{
    [Route("admin/subnavbar")]
    public class SubNavbarController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly DataContext _dataContext;
        public SubNavbarController(DataContext dataContext, ILogger<BookController> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        [HttpGet("list", Name = "admin-subnavbar-list")]
        public async Task<IActionResult> List()
        {
            var subnavbar = await _dataContext.SubNavbars
                .Select(sn => new ListItemViewModelForAp(sn.Id, sn.Name, sn.Url, sn.RowNumber, $"{sn.Navbar.Name}"))
                .ToListAsync();

            return View("~/Views/Admin/SubNavbar/List.cshtml", subnavbar);
        }

        [HttpGet("add", Name = "admin-subnavbar-add")]
        public async Task<IActionResult> AddAsync()
        {
            var model = new AddViewModel
            {
                Navbars = await _dataContext.Navbars.Select(sn => new NavbarListViewModelFC(sn.Id, sn.Name)).
                ToListAsync()
            };

            return View("~/Views/Admin/SubNavbar/Add.cshtml", model);
        }

        [HttpPost("add", Name = "admin-subnavbar-add")]
        public async Task<IActionResult> AddAsync(AddViewModel model)
        {
            if (!ModelState.IsValid) { 
               await GetView(model); 
            }

            if (!_dataContext.Navbars.Any(n => n.Id == model.NavbarId))
            {
                ModelState.AddModelError(String.Empty, "Something went wrong");
                _logger.LogWarning($"Navbar with id({model.NavbarId}) not found in db ");
                await GetView(model);
            } ;

           await AddSubNavbar();

            return RedirectToRoute("admin-subnavbar-list");


            async Task<IActionResult> GetView(AddViewModel model)
            {
                model.Navbars = await _dataContext.Navbars
                     .Select(sn => new NavbarListViewModelFC(sn.Id, sn.Name))
                     .ToListAsync();

                return View("~/Views/Admin/SubNavbar/Add.cshtml", model);
            }

            async Task AddSubNavbar()
            {
                var subnavbar = new SubNavbar
                {
                    Name = model.Name,
                    Url = model.Url,
                    RowNumber = model.RowNumber,
                    NavbarId = model.NavbarId
                };

                await _dataContext.SubNavbars.AddAsync(subnavbar);

                 _dataContext.SaveChanges();

            }
        }

        [HttpGet("update/{id}", Name = "admin-subnavbar-update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id)
        {
            var subnavbar = await _dataContext.SubNavbars.FirstOrDefaultAsync(sn => sn.Id == id);

            if (subnavbar is null) return NotFound();

            var model = new UpdateViewModel
            {
                Id = subnavbar.Id,
                Name = subnavbar.Name,
                Url = subnavbar.Url,
                RowNumber = subnavbar.RowNumber,
                Navbars = _dataContext.Navbars.Select(n => new NavbarListItemViewModel(n.Id, n.Name)).ToList()
               
            };

            return View("~/Views/Admin/SubNavbar/Update.cshtml", model);
        }

        [HttpPost("update/{id}", Name = "admin-subnavbar-update")]
        public async Task<IActionResult> UpdateAsync( UpdateViewModel model) 
        {
            var subnavbar = await _dataContext.SubNavbars.FirstOrDefaultAsync(sn => sn.Id == model.Id);

            if (!ModelState.IsValid) await GetView();

            if (!_dataContext.Navbars.Any(n => n.Id == model.NavbarId))
            {
                ModelState.AddModelError(String.Empty, "Something went wrong");
                _logger.LogWarning($"Navbar with id({model.NavbarId}) not found in db ");
                await GetView();
            }

            await UpdateSubNavbar();

            return RedirectToRoute("admin-subnavbar-list");

            async Task UpdateSubNavbar ()
            {
                subnavbar.Name = model.Name;
                subnavbar.Url = model.Name;
                subnavbar.RowNumber = model.RowNumber;
                subnavbar.NavbarId = model.NavbarId;

               await _dataContext.SaveChangesAsync();
            }

            async Task<IActionResult> GetView()
            {
                model.Navbars = await _dataContext.Navbars
                     .Select(sn => new NavbarListItemViewModel(sn.Id, sn.Name))
                     .ToListAsync();
                

                return View("~/Views/Admin/SubNavbar/Update.cshtml", model);
            }

        }
        [HttpPost("delete/{id}", Name = "admin-subnavbar-delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var navbar = await _dataContext.SubNavbars.FirstOrDefaultAsync(n => n.Id == id);
            if (navbar is null) return NotFound();



            _dataContext.SubNavbars.Remove(navbar);
            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-navbar-list");
        }
    }
}
