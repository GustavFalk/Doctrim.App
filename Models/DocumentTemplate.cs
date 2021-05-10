using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DocumentTemplate
    {
        public Guid UniqueId { get; set; }

        public string TemplateName { get; set; }

        public override string ToString()
        {
            return TemplateName;
        }
    }
}
