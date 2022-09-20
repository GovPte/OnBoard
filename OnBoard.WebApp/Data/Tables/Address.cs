namespace OnBoard.WebApp.Data.Tables
{
    public class Address
    {
        public int AddressID { get; set; }
        public string AddressStreet { get; set; }
        public string AddressExtended { get; set; }
        public int MunicipalityID { get; set; } //FK
        public Municipality Municipality { get; set; } //FK
        public int AddressZipCode { get; set; }
    }
}