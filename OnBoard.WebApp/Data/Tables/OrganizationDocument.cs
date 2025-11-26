using System.ComponentModel.DataAnnotations;

namespace OnBoard.WebApp.Data.Tables
{
    public class OrganizationDocument
    {
        [Key][Required]
        public int OrganizationDocumentID { get; set; }
        public int OrganizationID { get; set; }
        public Organization Organization { get; set; }
        public int DocumentID { get; set; }
        public Document Document { get; set; }
    }
}
