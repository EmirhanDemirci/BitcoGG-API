﻿using System;
using System.Collections.Generic;
using System.Text;
using BitcoGG_API.Models;

namespace BitcoGG_API.Services.Interfaces
{
    public interface IUserService
    {
        void Create(User user);
        JwtUser Authenticate(string username, string password);
        User Get(int id);
    }
}