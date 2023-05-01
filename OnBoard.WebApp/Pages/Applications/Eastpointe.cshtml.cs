using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using OnBoard.WebApp.Data;
using OnBoard.WebApp.Data.Tables;
using OnBoard.WebApp.Models;

namespace OnBoard.WebApp.Pages.Applications
{
    public class EastpointeModel : PageModel
    {
        private readonly DataModelDbContext _context;
        private readonly ApplicationDbContext _contextUsers;

        public EastpointeModel(DataModelDbContext context, ApplicationDbContext contextUsers)
        {
            _context = context;
            _contextUsers = contextUsers;
        }

        [TempData]
        public string Message { get; set; } = string.Empty;
        public Application Application { get; set; } = new Application();
        [BindProperty]
        public DateTime ApplicationSubmitted { get; set; } = new DateTime();
        [BindProperty]
        public List<int> CommissionsSelected { get; set; } = new List<int>();
        public List<Commission> Commissions { get; set; } = new List<Commission>();
        [BindProperty]
        public ApplicationExtended UserExtended { get; set; } = new ApplicationExtended();
        [BindProperty]
        public string UserEmail { get; set; } = string.Empty;

        //Questions
        public ApplicationQuestion ApplicationQuestion1 { get; set; } = new ApplicationQuestion();
        [BindProperty]
        public QuestionAnswer QuestionAnswer1 { get; set; } = new QuestionAnswer();
        public ApplicationQuestion ApplicationQuestion2 { get; set; } = new ApplicationQuestion();
        [BindProperty]
        public QuestionAnswer QuestionAnswer2 { get; set; } = new QuestionAnswer();
        public ApplicationQuestion ApplicationQuestion3 { get; set; } = new ApplicationQuestion();
        [BindProperty]
        public QuestionAnswer QuestionAnswer3 { get; set; } = new QuestionAnswer();
        public ApplicationQuestion ApplicationQuestion4 { get; set; } = new ApplicationQuestion();
        [BindProperty]
        public QuestionAnswer QuestionAnswer4 { get; set; } = new QuestionAnswer();
        public ApplicationQuestion ApplicationQuestion5 { get; set; } = new ApplicationQuestion();
        [BindProperty]
        public string QuestionAnswer5Text { get; set; } = "";
        public ApplicationQuestion ApplicationQuestion6 { get; set; } = new ApplicationQuestion();
        [BindProperty]
        //public QuestionAnswer QuestionAnswer6 { get; set; } = new QuestionAnswer();
        [Required]
        public string QuestionAnswer6Text { get; set; } = "";

        public IActionResult OnGet()
        {
            if (User.IsInRole("Administrator") || User.IsInRole("Manager"))
            {
                //Get Questions...
                var aq = _context.ApplicationQuestions;
                ApplicationQuestion1 = aq.Find(2);
                ApplicationQuestion2 = aq.Find(3);
                ApplicationQuestion3 = aq.Find(4);
                ApplicationQuestion4 = aq.Find(5);
                ApplicationQuestion5 = aq.Find(6);
                ApplicationQuestion6 = aq.Find(7);

                //Defaults...
                ApplicationSubmitted = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")).Date;

                //Get Commissions for drop-down...
                Commissions = _context.Commissions.OrderBy(x => x.CommissionName).ToList();
                ViewData["Commissions"] = new SelectList(Commissions, "CommissionID", "CommissionName");

                return Page();
            }
            else
                return RedirectToPage("/Index");             
        }

        /// <summary>
        /// Save the user's Board and Commission Application
        /// </summary>
        public async Task<IActionResult> OnPostAsync()
        {
            //If all required fields have not been populated...
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //-----------//
            // User Info //
            //-----------//

            //If user exists, use their ID...
            string userID = null;
            if (_contextUsers.Users.Where(x => x.Email == UserEmail).Count() > 0)
            {
                userID = _contextUsers.Users.Where(x => x.Email == UserEmail).SingleOrDefault().Id;

                UserExtended.UserExtendedUserId = userID;
            }
            //else user does not exist, so create their account...
            else
            {
                //Create user account...
                AppUserModels user = new AppUserModels
                {
                    UserName = UserEmail,
                    Email = UserEmail
                };
                await _contextUsers.Users.AddAsync(user);

                //Add user to "Resident" role...
                IdentityUserRole<string> userRole = new IdentityUserRole<string>
                {
                    UserId = user.Id,
                    RoleId = "4" //4=Resident
                };
                await _contextUsers.UserRoles.AddAsync(userRole);
                userID = user.Id; //Save the user ID for later

                UserExtended.UserExtendedUserId = userID;
            }

            //Extended User Info...
            await _context.ApplicationsExtended.AddAsync(UserExtended);

            //-------------//
            // Application //
            //-------------//

            //Create Application...
            Application userApp = new Application
            {
                //ApplicationSubmitted = DateTime.Now, //This is in interface since I am inputting myself
                ApplicationSubmitted = ApplicationSubmitted,
                ApplicationUserID = userID
            };

            await _context.Applications.AddAsync(userApp);
            await _context.SaveChangesAsync(); //Update database

            //Six questions next, so create the answers to them...
            await _context.AddAsync(new QuestionAnswer
            {
                QuestionAnswerText = QuestionAnswer1.QuestionAnswerText,
                ApplicationQuestionID = 2,
                ApplicationID = userApp.ApplicationID
            });
            await _context.AddAsync(new QuestionAnswer
            {
                QuestionAnswerText = QuestionAnswer2.QuestionAnswerText,
                ApplicationQuestionID = 3,
                ApplicationID = userApp.ApplicationID
            });
            await _context.AddAsync(new QuestionAnswer
            {
                QuestionAnswerText = QuestionAnswer3.QuestionAnswerText != "0" ? QuestionAnswer3.QuestionAnswerText : "",
                ApplicationQuestionID = 4,
                ApplicationID = userApp.ApplicationID
            });
            await _context.AddAsync(new QuestionAnswer
            {
                QuestionAnswerText = QuestionAnswer4.QuestionAnswerText,
                ApplicationQuestionID = 5,
                ApplicationID = userApp.ApplicationID
            });
            await _context.AddAsync(new QuestionAnswer
            {
                QuestionAnswerText = QuestionAnswer5Text != null ? QuestionAnswer5Text : "",
                ApplicationQuestionID = 6,
                ApplicationID = userApp.ApplicationID
            });
            await _context.AddAsync(new QuestionAnswer
            {
                QuestionAnswerText = QuestionAnswer6Text != null ? QuestionAnswer6Text : "",
                ApplicationQuestionID = 7,
                ApplicationID = userApp.ApplicationID
            });

            userApp.UserExtended = UserExtended;
            _context.Applications.Update(userApp);

            //----------------------//
            // Boards & Commissions //
            //----------------------//

            //Last question about interested Boards/Commissions
            //  Go through each Board passed to here and those are the boards the user is interested in...
            foreach (var commission in CommissionsSelected)
            {
                await _context.AddAsync(new CommissionApplication
                {
                    CommissionID = commission,
                    ApplicationID = userApp.ApplicationID
                });
            }

            await _contextUsers.SaveChangesAsync(); //Update database
            await _context.SaveChangesAsync(); //Update database

            Message = "Thank you for submitting an application! -Eastpointe City Council";

            //TO-DO
            //Send email using SendGrid
            //  Should go to City Manager, City Manager Executive Assistant, City Council, current members of that board/commission

            return RedirectToPage("/Applications/Eastpointe");
        }
    }
}
