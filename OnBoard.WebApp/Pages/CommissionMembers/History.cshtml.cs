using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

using OnBoard.WebApp.Data;
using OnBoard.WebApp.Data.Services;
using OnBoard.WebApp.Data.Tables;

namespace OnBoard.WebApp.Pages.CommissionMembers
{
    public class HistoryModel : PageModel
    {
        public readonly ICommissionService _cr;
        public readonly IUserService _userService;

        public HistoryModel(ICommissionService cr, IUserService userService)
        {
            _cr = cr;
            _userService = userService;
        }

        public Commission Commission { get; set; } = new Commission();
        public List<CommissionMember> CommissionMembers { get; set; } = new List<CommissionMember>();
        public List<AppUserModelExtended> Users { get; set; } = new List<AppUserModelExtended>();

        public void OnGet(int commissionID)
        {
            //Get Commissions and Commission members...
            Commission = _cr.GetCommissions().Where(x => x.CommissionID == commissionID).SingleOrDefault();
            CommissionMembers = _cr.GetCommissionMembers(commissionID).OrderByDescending(x => x.StartDate).ToList();
            Users = _userService.GetUsersInfo().ToList();
        }
    }
}