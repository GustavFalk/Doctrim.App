using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MetadataTag
    {
        public int Id { get; set; }
        public string Tag { get; set; }        
        public Guid DocumentGuid { get; set; }

        public override string ToString()
        {
            return Tag;
        }
    }
}
