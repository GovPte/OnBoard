namespace OnBoard.WebApp.Data.Tables
{
    public class Organization
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationDescription { get; set; }
        public string OrganizationWebsite { get; set; }
        public int? AddressID { get; set; }
        public Address Address { get; set; }
        //TO-DO: Geographical boundaries need to be defined
    }
}