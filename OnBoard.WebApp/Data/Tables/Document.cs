using System;

namespace OnBoard.WebApp.Data.Tables
{
    public class Document
    {
        public int DocumentID { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentDescription { get; set; }
        public string DocumentURL { get; set; }
        public string DocumentUpload {  get; set; }
        public DateTime DocumentStart { get; set; }
        public DateTime DocumentEnd { get; set; }
        public int DocumentTypeID { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}
