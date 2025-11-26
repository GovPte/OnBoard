using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnBoard.WebApp.Data.Services;
using OnBoard.WebApp.Data.Tables;
using System.Collections.Generic;
using System.Linq;

namespace OnBoard.WebApp.Pages.Info
{
    public class AddModel : PageModel
    {
        private readonly IDocumentService _documentService;
        private readonly IOrganizationService _organizationService;
        private readonly IUnitOfWork _unitOfWork;

        public AddModel(IDocumentService documentService, IOrganizationService organizationService,
            IUnitOfWork unitOfWork) 
        { 
            _documentService = documentService;
            _organizationService = organizationService;
            _unitOfWork = unitOfWork;
        }

        public List<Organization> Organizations { get; set; } = new List<Organization>();
        public List<DocumentType> DocumentTypes { get; set; } = new List<DocumentType>();

        [BindProperty]
        public Data.Tables.Document Document { get; set; }
        [BindProperty]
        public List<int> OrganizationIDs { get; set; } = new List<int>();
        public int DocumentTypeID { get; set; }

        public void OnGet()
        {
            Organizations = _organizationService.GetOrganizations();
            ViewData["Organizations"] = new SelectList(Organizations.OrderBy(x => x.OrganizationName), "OrganizationID", "OrganizationName", OrganizationIDs);

            DocumentTypes = _documentService.GetDocumentTypes();
            ViewData["DocumentTypes"] = new SelectList(DocumentTypes.OrderBy(x => x.DocumentTypeName), "DocumentTypeID", "DocumentTypeName", DocumentTypeID);
        }

        public void OnPost()
        {
            //Insert Document
            _documentService.AddDocument(Document);

            _unitOfWork.SaveChanges(); //Save changes to save Document and get Document ID

            //Insert Organization Document records
            //var documentID = _documentService.GetDocuments().Where(x => x.DocumentID == Document.DocumentID);
            foreach (var orgID in OrganizationIDs)
            {
                _organizationService.AddOrganizationDocument(orgID, Document.DocumentID);
            }

            _unitOfWork.SaveChanges(); //Save changes to link Document to Organizations
        }
    }
}
