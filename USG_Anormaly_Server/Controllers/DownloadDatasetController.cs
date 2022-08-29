using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;
using System.IO;
using USG_Anormaly_Server.Models;

namespace USG_Anormaly_Server.Controllers
{
    [ApiController]
    public class DownloadDatasetController : ControllerBase
    {
        private readonly IFileProvider fileProvider;
        private readonly usg_anormaly_mvi_systemContext _dbcontext;
        public DownloadDatasetController(IFileProvider provider, usg_anormaly_mvi_systemContext context)
        {
            fileProvider = provider;
            _dbcontext = context;
        }

        //[Route("usg_mvi_anormaly/api/list-dataset-file")]
        //[HttpGet]
        //public ActionResult<List<string>> Get()
        //{
        //    List<string> files = new List<string>();
        //    foreach (var item in fileProvider.GetDirectoryContents(""))
        //    {
        //        files.Add(item.Name);
        //    }
        //    return files;
        //}


        [Route("usg_mvi_anormaly/list-dataset-file-model")]
        [HttpGet]
        public async Task<ActionResult<List<FileListDownload>>> GetModel()
        {
            var result = await (new AIDatabaseProcess(_dbcontext)).modelOnTrainingInQueue();
            if (result == null)
                return NotFound();

            List<string> files = new List<string>();
            foreach (var item in fileProvider.GetDirectoryContents(""))
            {
                files.Add(item.Name);
            }
            List<FileListDownload> fileInQueue = new List<FileListDownload>();
            foreach (var item in result)
            {
                var dataTrain = await (new AIDatabaseProcess(_dbcontext)).getTrainingData(item.recipeName);
                if(dataTrain != null)
                {
                    var filesupload = dataTrain.fileUpload;
                    if (files.Contains(filesupload.zipNameFront) && files.Contains(filesupload.zipNameSide1) && files.Contains(filesupload.zipNameSide2))
                    {
                        fileInQueue.Add(new FileListDownload
                        {
                            recipe = item.recipeName,
                            status = item.status,
                            files = filesupload
                        });
                    }

                }
            }
            return Ok(fileInQueue);

        }



        [Route("usg_mvi_anormaly/download-dataset-file")]
        [HttpGet]
        public async Task<ActionResult> DownloadFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || fileName == null)
            {
                return Content("File Name is Empty...");
            }

            var result = await (new AIDatabaseProcess(_dbcontext)).modelList(StatusMode.InQueue);
            if (result == null)
                return NotFound();


            string filePath = "";
            // get the filePath
            foreach (var item in fileProvider.GetDirectoryContents(""))
            {
                if(item.Name == fileName)
                {
                    filePath = item.PhysicalPath;
                    break;
                }
            }
            if (filePath == "")
                return NotFound($"Not found file name {filePath} !!!");
            // create a memorystream
            var memoryStream = new MemoryStream();

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memoryStream);
            }
            // set the position to return the file from
            memoryStream.Position = 0;

            // Get the MIMEType for the File
            var mimeType = (string file) =>
            {
                var mimeTypes = MimeTypes.GetMimeTypes();
                var extension = Path.GetExtension(file).ToLowerInvariant();
                return mimeTypes[extension];
            };

            return File(memoryStream, mimeType(filePath), Path.GetFileName(filePath));
        }

    }
}
