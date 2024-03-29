namespace FlowerShop.Server.Models.OrderEntity
{
    public class OrderEntity
    {
        public OrderEntity() : base()
        { }

        public OrderEntity(Guid id, DateTime orderDate, double totalAmount, string additionalComment, string userId)
        {
            this.id = id;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            AdditionalComment = additionalComment;
            UserId = userId;
        }

        public virtual Guid id { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual double TotalAmount { get; set; }
        public virtual string AdditionalComment { get; set; }
        public virtual string UserId { get; set; }

        //public virtual string Delivery { get; set; } //l8



    }
}