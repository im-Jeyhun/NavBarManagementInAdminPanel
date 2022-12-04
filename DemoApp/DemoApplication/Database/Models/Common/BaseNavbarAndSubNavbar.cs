namespace DemoApplication.Database.Models.Common
{
    public abstract class BaseNavbarAndSubNavbar
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int RowNumber { get; set; }
    }
}
