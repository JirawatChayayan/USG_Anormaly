using Microsoft.AspNetCore.Mvc;
using USG_Anormaly_DL_lib;
using USG_Anormaly_lib;
using USG_Anormaly_Server.Models;
using ErrorTrainingModel = USG_Anormaly_Server.Models.ErrorTrainingModel;

namespace USG_Anormaly_Server.Controllers
{
    [Route("usg_mvi_anormaly/[controller]")]
    [ApiController]
    public class AIInferenceController : Controller
    {

        private readonly usg_anormaly_mvi_systemContext _dbcontext;
        public AIInferenceController(usg_anormaly_mvi_systemContext context)
        {
            _dbcontext = context;
        }

        [HttpPost]
        public async Task<ActionResult<DL_InferenceResult>> Post([FromBody] AIInferenceModel dataItem)
        {
            if (dataItem == null)
                return BadRequest("Input body is null !!!");
            if (dataItem.b64Img == null || dataItem.b64Img == "")
                return BadRequest("Please input image in base 64 format.");
            if (dataItem.recipe == null || dataItem.recipe == "")
                return BadRequest("Please input recipe.");
            if (!(dataItem.CameraIdx == CameraIdx.Front || dataItem.CameraIdx == CameraIdx.Side || dataItem.CameraIdx == CameraIdx.Side2))
                return BadRequest("Camera index is not correct");
            
            string recipeName = dataItem.recipe.Trim();
            var modelfinished = await (new AIDatabaseProcess(_dbcontext)).modelList(StatusMode.Finished);
            if (modelfinished == null)
                NotFound($"Not found recipe model training name {recipeName} !!!");
            bool haveRecipe = false;
            
            foreach(var model in modelfinished)
            {
                if(model.recipeName == recipeName)
                {
                    haveRecipe = true;
                    break;
                }
            }
            if (!haveRecipe)
                return NotFound($"Not found recipe model training name {recipeName} !!!");

            string[] imgRaw = dataItem.b64Img.Split(',');
            string[] detail1 = imgRaw[0].Split(';');
            string imgType = "";
            if (detail1[1] != "base64")
            {
                throw new Exception($"Unsupported format {imgRaw[0]}");
            }
            if (detail1[0] == "data:image/png")
            {
                imgType = ".png";
            }
            else if (detail1[0] == "data:image/jpg" || detail1[0] == "data:image/jpeg")
            {
                imgType = ".jpg";
            }
            else
            {
                throw new Exception($"Unsupported format {imgRaw[0]}");
            }
            string strImg = imgRaw[1].Trim();
            
            try
            {
               var result = (new DL_Inference()).inference(strImg, recipeName, dataItem.CameraIdx, dataItem.reqImgDisplay);
               return Ok(result);
            }
            catch (FileNotFoundException ex)
            {
                ErrorTrainingModel errorTrainingModel = new ErrorTrainingModel();
                errorTrainingModel.msg = ex.Message;
                errorTrainingModel.recipe = recipeName;
                await (new AIDatabaseProcess(_dbcontext)).changeModeToError(errorTrainingModel);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest();
        }
    }
}
