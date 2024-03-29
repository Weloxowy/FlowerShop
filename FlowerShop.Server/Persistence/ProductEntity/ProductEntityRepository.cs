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
    }
}
