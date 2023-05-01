using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using OnBoard.WebApp.Data;
using OnBoard.WebApp.Data.Services;
using OnBoard.WebApp.Data.Tables;
using OnBoard.WebApp.Models;
using OnBoard.WebApp.Pages.Shared;

namespace OnBoard.WebApp.Pages
{
    public class ApplicationModel : BasePageModel
    {
        public readonly DataModelDbContext _dataContext;
        public readonly ApplicationDbContext _userContext;
        public readonly IApplicationService _ar;
        private readonly ICommissionService _cs;

        public ApplicationModel(DataModelDbContext dataContext, ApplicationDbContext userContext, IApplicationService ar, ICommissionService cs)
        {
            _dataContext = dataContext;
            _userContext = userContext;
            _ar = ar;
            _cs = cs;
        }

        [TempData]
        public string Message { get; set; } = string.Empty;
        public Application Application { get; set; } = new Application();
        public List<ApplicationQuestion> ApplicationQuestions { get; set; } = new List<ApplicationQuestion>();
        public ApplicationQuestion ApplicationQuestion { get; set; } = new ApplicationQuestion();
        public QuestionAnswer QuestionAnswer { get; set; } = new QuestionAnswer();
        [BindProperty]
        public ApplicationExtended UserExtended { get; set; } = new ApplicationExtended();
        [Required]
        [BindProperty]
        public string UserEmail { get; set; } = string.Empty;
        [BindProperty]
        public List<Commission> Commissions { get; set; } = new List<Commission>();

        public IActionResult OnGetAsync()
        {
            if (IsAdminOrManager())
            {
                Commissions = _cs.GetCommissions().OrderBy(x => x.CommissionName).ToList();
                ViewData["Commissions"] = new SelectList(Commissions, "CommissionID", "CommissionName");
                ApplicationQuestions = _ar.GetApplicationQuestions();

                return Page();
            }
            else
                return RedirectToPage("/Index");
        }

        /// <summary>
        /// Save the user's Board and Commission Application
        /// </summary>
        /// <param name="app"></param>
        /// <param name="userExtended"></param>
        /// <param name="Commissions"></param>
        public async Task<IActionResult> OnPostAsync(
            bool RegisteredVoter, bool PreviousExperience, string PreviousExperienceDetails, 
            bool CrimeConviction, string CrimeConvictionDetails, string CommunityInvolvement)
        {
            //TO-DO: There will probably need to be custom validation...
            //...

            //if all required fields have been populated...
            if (ModelState.IsValid)
            {
                //-----------//
                // User Info //
                //-----------//

                //if user exists, use their ID...
                string userID = null;
                if (_userContext.Users.Where(x => x.Email == UserEmail).Count() > 0)
                {
                    userID = _userContext.Users.Where(x => x.Email == UserEmail).SingleOrDefault().Id;

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
                    await _userContext.Users.AddAsync(user);

                    //Add user to "Resident" role...
                    IdentityUserRole<string> userRole = new IdentityUserRole<string>
                    {
                        UserId = user.Id,
                        RoleId = "4" //4=Resident
                    };
                    await _userContext.UserRoles.AddAsync(userRole);
                    userID = user.Id; //Save the user ID for later

                    UserExtended.UserExtendedUserId = userID;
                }

                //Extended User Info...               
                await _dataContext.ApplicationsExtended.AddAsync(UserExtended);

                //-------------//
                // Application //
                //-------------//

                //Create Application...
                Application userApp = new Application
                {
                    ApplicationSubmitted = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")), //Save date/time that this application was submitted
                    ApplicationUserID = userID
                };
                await _dataContext.Applications.AddAsync(userApp);
                await _dataContext.SaveChangesAsync(); //Update database

                //Six questions next, so create the answers to them...
                await _dataContext.AddAsync(new QuestionAnswer
                { QuestionAnswerText = RegisteredVoter.ToString(),
                    ApplicationQuestionID = 2, ApplicationID = userApp.ApplicationID });
                await _dataContext.AddAsync(new QuestionAnswer
                { QuestionAnswerText = PreviousExperience.ToString(),
                    ApplicationQuestionID = 3, ApplicationID = userApp.ApplicationID });
                await _dataContext.AddAsync(new QuestionAnswer
                { QuestionAnswerText = PreviousExperienceDetails != null ? PreviousExperienceDetails : "", //ToString() in case the user enters nothing
                    ApplicationQuestionID = 4, ApplicationID = userApp.ApplicationID });
                await _dataContext.AddAsync(new QuestionAnswer
                { QuestionAnswerText = CrimeConviction.ToString(),
                    ApplicationQuestionID = 5, ApplicationID = userApp.ApplicationID });
                await _dataContext.AddAsync(new QuestionAnswer
                { QuestionAnswerText = CrimeConvictionDetails != null ? CrimeConvictionDetails : "", //ToString() in case the user enters nothing
                    ApplicationQuestionID = 6, ApplicationID = userApp.ApplicationID });
                await _dataContext.AddAsync(new QuestionAnswer
                { QuestionAnswerText = CommunityInvolvement != null ? CommunityInvolvement : "", //ToString() in case the user enters nothing
                    ApplicationQuestionID = 7, ApplicationID = userApp.ApplicationID });

                //----------------------//
                // Boards & Commissions //
                //----------------------//

                //Last question about interested Boards/Commissions
                //  Go through each Board passed to here and those are the boards the user is interested in...
                foreach(var c in Commissions)
                {
                    await _dataContext.AddAsync(new CommissionApplication { CommissionID = c.CommissionID,
                        ApplicationID = userApp.ApplicationID });
                }

                await _userContext.SaveChangesAsync(); //Update database
                await _dataContext.SaveChangesAsync(); //Update database

                Message = "Thank you for submitting an application! -Eastpointe City Council";

                //TO-DO
                //Send email using SendGrid
                //  Should go to City Manager, City Manager Executive Assistant, City Council, current members of that board/commission

            }

            return Page();
        }
    }
}