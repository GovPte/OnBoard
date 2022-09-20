using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using OnBoard.WebApp.Data;
using OnBoard.WebApp.Data.Services;
using OnBoard.WebApp.Data.Tables;

namespace OnBoard.WebApp.Pages.Commissions
{
    public class IndexModel : PageModel
    {
        private readonly ICommissionService _commissionRepository;

        public IndexModel(ICommissionService commissionRepository)
        {
            _commissionRepository = commissionRepository;
        }

        public List<Commission> Commissions { get; set; } = new List<Commission>();

        public IActionResult OnGet()
        {
            Commissions = _commissionRepository.GetCommissions().ToList();
            return Page();          
        }
    }
}
