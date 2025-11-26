using OnBoard.WebApp.Data.Tables;
using System.Collections.Generic;
using System.Linq;

namespace OnBoard.WebApp.Data.Services
{
    public interface IOrganizationService
    {
        List<Tables.Organization> GetOrganizations();
        void AddOrganization(Tables.Organization organization);
        void AddOrganizationDocument(int organizationID, int documentID);
    }

    public class OrganizationService : IOrganizationService
    {
        private readonly IBaseService<Document> _documentRepo;
        private readonly IBaseService<Tables.Organization> _organizationRepo;
        private readonly IBaseService<Tables.OrganizationDocument> _organizationDocRepo;

        public OrganizationService(IBaseService<Document> documentRepo,
            IBaseService<Tables.Organization> organizationRepo, IBaseService<Tables.OrganizationDocument> organizationDocRepo)
        {
            _documentRepo = documentRepo;
            _organizationRepo = organizationRepo;
            _organizationDocRepo = organizationDocRepo;
        }

        public List<Tables.Organization> GetOrganizations()
        {
            return _organizationRepo.AllInclude(x => x.Address).ToList();
        }

        public void AddOrganization(Tables.Organization organization)
        {
            _organizationRepo.Insert(organization);
        }

        public void AddOrganizationDocument(int organizationID, int documentID)
        {
            var orgDoc = new OrganizationDocument(){ 
                OrganizationID = organizationID, 
                //Organization = _organizationRepo.FindByKey(organizationID),
                DocumentID = documentID//, 
                //Document = _documentRepo.FindByKey(documentID)
                };
            _organizationDocRepo.Insert(orgDoc);
        }
    }
}
