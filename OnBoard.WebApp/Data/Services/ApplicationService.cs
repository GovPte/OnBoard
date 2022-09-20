using System;
using System.Collections.Generic;
using System.Linq;

using OnBoard.WebApp.Data.Tables;

namespace OnBoard.WebApp.Data.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IBaseService<Application> _applicationService;
        private readonly IBaseService<ApplicationQuestion> _applicationQuestionsService;
        private readonly IBaseService<CommissionApplication> _commissionApplicationsService;
        private readonly IBaseService<ApplicationExtended> _usersExtendedRepo;

        public ApplicationService(IBaseService<Application> applicationService, IBaseService<CommissionApplication> commissionApplicationsService,
            IBaseService<ApplicationQuestion> applicationQuestionsService, IBaseService<ApplicationExtended> usersExtendedRepo)
        {
            _applicationService = applicationService;
            _applicationQuestionsService = applicationQuestionsService;
            _commissionApplicationsService = commissionApplicationsService;
            _usersExtendedRepo = usersExtendedRepo;
        }

        public List<Application> GetActiveApplications()
        {
            return _applicationService.FindByInclude(x => x.ApplicationArchived == null, x => x.UserExtended).ToList();
                //.Join(_usersExtendedRepo.All(), app => app.ApplicationUserID, ue => ue.UserExtendedUserId, (app,ue) => new { app, ue }).Select(x => x.app).ToList();
        }

        public List<Application> GetArchivedApplications()
        {
            return _applicationService.FindBy(x => x.ApplicationArchived != null).OrderByDescending(x => x.ApplicationArchived).ToList();
        }

        public List<Application> GetActiveApplications(int commissionID)
        {
            //Get Commission Applications data and then link to Applications and return...
            return _commissionApplicationsService.FindByInclude(x => x.CommissionID == commissionID && x.Application.ApplicationArchived == null,
                x => x.Application).Select(x => x.Application).ToList();     
        }

        public string GetBoardsAndCommissionsAppliedTo(int applicationID)
        {
            string commissions = "";
            var listCa = _commissionApplicationsService.FindByInclude(x => x.ApplicationID == applicationID, x=> x.Commission).ToList();

            foreach (var ca in listCa)
                commissions += $"{ca.Commission.CommissionName}, ";

            if (commissions.Length > 2)
                commissions = commissions.Substring(0, commissions.Length - 2);

            return commissions;
        }

        public List<ApplicationQuestion> GetApplicationQuestions()
        {
            return _applicationQuestionsService.All().ToList();
        }

        public void ArchiveApplication(int applicationID)
        {
            var app = _applicationService.FindBy(x => x.ApplicationID == applicationID).SingleOrDefault();
            app.ApplicationArchived = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            _applicationService.Update(app);
        }
    }
}
