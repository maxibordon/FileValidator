using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileValidator.Utilities
{
    public sealed class Pdf : FileType
    {
        public Pdf()
        {
            Name = "PDF";
            Description = "PDF Document";
            AddExtensions("pdf");
            AddSignatures(
                // new byte[] { 0x25, 0x50, 0x44, 0x46,0x2d }
                new byte[] { 0x25, 0x50, 0x44, 0x46 }
            );
        }
    }
}
