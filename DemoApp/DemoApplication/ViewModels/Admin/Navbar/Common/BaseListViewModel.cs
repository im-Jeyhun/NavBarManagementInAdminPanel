using DemoApplication.Database.Models;

namespace DemoApplication.ViewModels.Admin.Navbar
{
    public abstract class BaseListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BaseListViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
