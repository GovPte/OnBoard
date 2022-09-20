using System.ComponentModel.DataAnnotations;

namespace OnBoard.WebApp.Data.Tables
{
    public class Commission
    {
        [Key][Required]
        public int CommissionID { get; set; }
        [Required]
        public string CommissionName { get; set; }
        public string CommissionDescription { get; set; }
        public int CommissionMembersTotal { get; set; }
        public string CommissionOrdinanceOrLaw { get; set; } //Link to Ordinance or Law creating Commission
        public int OrganizationID { get; set; } //FK
        public Organization Organization { get; set; } //FK (i.e. City of Eastpointe)
        public bool CommissionActive { get; set; }
    }
}