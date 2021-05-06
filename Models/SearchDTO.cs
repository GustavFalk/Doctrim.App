using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    
    public class SearchDTO
    {
        
        public Guid TypeGuid { get; set; }
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        public string TagName { get; set; }
        public Guid LegalEntityGuid { get; set; }
    }
}
