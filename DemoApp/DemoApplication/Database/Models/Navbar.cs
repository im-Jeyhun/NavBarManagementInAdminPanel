using DemoApplication.Database.Models.Common;

namespace DemoApplication.Database.Models
{
    public class Navbar : BaseNavbarAndSubNavbar
    {


        public bool IsMain { get; set; }

        public bool IsFooter { get; set; }

        public bool IsHeader { get; set; }

        public List<SubNavbar>? SubNavbars { get; set; }
    }
}
