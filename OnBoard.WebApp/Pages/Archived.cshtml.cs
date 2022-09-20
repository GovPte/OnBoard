using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using OnBoard.WebApp.Data;
using OnBoard.WebApp.Data.Services;
using OnBoard.WebApp.Data.Tables;
using OnBoard.WebApp.Pages.Shared;

namespace OnBoard.WebApp.Pages
{
    public class ArchivedModel : BasePageModel
    {
        public readonly IApplicationService _as;
        public readonly IUserService _us;
        public readonly ApplicationDbContext _um;

        public ArchivedModel(IApplicationService @as, IUserService us, ApplicationDbContext um)
        {
            _as = @as;
            _us = us;
            _um = um;
        }

        public List<Application> archivedApplications = new List<Application>();  

        public IActionResult OnGet()
        {
            if (IsAdminOrManager())
            {
                archivedApplications = _as.GetArchivedApplications();
                return Page();
            }
            else
                return RedirectToPage("/Index");
        }
    }
}
