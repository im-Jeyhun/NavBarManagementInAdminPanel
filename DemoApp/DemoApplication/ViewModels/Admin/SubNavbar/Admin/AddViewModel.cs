using DemoApplication.ViewModels.Admin.Navbar.Client;

namespace DemoApplication.ViewModels.Admin.SubNavbar.Admin
{
    public class AddViewModel
    {
     
        public string Name { get; set; }

        public string Url { get; set; }

        public int RowNumber { get; set; }
        public int NavbarId { get; set; }
        public List<NavbarListViewModelFC>? Navbars { get; set; }

     




    }
}
