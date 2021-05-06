using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DocumentType
    {
       
             
        public Guid UniqueId { get; set; }
        [Required]
        public string Type { get; set; }

        public override string ToString()
        {
            return Type;
        }


    }
}
