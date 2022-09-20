using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using OnBoard.WebApp.Data.Services;
using OnBoard.WebApp.Data.Tables;
using OnBoard.WebApp.Models;
using OnBoard.WebApp.Pages.Shared;

namespace OnBoard.WebApp.Pages.CommissionApplications
{
    public class IndexModel : BasePageModel
    {
        public readonly IUserService _users;
        public readonly IApplicationService _ar;
        private readonly ICommissionService _commissionRepository;

        public IndexModel(IUserService users, IApplicationService ar, ICommissionService commissionRepository)
        {
            _users = users;
            _ar = ar;
            _commissionRepository = commissionRepository;
        }

        public List<Application> Applications { get; set; } = new List<Application>();
        public Commission Commission { get; set; } = null;
        public List<AppUserModels> Users { get; set; } = new List<AppUserModels>();
        public List<ApplicationExtended> UsersExtended { get; set; } = new List<ApplicationExtended>();

        public IActionResult OnGet(int? id)
        {
            Applications = _commissionRepository.GetCommissionApplications(id);
            if (id.HasValue) //If we are showing applicants for one board only
                Commission = _commissionRepository.GetCommissions().Where(x => x.CommissionID == id.Value).SingleOrDefault();
            Users = _users.GetUsers().ToList();
            UsersExtended = _users.GetUsersExtended().ToList();

            return Page();
        }
    }
}
