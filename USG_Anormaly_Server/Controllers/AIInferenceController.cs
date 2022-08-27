//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics;
//using USG_Anormaly_DL_lib;
//using USG_Anormaly_lib;
//using USG_Anormaly_Server.Models;
//using ErrorTrainingModel = USG_Anormaly_Server.Models.ErrorTrainingModel;
//using LogInferenceInsertModel = USG_Anormaly_Server.Models.LogInferenceInsertModel;

//namespace USG_Anormaly_Server.Controllers
//{
//    [Route("usg_mvi_anormaly/[controller]")]
//    [ApiController]
//    public class AIInferenceController : Controller
//    {

//        private readonly usg_anormaly_mvi_systemContext _dbcontext;
//        public AIInferenceController(usg_anormaly_mvi_systemContext context)
//        {
//            _dbcontext = context;
//        }

//        [HttpPost]
//        public async Task<ActionResult<USG_Anormaly_lib.DL_InferenceResult>> Post([FromBody] USG_Anormaly_lib.AIInferenceModel dataItem)
//        {
//            if (dataItem == null)
//                return BadRequest("Input body is null !!!");
//            if (dataItem.b64Img == null || dataItem.b64Img == "")
//                return BadRequest("Please input image in base 64 format.");
//            if (dataItem.recipe == null || dataItem.recipe == "")
//                return BadRequest("Please input recipe.");
//            if (!(dataItem.CameraIdx == CameraIdx.Front || dataItem.CameraIdx == CameraIdx.Side || dataItem.CameraIdx == CameraIdx.Side2))
//                return BadRequest("Camera index is not correct");
//            if (dataItem.clientId == null || dataItem.clientId == "")
//                return BadRequest("Please input client ID");

//            string cameraStr = "";
//            switch (dataItem.CameraIdx)
//            {
//                case CameraIdx.Front:
//                    cameraStr = "Front";
//                    break;
//                case CameraIdx.Side:
//                    cameraStr = "Side1";
//                    break;
//                case CameraIdx.Side2:
//                    cameraStr = "Side2";
//                    break;
//            }

//            string recipeName = dataItem.recipe.Trim();
//            var modelfinished = await (new AIDatabaseProcess(_dbcontext)).modelList(StatusMode.Finished);
//            if (modelfinished == null)
//                NotFound($"Not found recipe model training name {recipeName} !!!");
//            bool haveRecipe = false;
            
//            foreach(var model in modelfinished)
//            {
//                if(model.recipeName == recipeName)
//                {
//                    haveRecipe = true;
//                    break;
//                }
//            }
//            if (!haveRecipe)
//                return NotFound($"Not found recipe model training name {recipeName} !!!");




//            LogInferenceInsertModel log = new LogInferenceInsertModel();
//            log.modelName = recipeName;
//            log.camera = cameraStr;
//            log.clientId = dataItem.clientId.Trim();



//            string[] imgRaw = dataItem.b64Img.Split(',');
//            string[] detail1 = imgRaw[0].Split(';');
//            string imgType = "";
//            if (detail1[1] != "base64")
//            {
//                log.processTime = 0;
//                log.rejectPosition = null;
//                log.remark = $"Unsupported format {imgRaw[0]}";
//                log.result = false;
//                bool res = await (new Logging(_dbcontext)).InsertLogInfer(log);
//                return BadRequest($"Unsupported format {imgRaw[0]}");
//            }
//            if (detail1[0] == "data:image/png")
//            {
//                imgType = ".png";
//            }
//            else if (detail1[0] == "data:image/jpg" || detail1[0] == "data:image/jpeg")
//            {
//                imgType = ".jpg";
//            }
//            else
//            {
//                log.processTime = 0;
//                log.rejectPosition = null;
//                log.remark = $"Unsupported format {detail1[0]}";
//                log.result = false;
//                bool res = await (new Logging(_dbcontext)).InsertLogInfer(log);
//                return BadRequest($"Unsupported format {detail1[0]}");
//            }
//            string strImg = imgRaw[1].Trim();

//            Stopwatch sw = new Stopwatch();
//            sw.Start();
//            try
//            {
//                string posRejectAll = null;
//                var result = (new DL_Inference()).inference(out posRejectAll,strImg, recipeName, dataItem.CameraIdx, dataItem.reqImgDisplay);
//                sw.Stop();

//                if(result.anormalyClass == "ok")
//                {
//                    log.rejectPosition = null;
//                    log.result = true;
//                }
//                else
//                {
//                    log.result = false;
//                    if(posRejectAll != null)
//                        log.rejectPosition =posRejectAll;
//                }
//                log.processTime = sw.Elapsed.TotalMilliseconds;
//                bool res = await (new Logging(_dbcontext)).InsertLogInfer(log);
//                return Ok(result);
//            }
//            catch (FileNotFoundException ex)
//            {
//                log.processTime = 0;
//                log.rejectPosition = null;
//                log.remark = ex.Message;
//                log.result = false;
//                bool res = await (new Logging(_dbcontext)).InsertLogInfer(log);


//                ErrorTrainingModel errorTrainingModel = new ErrorTrainingModel();
//                errorTrainingModel.msg = ex.Message;
//                errorTrainingModel.recipe = recipeName;
//                await (new AIDatabaseProcess(_dbcontext)).changeModeToError(errorTrainingModel);
//                sw.Stop();
//                return NotFound(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                log.processTime = 0;
//                log.rejectPosition = null;
//                log.remark = ex.Message;
//                log.result = false;
//                bool res = await (new Logging(_dbcontext)).InsertLogInfer(log);
//                sw.Stop();
//                return BadRequest(ex.Message);
//            }
//            sw.Stop();
//            return BadRequest();
//        }
//    }
//}
