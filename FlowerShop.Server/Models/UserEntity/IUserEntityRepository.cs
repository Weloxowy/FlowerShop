namespace FlowerShop.Server.Models.UserEntity
{
    public interface IUserEntityRepository
    {
        public bool Edit(Guid id, string name, string surname, string password, bool isConfirmed, bool isBlocked, UserRank userRank);
    }
}
