using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Xml.Linq;
using USG_Anormaly_lib;
using USG_Anormaly_Server.Models;
using UploadFileResultModel = USG_Anormaly_lib.UploadFileResultModel;

namespace USG_Anormaly_Server.Controllers
{

    
    [ApiController]
    public class FileUploadController : ControllerBase
    {

        private readonly usg_anormaly_mvi_systemContext _dbcontext;
        public FileUploadController(usg_anormaly_mvi_systemContext context)
        {
            _dbcontext = context;
        }

        [Route("usg_mvi_anormaly/FileUpload")]
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 2097152000)]
        [RequestSizeLimit(2097152000)]
        public async Task<ActionResult<UploadFileResultModel>> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("file not selected");
            var fileSplit = file.FileName.Split('.');
            string fileType = fileSplit[fileSplit.Length-1];
            if(fileType != "zip")
            {
                return BadRequest("Please upload only zip file.");
            }
            var path = PathProcess._uploadPath;
            var unixtime = DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString().Replace(".","-");
            string fName = Path.GetFileNameWithoutExtension(file.FileName) + $"_{unixtime}." + fileType;

            path = Path.Combine(path, fName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok(new UploadFileResultModel
            {
                msg = $"file {fName} uploaded",
                fileName = fName
            });
        }

        [Route("usg_mvi_anormaly/FileUploadChunk")]
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 2097152000)]
        [RequestSizeLimit(2097152000)]
        public async Task<ActionResult<UploadFileResultModel>> UploadFileChunk(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("file not selected");
            var path = PathProcess._uploadPath;
            
            string fName = file.FileName;//Path.GetFileNameWithoutExtension(file.FileName) + $"_{unixtime}." + fileType;

            path = Path.Combine(path, fName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            try
            {
                Shared.Utils UT = new Shared.Utils();
                bool merged = false;
                string baseFName = "";
                UT.MergeFile(path, out merged, out baseFName);
                if (merged)
                {
                    fName = Path.GetFileName(baseFName);
                    return Ok(new UploadFileResultModel
                    {
                        msg = $"file {fName} uploaded",
                        fileName = fName
                    });
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }


        [Route("usg_mvi_anormaly/FileUpload/UploadTrainedModel")]
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 2097152000)]
        [RequestSizeLimit(2097152000)]
        public async Task<ActionResult<UploadFileResultModel>> UploadTrainedModel(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("file not selected");
            var fileSplit = file.FileName.Split('.');
            string fileType = fileSplit[fileSplit.Length - 1];
            if (fileType != "zip")
            {
                return BadRequest("Please upload only zip file.");
            }
            var path = PathProcess._modelUpload;
            // var unixtime = DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString().Replace(".", "-");
            string fName = file.FileName;//Path.GetFileNameWithoutExtension(file.FileName) + fileType;

            path = Path.Combine(path, fName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            //string unzipPath = Path.Combine(PathProcess._modelPath, Path.GetFileNameWithoutExtension(file.FileName));
            //if(!Directory.Exists(unzipPath))
            //    Directory.CreateDirectory(unzipPath);

            ZipProcess zipProcess = new ZipProcess();

            var pathExportZip = Path.Combine(PathProcess._modelPath, Path.GetFileNameWithoutExtension(file.FileName));
            if(!Directory.Exists(pathExportZip))
            {
                Directory.CreateDirectory(pathExportZip);
            }
            zipProcess.unZip(path, pathExportZip);
            zipProcess.deleteZip(path);
            try
            {
                var dataTrain = await (new AIDatabaseProcess(_dbcontext)).getTrainingData(Path.GetFileNameWithoutExtension(file.FileName));
                if (dataTrain != null)
                {
                    var filesupload = dataTrain.fileUpload;
                    (new ZipProcess()).deleteZip(Path.Combine(PathProcess._uploadPath, filesupload.zipNameFront));
                    (new ZipProcess()).deleteZip(Path.Combine(PathProcess._uploadPath, filesupload.zipNameSide1));
                    (new ZipProcess()).deleteZip(Path.Combine(PathProcess._uploadPath, filesupload.zipNameSide2));

                }
            }
            catch(Exception ex)
            {

            }


            return Ok(new UploadFileResultModel
            {
                msg = $"file {fName} uploaded",
                fileName = PathProcess._modelPath+ @"\"+Path.GetFileNameWithoutExtension(file.FileName)
            });
        }

        [Route("usg_mvi_anormaly/FileUpload/UploadTrainedModelChunk")]
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 2097152000)]
        [RequestSizeLimit(2097152000)]
        public async Task<ActionResult<UploadFileResultModel>> UploadTrainedModelChunkFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("file not selected");
            var path = PathProcess._modelUpload;
            string fName = file.FileName;
            path = Path.Combine(path, fName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            try
            {
                Shared.Utils UT = new Shared.Utils();
                bool merged = false;
                string baseFName = "";
                UT.MergeFile(path, out merged, out baseFName);
                if (merged)
                {
                    ZipProcess zipProcess = new ZipProcess();
                    var pathExportZip = Path.Combine(PathProcess._modelPath, Path.GetFileNameWithoutExtension(baseFName));
                    if (!Directory.Exists(pathExportZip))
                    {
                        Directory.CreateDirectory(pathExportZip);
                    }
                    zipProcess.unZip(path, pathExportZip);
                    zipProcess.deleteZip(path);
                    try
                    {
                        var dataTrain = await (new AIDatabaseProcess(_dbcontext)).getTrainingData(Path.GetFileNameWithoutExtension(baseFName));
                        if (dataTrain != null)
                        {
                            var filesupload = dataTrain.fileUpload;
                            (new ZipProcess()).deleteZip(Path.Combine(PathProcess._uploadPath, filesupload.zipNameFront));
                            (new ZipProcess()).deleteZip(Path.Combine(PathProcess._uploadPath, filesupload.zipNameSide1));
                            (new ZipProcess()).deleteZip(Path.Combine(PathProcess._uploadPath, filesupload.zipNameSide2));

                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    
                    return Ok(new UploadFileResultModel
                    {
                        msg = $"file {Path.GetFileName(baseFName)} uploaded",
                        fileName = PathProcess._modelPath + @"\" + Path.GetFileNameWithoutExtension(baseFName)
                    });
                }
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
