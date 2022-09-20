using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using OnBoard.WebApp.Data;
using OnBoard.WebApp.Data.Services;
using OnBoard.WebApp.Data.Tables;
using OnBoard.WebApp.Models;

namespace OnBoard.WebApp.Pages.CommissionMembers
{
    public class AddModel : PageModel
    {
        private readonly ApplicationDbContext _users;
        private readonly DataModelDbContext _context;
        private readonly IUserService _userService;

        public AddModel(ApplicationDbContext users, DataModelDbContext context, IUserService userService)
        {
            _users = users;
            _context = context;
            _userService = userService;
        }

        [TempData]
        public string Message { get; set; } = "";

        public string UserID { get; set; }

        public List<Commission> Commissions { get; set; } = new List<Commission>();

        public List<AppUserModels> Applicants = new List<AppUserModels>();
        public AppUserModels Applicant = new AppUserModels();

        [BindProperty]
        public CommissionMember CommissionMember { get; set; }
        [BindProperty]
        public string ApplicantId { get; set; }

        public IActionResult OnGet(string userID, int commissionID)
        {
            if (User.IsInRole("Administrator") || User.IsInRole("Manager"))
            {
                //Gather Commissions...
                Commissions = _context.Commissions.ToList();
                ViewData["Commissions"] = new SelectList(Commissions.OrderBy(x => x.CommissionName), "CommissionID", "CommissionName", commissionID);

                //Gather Applicants...
                //Applicants = _context.UserExtended.OrderBy(x => x.UserExtendedNameLast).ThenBy(x => x.UserExtendedNameFirst).ToList();
                //Applicants = _users.Users.OrderBy(x => x.UserName).ToList();
                //ViewData["Applicants"] = new SelectList(Applicants, "UserName", "UserName");

                var aspnetUsers = _users.Users.ToList();
                var applicationsExtended = _context.ApplicationsExtended.ToList();
                //var usersFinal = aspnetUsers.Join(applicationsExtended, aspnetUser => aspnetUser.Id.ToString(), ue => ue.UserExtendedUserId.ToString(), 
                //    (aspnetUser, ue) => new { aspnetUser.Id, ue.UserExtendedFullName, ue.UserExtendedNameLast, ue.UserExtendedNameFirst })
                //    .OrderBy(x => x.UserExtendedNameLast).ThenBy(x => x.UserExtendedNameFirst).Distinct().ToList();
                var usersFinal = _userService.GetUsersInfo();
                ViewData["Applicants"] = new SelectList(usersFinal.OrderBy(x => x.LastName).ThenBy(x => x.FirstName), "Id", "FullName");

                /*
                    --Get all distinct ASP.NET User IDs, but only JOIN it with the latest username/first/last
                    SELECT au.id, au.username, (SELECT TOP 1 userextendednamefirst FROM UserExtended WHERE UserExtendedUserId = au.id ORDER BY userextendedid DESC) FirstName,
	                    (SELECT TOP 1 userextendednamelast FROM UserExtended WHERE UserExtendedUserId = au.id ORDER BY userextendedid DESC) LastName
                    FROM aspnetusers au 
                    ORDER BY (SELECT TOP 1 userextendednamelast FROM UserExtended WHERE UserExtendedUserId = au.id ORDER BY userextendedid DESC), 
	                    (SELECT TOP 1 userextendednamefirst FROM UserExtended WHERE UserExtendedUserId = au.id ORDER BY userextendedid DESC)

                    --Get all ASP.NET Users
                    SELECT COUNT(*) FROM aspnetusers --126

                    --Should user the aspnetUser.Id, not UserExtendedId in this table a user/person/human is appointed to a board, not an application
                    SELECT * FROM commissionmembers
                */

                UserID = userID;

                return Page();
            }
            else
                return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            CommissionMember.AspNetUserId = ApplicantId; //TODO: Need to change this to AspNetUser.Id

            if (await TryUpdateModelAsync<CommissionMember>(
                CommissionMember, 
                "CommissionMember",
                x => x.CommissionID, x => x.CommissionTitle, x => x.AspNetUserId, x => x.StartDate, x => x.EndDate))
            {
                _context.CommissionMembers.Add(CommissionMember);
                await _context.SaveChangesAsync();
                Message = "Appointment made!";
                return RedirectToPage("./Add");
            }

            return Page();
        }
    }
}