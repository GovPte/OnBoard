using Microsoft.AspNetCore.Mvc.RazorPages;
using OnBoard.WebApp.Data.Services;
using System.Collections.Generic;

namespace OnBoard.WebApp.Pages.Info
{
    public class IndexModel : PageModel
    {
        IDocumentService _documentService;

        public IndexModel(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public List<Data.Tables.Document> Documents = new List<Data.Tables.Document>();

        public void OnGet()
        {
            Documents = _documentService.GetDocuments();
        }
    }
}
