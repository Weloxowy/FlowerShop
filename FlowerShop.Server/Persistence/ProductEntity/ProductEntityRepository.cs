using FlowerShop.Server.Models.ProductEntity;

namespace FlowerShop.Server.Persistence.ProductEntity
{
    public class ProductEntityRepository : IProductEntityRepository
    {
        public string PackImg(string[] input)
        {
            string output = "";
            foreach(var item in input)
            {
                output += item;
                output += ",";
            }
            return output;
        }

        public string[] RepackImg(string input)
        {
                string[] imageUrls = input.Split(',');
                return imageUrls;
            
        }
        public List<Models.ProductEntity.ProductEntity> returnByCategoryId(string name)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var query = session.Query<Models.CategoryEntity.CategoryEntity>().Where(x => x.Name == name).ToList();
                if (query.Count > 1)
                {
                    throw new Exception("There are many category with same name");
                }
                else if (query.Count == 0)
                {
                    throw new Exception("No category with this name");
                }
                var id = query[0].id; //Zapisujemy id z Categori ktora ma taka sama nazwe
                var query2 = session.Query<Models.ProductEntity.ProductEntity>().Where(x => x.Category == id).ToList();
                return query2;

            }
        }
    }
}
