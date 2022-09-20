using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnBoard.WebApp.Data.Tables
{
    [Table("UserExtended")]
    public class ApplicationExtended
    {
        [Key][Required]
        public int UserExtendedID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string UserExtendedNameFirst { get; set; }
        [Display(Name = "Middle Name")]
        public string UserExtendedNameMiddle { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string UserExtendedNameLast { get; set; }
        [Required]
        [Display(Name = "Street Address")]
        public string UserExtendedAddressStreet { get; set; }
        [Display(Name = "Extended Address")]
        public string UserExtendedAddressExtended { get; set; }
        [Display(Name = "Home Phone")]
        public string UserExtendedPhoneHome { get; set; }
        [Display(Name = "Cell Phone")]
        public string UserExtendedPhoneCell { get; set; }
        [MaxLength(450)]
        public string UserExtendedUserId { get; set; }

        public string UserExtendedFullName
        {
            get
            {
                return $"{UserExtendedNameFirst} {UserExtendedNameLast}";
            }
        }

        public ApplicationExtended() { }

        private void populate(ApplicationExtended ue)
        {
            UserExtendedID = ue.UserExtendedID;
            UserExtendedNameFirst = ue.UserExtendedNameFirst;
            UserExtendedNameMiddle = ue.UserExtendedNameMiddle;
            UserExtendedNameLast = ue.UserExtendedNameLast;
            UserExtendedAddressStreet = ue.UserExtendedAddressStreet;
            UserExtendedAddressExtended = ue.UserExtendedAddressExtended;
            UserExtendedPhoneHome = ue.UserExtendedPhoneHome;
            UserExtendedPhoneCell = ue.UserExtendedPhoneCell;
            UserExtendedUserId = ue.UserExtendedUserId;
        }
    }
}