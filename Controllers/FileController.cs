using FileValidator.Modelos;
using FileValidator.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileValidator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
       

        private readonly ILogger<FileController> _logger;

        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public String Get()
        {

            // var path = Path.Combine("./Files", "pgadmin4.JPG");
            //var path = Path.Combine("./Files", "prueba.pdf");
            // var path = Path.Combine("./Files", "prueba.docx");
            // var path = Path.Combine("./Files", "gen_caso_sfdc.xls");
            var path = Path.Combine("./Files", "pinguino.png");
            FileTypeVerifyResult result = FileTypeVerifier.What(path);
            return result.Description;

        }
        [HttpPost]
        [Route("ValidarFile")]
        public string ValidarFile(ParametrosEnvio parametrosEnvio)
        {
           
            FileTypeVerifyResult result = FileTypeVerifier.WhatBase64(parametrosEnvio.base64String,parametrosEnvio.extension);
            return result.Description;
        }

    }
}
