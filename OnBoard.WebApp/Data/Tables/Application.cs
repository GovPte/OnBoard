using System;
using System.ComponentModel.DataAnnotations;

namespace OnBoard.WebApp.Data.Tables
{
    public class Application
    {
        [Key][Required]
        public int ApplicationID { get; set; }
        [Required]
        public DateTime ApplicationSubmitted { get; set; }
        [MaxLength(450)]
        public string ApplicationUserID { get; set; } //FK to AspNetUsers.Id
        public DateTime? ApplicationRenewed { get; set; }
        public DateTime? ApplicationArchived { get; set; }
        public int? UserExtendedID { get; set; } 
        public ApplicationExtended UserExtended { get; set; }

        //TODO: In Production, I will have to modify so that each Application has the original phone/email that was submitted?
        //      Except now I think there is only one field? Maybe change it one-to-many? hmmmmmmmm
        //UPDATE applications SET UserExtendedID = (SELECT top 1 UserExtendedId FROM userextended WHERE ApplicationUserID = UserExtended.UserExtendedUserId ORDER BY applicationid DESC)

        //TO-DO: What happens when someone moves out of the city?
        //  We should have enable/disable or a start and end time for each app

        //TO-DO: Also, what if a user talks to someone and says, actually, I'd like to take "Board A" off my list, 
        //  but keep Board B and Board C. There should be edit functionality with an audit trail.
    }
}