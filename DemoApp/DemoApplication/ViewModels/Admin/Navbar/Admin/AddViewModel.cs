using DemoApplication.ViewModels.Admin.SubNavbar;

namespace DemoApplication.ViewModels.Admin.Navbar.Admin
{
    public class AddViewModel
    {
    
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }

        public int RowNumber { get; set; }
        public bool IsFooter { get; set; }

        public bool IsHeader { get; set; }

        //public AddViewModel( string name, string url, bool ısMain, int rowNumber, bool ısFooter, bool ısHeader)
        //{
        //    Name = name;
        //    Url = url;
        //    IsMain = ısMain;
        //    RowNumber = rowNumber;
        //    IsFooter = ısFooter;
        //    IsHeader = ısHeader;
        //}


    }
}
