using DemoApplication.ViewModels.Admin.SubNavbar;

namespace DemoApplication.ViewModels.Admin.Navbar.Admin
{
    public class ListItemViewModelForAP : BaseListViewModel
    {
        public ListItemViewModelForAP(int id, string name,string url, bool ısMain, int rowNumber, bool ısFooter, bool ısHeader)
            : base(id ,name)
        {
            Url = url;
            IsMain = ısMain;
            RowNumber = rowNumber;
            IsFooter = ısFooter;
            IsHeader = ısHeader;
        }

        public string Url { get; set; }
        public bool IsMain { get; set; }

        public int RowNumber { get; set; }
        public bool IsFooter { get; set; }

        public bool IsHeader { get; set; }




    }
}
