using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using OnBoard.WebApp.Data;
using OnBoard.WebApp.Data.Services;
using OnBoard.WebApp.Data.Tables;
using OnBoard.WebApp.Models;
using OnBoard.WebApp.Pages.Shared;

namespace OnBoard.WebApp.Pages.CommissionMembers
{
    public class EditModel : BasePageModel
    {
        private readonly ApplicationDbContext _users;
        private readonly DataModelDbContext _context;
        private readonly ICommissionService _commissionService;
        private readonly IUserService _userService;

        public EditModel(ApplicationDbContext users, DataModelDbContext context, 
            ICommissionService commissionService, IUserService userService)
        {
            _users = users;
            _context = context;
            _commissionService = commissionService;
            _userService = userService;
        }

        [TempData]
        public string Message { get; set; } = "";

        public List<Commission> Commissions { get; set; } = new List<Commission>();
        public List<AppUserModels> Applicants = new List<AppUserModels>();
        public AppUserModels Applicant = new AppUserModels();

        [BindProperty]
        public CommissionMember CommissionMember { get; set; }
        [BindProperty]
        public string ApplicantId { get; set; }
        [BindProperty]
        public int AspnetUserId { get; set; }

        public IActionResult OnGet(int id)
        {
            if (IsAdminOrManager())
            {
                //Get Commission Member...
                CommissionMember = _commissionService.GetCommissionMember(id);

                //Gather Commissions...
                Commissions = _commissionService.GetCommissions().ToList();
                ViewData["Commissions"] = new SelectList(Commissions.OrderBy(x => x.CommissionName), "CommissionID", "CommissionName", CommissionMember.CommissionID);

                //Get users...
                var applicationsExtended = _context.ApplicationsExtended.ToList();
                var usersFinal = _userService.GetUsersInfo().ToList();
                ViewData["Applicants"] = new SelectList(usersFinal.OrderBy(x => x.LastName).ThenBy(x => x.FirstName), "Id", "FullName");

                return Page();
            }
            else
                return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            //Get Commission Member...
            var member = _commissionService.GetCommissionMember(CommissionMember.CommissionMemberID);

            if (await TryUpdateModelAsync<CommissionMember>(
                member, 
                "CommissionMember",
                x => x.CommissionID, x => x.CommissionTitle, x => x.AspNetUserId, 
                x => x.StartDate, x => x.EndDate,
                x => x.TermStartDate, x => x.TermEndDate,
                x => x.CommissionMemberSlot, x => x.CommissionMemberSort, 
                x => x.CommissionMemberAppointmentNotes, x => x.CommissionMemberAppointmentMinutesLink, 
                x => x.CommissionMemberResignationRemovalNotes, x => x.CommissionMemberResignationRemovalMinutesLink, 
                x => x.CommissionID))
            {
                _context.CommissionMembers.Update(member);
                await _context.SaveChangesAsync();
                Message = "Appointment update!";
                return RedirectToPage("./List");
            }

            return Page();
        }
    }
}