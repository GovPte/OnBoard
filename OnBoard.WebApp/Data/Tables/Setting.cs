using System.ComponentModel.DataAnnotations;

namespace OnBoard.WebApp.Data.Tables
{
    public class Setting
    {
        [Key][Required]
        public int SettingID { get; set; }
        public string SettingName { get; set; }
        public string SettingValue { get; set; }

        //TO-DO: Link settings to an Organization
    }
}