namespace FlowerShop.Server.Models.OrderDetailsEntity
{
    public class OrderDetailsEntity
    {
        public OrderDetailsEntity () : base() { }

        public OrderDetailsEntity(Guid id, Guid order, Guid product, int qty, double unitPrice)
        {
            this.id = id;
            Order = order;
            Product = product;
            Qty = qty;
            UnitPrice = unitPrice;
        }

        virtual public Guid id { get; set; }
        public virtual Guid Order { get; set; }
        public virtual Guid Product { get; set; }
        public virtual int Qty { get; set; }
        public virtual double UnitPrice { get; set; }
    
    }
    
}
