using System.Collections.Generic;
using System.Linq;

namespace OnBoard.WebApp.Data.Services
{
    public interface IDocumentService
    {
        List<Tables.Document> GetDocuments();
        List<Tables.DocumentType> GetDocumentTypes();
        void AddDocument(Tables.Document document);
    }

    public class DocumentService : IDocumentService
    {
        private readonly IBaseService<Tables.Document> _documentRepo;
        private readonly IBaseService<Tables.DocumentType> _documentTypeRepo;

        public DocumentService(IBaseService<Tables.Document> documentRepo,
            IBaseService<Tables.DocumentType> documentTypeRepo)
        {
            _documentRepo = documentRepo;
            _documentTypeRepo = documentTypeRepo;
        }

        public List<Tables.Document> GetDocuments()
        {
            return _documentRepo.AllInclude(x => x.DocumentType).ToList();
        }

        public List<Tables.DocumentType> GetDocumentTypes()
        {
            return _documentTypeRepo.All().ToList();
        }

        public void AddDocument(Tables.Document document)
        {
            _documentRepo.Insert(document);
        }
    }
}
