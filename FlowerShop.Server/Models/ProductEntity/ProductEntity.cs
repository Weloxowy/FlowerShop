namespace FlowerShop.Server.Models.ProductEntity
{
    public class ProductEntity
    {
        ProductEntity() :base()
        { }

        ProductEntity(Guid id, string name, string description, double price, Unit unit, bool isAvaible, int stockQuantity, string[] imageUrl, Guid category)
        {
            this.id = id;
            Name = name;
            Description = description;
            Price = price;
            Unit = unit;
            StockQuantity = stockQuantity;
            IsAvaible = isAvaible;
            ImageUrl = imageUrl;
            Category = category;

        }

        public virtual Guid id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual double Price { get; set; } 
        public virtual Unit Unit { get; set; } //jednostka miary
        public virtual int StockQuantity { get; set; }
        public virtual bool IsAvaible { get; set; }
        public virtual string[] ImageUrl { get; set; } // URLe obrazkow produktu; przyjmijmy ze link o id 0 to obrazek główny
        public virtual Guid Category { get; set; } // Kategoria produktu (klucz obcy)
    }
}
