namespace Make_Orders.Models
{
    public class Orders
    {
        public int OrdersID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Items> items { get; set; }

        public Orders()
        {
            items = new HashSet<Items>();
        }
    }
}
