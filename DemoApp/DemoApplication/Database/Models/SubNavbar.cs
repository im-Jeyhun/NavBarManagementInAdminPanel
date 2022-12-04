using DemoApplication.Database.Models.Common;

namespace DemoApplication.Database.Models
{
    public class SubNavbar : BaseNavbarAndSubNavbar
    {
       public Navbar? Navbar { get; set; }

        public int NavbarId { get; set; }
    }
}
