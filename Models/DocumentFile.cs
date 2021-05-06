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

        public Guid UniqueId { get; set; }

        [Required]
        public DateTime UploadDate { get; set; }
        public string DocumentPath { get; set; }
        [Required]        
        public string DocumentName { get; set; }
       
        public Guid LegalEntity { get; set; }
        [Required]
        public Guid TypeGuid { get; set; }
        public string FileExtension { get; set; }
        [Required]
        public List<MetadataTag> Tags { get; set; } = new List<MetadataTag>();

       
    }
}
