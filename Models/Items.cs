namespace Make_Orders.Models
{
    public class Items
    {

        public int ItemsID { get; set; }

        public string ItemsName { get; set; }

        public string Item_type { get; set; }
        public decimal Rate { get; set; }

        public int OrdersID { get; set; }

        public virtual Orders order { get; set; }

    }
}
