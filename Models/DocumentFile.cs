using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DocumentFile
    {
        public int Id { get; set; }
       
        public Guid UniqueId { get; set; }      
       
        [Required]
        public DateTime UploadDate { get; set; }

        public string DocumentName { get; set; }
        [Required]
        public Guid LegalEntity { get; set; }
        [Required]
        public Guid TypeGuid { get; set; }
        public DocumentType Type { get; set; }
        
        public byte[]  FileByteArray { get; set; }
        public List<MetadataTag> Tags { get; set; } = new List<MetadataTag>();

        
    }
}
