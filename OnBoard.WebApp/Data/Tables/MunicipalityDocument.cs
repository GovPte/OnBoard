namespace OnBoard.WebApp.Data.Tables
{
    public class MunicipalityDocument
    {
        public int MunicipalityDocumentID { get; set; }
        public int MunicipalityID { get; set; }
        public Municipality Municipality { get; set; }
        public int DocumentID { get; set; }
        public Document Document { get; set; }
    }
}
