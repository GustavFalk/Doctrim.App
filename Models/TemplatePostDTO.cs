using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class TemplatePostDTO
    {
        public DocumentTemplate TemplateDTO { get; set; } = new DocumentTemplate();

        public byte[] FileByteArray { get; set; }
    }
}
