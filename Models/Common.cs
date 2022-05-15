namespace Make_Orders.Models
{
    public class Common
    {
        public ICollection<Orders> order { get; set; }
        public ICollection<Items> item { get; set; }

        public Common()
        {
            order = new HashSet<Orders>();
            item = new HashSet<Items>();
        }

    }
}
