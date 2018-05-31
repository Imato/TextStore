
namespace TextStore.Model
{
    public class DbItem
    {
        public int Id { get; set; }
        public bool IsVisible { get; set; }

        public DbItem()
        {
            IsVisible = true;
        }
    }
}
