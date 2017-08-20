﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.DataServices.Interfaces
{
    public interface IAuthenticationService
    {

        bool isAuthenticated { get; }

        Task<bool> LoginAsync();

        Task LogoutAsync();

        int GetCurrentUserId();
    }
}
