using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using OnBoard.WebApp.Data;
using OnBoard.WebApp.Data.Tables;
using OnBoard.WebApp.Pages.Shared;

namespace OnBoard.WebApp.Pages.Apps
{
    public class IndexModel : BasePageModel
    {
        public readonly DataModelDbContext _dbContext;
        public readonly ApplicationDbContext _userContext;

        public IndexModel(DataModelDbContext dbContext, ApplicationDbContext userContext)
        {
            _dbContext = dbContext;
            _userContext = userContext;
        }

        public IQueryable<Application> GetApplications()
        {
            return _dbContext.Applications;
        }

        public Application GetApplication(int id)
        {
            return _dbContext.Applications.Where(x => x.ApplicationID == id).SingleOrDefault();
        }

        public Application App { get; set; }
        public ApplicationExtended AppUser { get; set; }
        public List<CommissionApplication> CommissionsAppliedTo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            App = await _dbContext.Applications.FindAsync(id);
            AppUser = _dbContext.ApplicationsExtended.Where(x => x.UserExtendedUserId == App.ApplicationUserID).FirstOrDefault();
            CommissionsAppliedTo = _dbContext.CommissionApplications.Where(x => x.ApplicationID == App.ApplicationID).ToList();

            return Page();
        }  
    }
}