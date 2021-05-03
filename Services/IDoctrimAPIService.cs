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
        public Task PostDocumentFile(DocumentPostDTO documentPost);

        public Task<List<DocumentFile>> GetAllDocuments();
        public Task<DocumentPostDTO> DownloadDocument(int id);

        public Task<List<DocumentFile>> GetDocumentFilesFromType(DocumentType type);
    }
}
