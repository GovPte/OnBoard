using System.Collections.Generic;
using System.Linq;

namespace OnBoard.WebApp.Data.Services
{
    public interface IDocumentService
    {
        List<Tables.Document> GetDocuments();
        List<Tables.DocumentType> GetDocumentTypes();
        string GetDocumentOrganizations(int documentID);
        void AddDocument(Tables.Document document);
    }

    public class DocumentService : IDocumentService
    {
        private readonly IBaseService<Tables.Document> _documentRepo;
        private readonly IBaseService<Tables.DocumentType> _documentTypeRepo;
        private readonly IBaseService<Tables.OrganizationDocument> _organizationDocumentRepo;

        public DocumentService(IBaseService<Tables.Document> documentRepo,
            IBaseService<Tables.DocumentType> documentTypeRepo,
            IBaseService<Tables.OrganizationDocument> organizationDocumentRepo)
        {
            _documentRepo = documentRepo;
            _documentTypeRepo = documentTypeRepo;
            _organizationDocumentRepo = organizationDocumentRepo;
        }

        public List<Tables.Document> GetDocuments()
        {
            return _documentRepo.AllInclude(x => x.DocumentType).ToList();
        }

        public List<Tables.DocumentType> GetDocumentTypes()
        {
            return _documentTypeRepo.All().ToList();
        }

        public string GetDocumentOrganizations(int documentID)
        {
            var listOrgs = _organizationDocumentRepo.FindByInclude(x => x.DocumentID == documentID, x => x.Organization).ToList();
            var orgs = string.Empty;
            foreach (var org in listOrgs)
            {
                orgs += $"{org.Organization.OrganizationName}, ";
            }
            if (orgs.Length >= 2)
                orgs = orgs.Substring(0, orgs.Length - 2);
            return orgs;
        }

        public void AddDocument(Tables.Document document)
        {
            _documentRepo.Insert(document);
        }
    }
}
