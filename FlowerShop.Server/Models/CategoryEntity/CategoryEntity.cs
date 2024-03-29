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
            Desc = desc;
            ImageLink = imageLink;
        }

        virtual public Guid id { get; set; }
        public virtual string Name { get; set; }
        public virtual string URLName { get; set; }
        public virtual string Desc { get; set; }
        public virtual string ImageLink { get; set; } 
    }
}
