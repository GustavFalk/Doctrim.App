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
        public Task<DocumentFile> PostDocumentFile(DocumentFile file);
    }
}
