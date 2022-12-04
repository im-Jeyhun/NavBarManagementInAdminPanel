using DemoApplication.ViewModels.Admin.Navbar.Client;

namespace DemoApplication.ViewModels.Admin.SubNavbar.Admin
{
    public class UpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Url { get; set; }

        public int RowNumber { get; set; }
        public int NavbarId { get; set; }
        public List<NavbarListItemViewModel>? Navbars { get; set; }

    }
}
