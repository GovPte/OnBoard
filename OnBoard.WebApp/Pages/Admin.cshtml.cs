using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using OnBoard.WebApp.Data;
using OnBoard.WebApp.Data.Services;
using OnBoard.WebApp.Data.Tables;
using OnBoard.WebApp.Models;
using OnBoard.WebApp.Pages.Shared;

namespace OnBoard.WebApp.Pages
{
    public class AdminModel : BasePageModel
    {
        public readonly IApplicationService _as;
        public readonly IUserService _us;
        private readonly IUnitOfWork _uow;
        public readonly ApplicationDbContext _um;

        public AdminModel(IApplicationService @as, IUserService us, IUnitOfWork uow, ApplicationDbContext um)
        {
            _as = @as;
            _us = us;
            _um = um;
            _uow = uow;
        }

        public List<Application> Applications { get; set; } = new List<Application>();
        public int SelectedCommission { get; set; }
        public List<AppUserModels> Users { get; set; } = new List<AppUserModels>();

        public IActionResult OnGet(int selectedCommission)
        {
            //Only allow administrators to get to this page
            if (IsAdmin())
            {
                Applications = _as.GetActiveApplications().OrderByDescending(x => x.ApplicationSubmitted).ToList();
                Users = _um.Users.ToList();

                //This sets what commission was selected in the Board/Commission filter...
                SelectedCommission = selectedCommission;

                return Page();
            }
            else
                return RedirectToPage("/Index");
        }

        public IActionResult OnPostArchive(int ApplicationID)
        {
            _as.ArchiveApplication(ApplicationID);
            _uow.SaveChanges();

            return Page();
        }
    }
}