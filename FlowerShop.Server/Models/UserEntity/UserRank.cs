﻿namespace FlowerShop.Server.Models.UserEntity
{
    public enum UserRank
    {
        Visitor = 0, //Not confirmed user
        User = 1, //Confirmed user
        Worker = 2, 
        Admin = 3,
    }
}
