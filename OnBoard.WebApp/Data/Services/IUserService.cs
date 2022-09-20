using System;
using System.Collections.Generic;

using OnBoard.WebApp.Data.Tables;
using OnBoard.WebApp.Models;

namespace OnBoard.WebApp.Data.Services
{
    public interface IUserService
    {
        IEnumerable<AppUserModels> GetUsers();
        IEnumerable<AppUserModelExtended> GetUsersInfo();
        IEnumerable<ApplicationExtended> GetUsersExtended();
        ApplicationExtended GetUserExtended(string userExtendedUserId);
        Tuple<AppUserModels, ApplicationExtended> GetUser(string id);
    }
}