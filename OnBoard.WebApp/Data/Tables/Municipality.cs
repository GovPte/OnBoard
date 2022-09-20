namespace OnBoard.WebApp.Data.Tables
{
    public class Municipality
    {
        public int MunicipalityID { get; set; }
        public string MunicipalityName { get; set; }
        public int StateID { get; set; } //FK
        public State State { get; set; }
    }
}