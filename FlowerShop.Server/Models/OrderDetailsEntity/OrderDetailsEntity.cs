namespace FlowerShop.Server.Models.OrderDetailsEntity
{
    public class OrderDetailsEntity
    {
        public OrderDetailsEntity () : base() { }

        public OrderDetailsEntity(Guid id, Guid orderId, Guid productId, int qty, double unitPrice)
        {
            this.id = id;
            OrderId = orderId;
            ProductId = productId;
            Qty = qty;
            UnitPrice = unitPrice;
        }

        virtual public Guid id { get; set; }
        public virtual Guid OrderId { get; set; }
        public virtual Guid ProductId { get; set; }
        public virtual int Qty { get; set; }
        public virtual double UnitPrice { get; set; }
    
    }
    
}
