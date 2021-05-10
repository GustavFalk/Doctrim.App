using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public interface IDoctrimAPIService
    {
        public Task<List<DocumentType>> GetDocumentTypes();
        public Task<bool> PostDocumentFile(DocumentPostDTO documentPost);

        public Task<List<DocumentFile>> GetAllDocuments();
        public Task<DocumentPostDTO> DownloadDocument(Guid UniqueId);

        public Task<List<DocumentFile>> GetDocumentFilesFromType(DocumentType type);
        public Task<List<DocumentFile>> GetDocumentFilesBetweenDates(DateTime first, DateTime last);
        public Task<List<DocumentFile>> GetDocumentFromTag(string tag);
        public Task<List<DocumentFile>> DocumentSearch(SearchDTO SearchParameter);
        public Task<List<DocumentTemplate>> GetTemplates();

        public Task<bool> PostTemplate(TemplatePostDTO templatePost);
    }
}
