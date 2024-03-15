using FlowerShop.Server.Models.UserEntity;

namespace FlowerShop.Server.Persistence.User
{
    public class UserEntityRepository : IUserEntityRepository
    {
        public bool Edit(Guid id, string name, string surname, string telephone, string email, string login, string password, bool isConfirmed, bool isBlocked, UserRank userRank)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var entity = session.Get<Models.UserEntity.UserEntity>(id);
                    if (entity == null)
                        return false;

                    entity.Name = name ?? entity.Name; //?? <- null-coalescing
                    entity.Surname = surname ?? entity.Surname;
                    entity.TelephoneNumber = telephone ?? entity.TelephoneNumber;
                    entity.EmailAddress = email ?? entity.EmailAddress;
                    entity.Login = login ?? entity.Login;
                    entity.Password = password ?? entity.Password;
                    entity.IsUserProfileBlocked = isBlocked;
                    entity.IsUserProfileConfirmed = isConfirmed;
                    entity.UserRank = userRank;

                    session.SaveOrUpdate(entity);
                    transaction.Commit();
                }
            }
        return true;
        }

    }
}
