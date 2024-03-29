namespace FlowerShop.Server.Models.ProductEntity
{
    public interface IProductEntityRepository
    {
        string[] RepackImg(string input);
        string PackImg(string[] input);
    }
}
