namespace DemoApplication.ViewModels.Admin.Author
{
    public class BaseListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public BaseListViewModel(int id, string name, string lastName)
        {
            Id = id;
            Name = name;
            LastName = lastName;
        }
    }
}
