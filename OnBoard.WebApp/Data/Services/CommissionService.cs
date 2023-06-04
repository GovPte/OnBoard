using System;
using System.Collections.Generic;
using System.Linq;

using OnBoard.WebApp.Data.Tables;

namespace OnBoard.WebApp.Data.Services
{
    public class CommissionService : ICommissionService
    {
        private readonly IBaseService<Application> _applicationService;
        private readonly IBaseService<Commission> _commissionsService;
        private readonly IBaseService<CommissionApplication> _commissionApplicationsService;
        private readonly IBaseService<CommissionMember> _commissionMembersService;

        public CommissionService(IBaseService<Application> applicationService, IBaseService<Commission> commissionsService,
            IBaseService<CommissionApplication> commissionApplicationsService, IBaseService<CommissionMember> commissionMembersService)
        {
            _applicationService = applicationService;
            _commissionsService = commissionsService;
            _commissionApplicationsService = commissionApplicationsService;
            _commissionMembersService = commissionMembersService;
        }

        public IEnumerable<Commission> GetCommissions()
        {
            return _commissionsService.FindBy(x => x.CommissionActive).OrderBy(x => x.CommissionName);
        }

        public Commission GetActiveCommission(int commissionID)
        {
            return _commissionsService.FindBy(x => x.CommissionActive && x.CommissionID == commissionID).SingleOrDefault();
        }

        /// <summary>
        /// This function will return all appointments ever to all commissions.
        /// <returns></returns>
        public List<CommissionMember> GetCommissionMembers()
        {
             return _commissionMembersService.AllInclude(x => x.Commission).ToList();
        }

        /// <summary>
        /// This function will return all appointments ever to a particular commission.
        /// <returns></returns>
        public List<CommissionMember> GetCommissionMembers(int commissionID)
        {
            return _commissionMembersService.FindByInclude(x => x.CommissionID == commissionID, x => x.Commission).ToList();
        }

        /// <summary>
        /// This function will return the current Commission Members. 
        /// TODO: Implement that an expired term stays in the list until that position
        /// </summary>
        /// <returns></returns>
        public List<CommissionMember> GetCommissionMembersActive()
        {
            var now = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            return _commissionMembersService.FindByInclude(x => x.StartDate <= now && x.EndDate > now, 
                                                            x => x.Commission).ToList(); //TODO: Need a JOIN here to the AspNetUsers table
        }

        public List<CommissionMember> GetCommissionMembersActive(int commissionID)
        {
            var now = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));

            //Figure out how many members should be on the Commission...
            var commission = GetActiveCommission(commissionID);
            var totalMembers = commission.CommissionMembersTotal;

            //For each member slot on the commission...
            List<int> activeCommissionMembers = new List<int>();
            for (int i = 1; i <= totalMembers; i++)
            {
                //If there is a member in the slot right now, and they have not resigned or been removed, return that person...
                var member = _commissionMembersService.FindBy(x => x.CommissionID == commissionID && x.StartDate <= now && x.EndDate > now && 
                    x.CommissionMemberSlot == i).OrderByDescending(x => x.StartDate).FirstOrDefault();

                //If member found, and they did not resign or get removed, show them...
                if (member != null && (member.CommissionMemberResignationRemovalNotes == null &&
                    member.CommissionMemberResignationRemovalMinutesLink == null))
                {
                    activeCommissionMembers.Add(member.CommissionMemberID);
                }
                //Else check to see if there are any members, and if so, return the last person that currently has an expired term...
                else
                {
                    var lastMember = _commissionMembersService.FindBy(x => x.CommissionID == commissionID && 
                                                x.CommissionMemberSlot == i).OrderByDescending(x => x.StartDate).FirstOrDefault();

                    //If member found, and they did not resign or get removed, show them...
                    if (lastMember != null && (lastMember.CommissionMemberResignationRemovalNotes == null &&
                        lastMember.CommissionMemberResignationRemovalMinutesLink == null))
                    {
                        activeCommissionMembers.Add(lastMember.CommissionMemberID);
                    }
                }
            }

            return _commissionMembersService.FindByInclude(x => activeCommissionMembers.Contains(x.CommissionMemberID), 
                                                            x => x.Commission).ToList(); //TODO: Need a JOIN here to the AspNetUsers table
        }

        public List<Application> GetCommissionApplications(int? commissionID)
        {
            if (commissionID.HasValue)
                return _commissionApplicationsService.FindByInclude(x => x.CommissionID == commissionID, x => x.Application)
                       .OrderByDescending(x => x.Application.ApplicationSubmitted)
                       .Select(x => x.Application).ToList();
            else
                return _applicationService.All().OrderByDescending(x => x.ApplicationSubmitted).ToList();
        }

        public CommissionMember GetCommissionMember(int id)
        {
            return _commissionMembersService.FindByInclude(x => x.CommissionMemberID == id, x => x.Commission).Single();
        }
    }
}