using System.Collections.Generic;

using OnBoard.WebApp.Data.Tables;

namespace OnBoard.WebApp.Data.Services
{
    public interface IApplicationService
    {
        List<Application> GetActiveApplications();
        List<Application> GetArchivedApplications();
        List<Application> GetActiveApplications(int commissionID);
        string GetBoardsAndCommissionsAppliedTo(int applicationID);
        List<ApplicationQuestion> GetApplicationQuestions();
        void ArchiveApplication(int applicationID);
    }
}
