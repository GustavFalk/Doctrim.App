﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DocumentPostDTO
    {
        public DocumentFile DocumentFile { get; set; }

        public byte[] FileByteArray { get; set; }

        public string FileInfo { get; set; }
    }
}
