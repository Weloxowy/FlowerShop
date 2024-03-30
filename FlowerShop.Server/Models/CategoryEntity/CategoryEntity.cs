namespace FlowerShop.Server.Models.CategoryEntity
{
    public class CategoryEntity
    {
        public CategoryEntity() : base()
        { }

        public CategoryEntity(Guid id, string name, string urlName, string desc, string imageLink)
        {
            this.id = id;
            Name = name;
            URLName = urlName;
            Description = desc;
            ImageLink = imageLink;
        }

        virtual public Guid id { get; set; }
        public virtual string Name { get; set; }
        public virtual string URLName { get; set; }
        public virtual string Description { get; set; }
        public virtual string ImageLink { get; set; } 
    }
}
