using System.ComponentModel.DataAnnotations;

namespace OnBoard.WebApp.Data.Tables
{
    public class CommissionApplication
    {
        [Key][Required]
        public int CommissionApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public Application Application { get; set; }
        public int CommissionID { get; set; }
        public Commission Commission { get; set; }

        public CommissionApplication() { }
    }
}