using FlowerShop.Server.Models.ProductEntity;

namespace FlowerShop.Server.Persistence.ProductEntity
{
    public class ProductEntityService : IProductEntityService
    {
       public ProductEntityRepository productEntityRepository = new ProductEntityRepository();
        public List<Models.ProductEntity.ProductEntity> returnByCategoryId(string name)
        {
            return productEntityRepository.returnByCategoryId(name);
        }
    }
}
