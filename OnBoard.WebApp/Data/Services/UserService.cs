using System;
using System.Collections.Generic;
using System.Linq;

using OnBoard.WebApp.Data.Tables;
using OnBoard.WebApp.Models;

namespace OnBoard.WebApp.Data.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseService<ApplicationExtended> _applicationsExtendedService;
        private readonly ApplicationDbContext _users;

        public UserService(IBaseService<ApplicationExtended> applicationsExtendedService, ApplicationDbContext users)
        {
            _applicationsExtendedService = applicationsExtendedService;
            _users = users;
        }

        public IEnumerable<AppUserModels> GetUsers()
        {
            return _users.Users;
        }

        public IEnumerable<AppUserModelExtended> GetUsersInfo()
        {
            var allUsers = new List<AppUserModelExtended>();
            var applicationsExtended = _applicationsExtendedService.All().ToList();

            foreach (var u in GetUsers())
            {
                allUsers.Add(new AppUserModelExtended
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName = applicationsExtended.Where(y => y.UserExtendedUserId == u.Id).OrderByDescending(z => z.UserExtendedID).FirstOrDefault()?.UserExtendedNameFirst,
                    LastName = applicationsExtended.Where(y => y.UserExtendedUserId == u.Id).OrderByDescending(z => z.UserExtendedID).FirstOrDefault()?.UserExtendedNameLast,
                    FullName = applicationsExtended.Where(y => y.UserExtendedUserId == u.Id).OrderByDescending(z => z.UserExtendedID).FirstOrDefault()?.UserExtendedFullName
                });
            }
            return allUsers.AsEnumerable();
        }

        public IEnumerable<ApplicationExtended> GetUsersExtended()
        {
            return _applicationsExtendedService.All();
        }

        public ApplicationExtended GetUserExtended(string userExtendedUserId)
        {
            return _applicationsExtendedService.FindBy(x => x.UserExtendedUserId == userExtendedUserId).SingleOrDefault();
        }

        public Tuple<AppUserModels, ApplicationExtended> GetUser(string id)
        {
            var u = _users.Users.Where(x => x.Id == id).FirstOrDefault();
            var ue = _applicationsExtendedService.FindBy(x => x.UserExtendedUserId == id).FirstOrDefault();

            return new Tuple<AppUserModels, ApplicationExtended>(u, ue);
        }
    }

    public class AppUserModelExtended : AppUserModels
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
    }
}