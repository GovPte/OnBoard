using System.Collections.Generic;

using OnBoard.WebApp.Data.Tables;

namespace OnBoard.WebApp.Data.Services
{
    public interface ICommissionService
    {
        IEnumerable<Commission> GetCommissions();
        Commission GetActiveCommission(int commissionID);
        List<CommissionMember> GetCommissionMembers();
        List<CommissionMember> GetCommissionMembers(int commissionID);
        List<CommissionMember> GetCommissionMembersActive();
        List<CommissionMember> GetCommissionMembersActive(int commissionID);
        List<Application> GetCommissionApplications(int? commissionID);
        CommissionMember GetCommissionMember(int id);
    }
}