﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using curso_restful.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace curso_restful.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FileController : ControllerBase
    {
        private FileService service;

        public FileController(FileService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetFile()
        {
            byte[] buffer = service.GetPDFFile();
            if (buffer != null)
            {
                HttpContext.Response.ContentType = "application/pdf";
                HttpContext.Response.Headers.Add("content-length", buffer.Length.ToString());
                HttpContext.Response.Body.WriteAsync(buffer, 0, buffer.Length);
            }

            return new ContentResult();
        }
    }
}