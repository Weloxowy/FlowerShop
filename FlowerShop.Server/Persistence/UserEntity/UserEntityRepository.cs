using FlowerShop.Server.Models.UserEntity;

namespace FlowerShop.Server.Persistence.User
{
    public class UserEntityRepository : IUserEntityRepository
    {
        //przenieść do PATCH/UPDATE
        public bool Edit(Guid id, string name, string surname, string password, bool isConfirmed, bool isBlocked, UserRank userRank)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var entity = session.Get<Models.UserEntity.AspNetUsers>(id);
                    if (entity == null)
                        return false;

                    entity.FirstName = name ?? entity.FirstName; //?? <- null-coalescing
                    entity.Surname = surname ?? entity.Surname;
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
