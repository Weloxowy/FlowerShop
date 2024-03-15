﻿using FluentNHibernate.Mapping;

namespace FlowerShop.Server.Models.UserEntity
{
    public class UserEntityMapping : ClassMap<UserEntity>
    {
        readonly string tablename = nameof(UserEntity);
        public UserEntityMapping() 
        {
            Id(x => x.id).GeneratedBy.Guid();
            Map(x => x.Name);
            Map(x => x.Surname);
            Map(x => x.TelephoneNumber);
            Map(x => x.EmailAddress);
            Map(x => x.Login);
            Map(x => x.Password);
            Map(x => x.IsUserProfileConfirmed);
            Map(x => x.IsUserProfileBlocked);
            Map(x => x.UserRank).CustomType<UserRank>();
            //Map(x => x.Address);
            //Map(x => x.Payment);
            //Map(x => x.Company);
            Table(tablename);
        }
    }
}