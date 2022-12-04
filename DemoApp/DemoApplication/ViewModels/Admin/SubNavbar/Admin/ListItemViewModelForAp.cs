namespace DemoApplication.ViewModels.Admin.SubNavbar.Admin
{
    public class ListItemViewModelForAp 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int RowNumber { get; set; }
        public string Navbar { get; set; }

        public ListItemViewModelForAp(int id, string name, string url, int rowNumber, string navbar)
        {
            Id = id;
            Name = name;
            Url = url;
            RowNumber = rowNumber;
            Navbar = navbar;
        }
    }
}
