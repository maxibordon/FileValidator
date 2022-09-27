using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileValidator.Utilities
{
    public static class FileTypeVerifier
    {
        private static FileTypeVerifyResult Unknown = new FileTypeVerifyResult
        {
            Name = "Desconocido",
            Description = "Tipo de archivo desconocido",
            IsVerified = false
        };

        static FileTypeVerifier()
        {
            Types = new List<FileType>
            {
                new Jpeg(),
                new Png(),
                new Pdf()
               
            }
                .OrderByDescending(x => x.SignatureLength)
                .ToList();


        }



        private static IEnumerable<FileType> Types { get; set; }



        public static FileTypeVerifyResult What(string path)
        {
            using var file = File.OpenRead(path);
            FileTypeVerifyResult result = null;

            foreach (var fileType in Types)
            {
                result = fileType.Verify(file);
                if (result.IsVerified)
                    break;
            }

            return result?.IsVerified == true
                   ? result
                   : Unknown;
        }

        public static FileTypeVerifyResult WhatBase64(string base64String,string extension)
        {           

            byte[] data = Convert.FromBase64String(base64String);
            var inStream = new MemoryStream(data);
            long size = inStream.Length;
            FileTypeVerifyResult result = null;

            foreach (var fileType in Types)
            {
                if (fileType.Extensions.Contains(extension.ToLower()))
                {
                    result = fileType.Verify(inStream);
                    break;            

                }
            }

            return result?.IsVerified == true
                   ? result
                   : Unknown;
        }





    }




}
