using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

using OnBoard.WebApp.Data;
using OnBoard.WebApp.Data.Services;
using OnBoard.WebApp.Data.Tables;

namespace OnBoard.WebApp.Pages.CommissionMembers
{
    public class ListModel : PageModel
    {
        public readonly ICommissionService _cr;
        public readonly IUserService _userService;

        public ListModel(ICommissionService cr, IUserService userService)
        {
            _cr = cr;
            _userService = userService;
        }

        public List<Commission> Commissions { get; set; } = new List<Commission>();
        public List<CommissionMember> CommissionMembers { get; set; } = new List<CommissionMember>();
        public List<AppUserModelExtended> Users { get; set; } = new List<AppUserModelExtended>();

        public void OnGet()
        {
            //Get Commissions and Commission members...
            Commissions = _cr.GetCommissions().Where(x => x.CommissionActive).OrderBy(x => x.CommissionName).ToList();
            CommissionMembers = _cr.GetCommissionMembersActive();
            Users = _userService.GetUsersInfo().ToList();
        }
    }
}