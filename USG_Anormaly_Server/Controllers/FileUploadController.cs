using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using USG_Anormaly_Server.Models;

namespace USG_Anormaly_Server.Controllers
{

    [Route("usg_mvi_anormaly/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
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
    }
}
