using System.Collections.Generic;
using System.Linq;

namespace OnBoard.WebApp.Data.Services
{
    public interface IDocumentService
    {
        List<Tables.Document> GetDocuments();
    }

    public class DocumentService : IDocumentService
    {
        private readonly IBaseService<Tables.Document> _documentService;

        public DocumentService(IBaseService<Tables.Document> documentService)
        {
            _documentService = documentService;
        }

        public List<Tables.Document> GetDocuments()
        {
            return _documentService.AllInclude(x => x.DocumentType).ToList();
        }
    }
}
