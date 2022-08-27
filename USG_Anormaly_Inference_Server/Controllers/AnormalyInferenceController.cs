using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using USG_Anormaly_DL_lib;
using USG_Anormaly_lib;

namespace USG_Anormaly_Inference_Server.Controllers
{
    public class Uptime
    {
        public DateTime startdate { get; set; }
        public DateTime curdate { get; set; }
        public TimeSpan uptime { get; set; }
    }
    public class AnormalyInferenceController : ApiController
    {
        


        [Route("api/uptime")]
        [HttpGet]
        [ResponseType(typeof(Uptime))]
        public HttpResponseMessage Get()
        {
            Uptime uptime = new Uptime();
            uptime.startdate = WebApiConfig.startDate;
            uptime.uptime = DateTime.Now.Subtract(WebApiConfig.startDate);
            uptime.curdate = DateTime.Now;
            return Request.CreateResponse(HttpStatusCode.OK, uptime);
        }

        [Route("api/infer")]
        [HttpPost]
        [ResponseType(typeof(string))]
        public HttpResponseMessage Post([FromBody] USG_Anormaly_lib.AIInferenceModel dataItem)
        {
            if (dataItem == null)
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Input body is null !!!");

            if (dataItem.b64Img == null || dataItem.b64Img == "")
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please input image in base 64 format.");

            if (dataItem.recipe == null || dataItem.recipe == "")
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please input recipe.");

            if (!(dataItem.CameraIdx == CameraIdx.Front || dataItem.CameraIdx == CameraIdx.Side || dataItem.CameraIdx == CameraIdx.Side2))
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Camera index is not correct");

            if (dataItem.clientId == null || dataItem.clientId == "")
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please input client ID");


            string cameraStr = "";
            switch (dataItem.CameraIdx)
            {
                case CameraIdx.Front:
                    cameraStr = "Front";
                    break;
                case CameraIdx.Side:
                    cameraStr = "Side1";
                    break;
                case CameraIdx.Side2:
                    cameraStr = "Side2";
                    break;
            }



            try
            {

                string recipeName = dataItem.recipe.Trim();
                var modelfinished = (new ServerInterface()).getModelFinished();
                if (modelfinished == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"Not found recipe model training name {recipeName} !!!");
                bool haveRecipe = false;

                foreach (var model in modelfinished)
                {
                    if (model.recipeName == recipeName)
                    {
                        haveRecipe = true;
                        break;
                    }
                }
                if (!haveRecipe)
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"Not found recipe model training name {recipeName} !!!");

                LogInferenceInsertModel log = new LogInferenceInsertModel();
                log.modelName = recipeName;
                log.camera = cameraStr;
                log.clientId = dataItem.clientId.Trim();

                string[] imgRaw = dataItem.b64Img.Split(',');
                string[] detail1 = imgRaw[0].Split(';');
                string imgType = "";
                if (detail1[1] != "base64")
                {
                    log.processTime = 0;
                    log.rejectPosition = null;
                    log.remark = $"Unsupported format {imgRaw[0]}";
                    log.result = false;
                    (new ServerInterface()).postInferLog(log);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, $"Unsupported format {imgRaw[0]}");
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
                    log.processTime = 0;
                    log.rejectPosition = null;
                    log.remark = $"Unsupported format {detail1[0]}";
                    log.result = false;
                    (new ServerInterface()).postInferLog(log);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, $"Unsupported format {detail1[0]}");
                }
                string strImg = imgRaw[1].Trim();



                Stopwatch sw = new Stopwatch();
                sw.Start();
                try
                {
                    string posRejectAll = null;
                    var result = (new DL_Inference()).inference(out posRejectAll, strImg, recipeName, dataItem.CameraIdx, dataItem.reqImgDisplay);
                    sw.Stop();

                    if (result.anormalyClass == "ok")
                    {
                        log.rejectPosition = null;
                        log.result = true;
                    }
                    else
                    {
                        log.result = false;
                        if (posRejectAll != null)
                            log.rejectPosition = posRejectAll;
                    }
                    log.processTime = sw.Elapsed.TotalMilliseconds;
                    (new ServerInterface()).postInferLog(log);
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                catch (FileNotFoundException ex)
                {
                    log.processTime = 0;
                    log.rejectPosition = null;
                    log.remark = ex.Message;
                    log.result = false;
                    (new ServerInterface()).postInferLog(log);


                    ErrorTrainingModel errorTrainingModel = new ErrorTrainingModel();
                    errorTrainingModel.msg = ex.Message;
                    errorTrainingModel.recipe = recipeName;
                    (new ServerInterface()).setToTrainingFail(errorTrainingModel);
                    sw.Stop();
                    return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
                }
                catch (Exception ex)
                {
                    log.processTime = 0;
                    log.rejectPosition = null;
                    log.remark = ex.Message;
                    log.result = false;
                    (new ServerInterface()).postInferLog(log);
                    sw.Stop();
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }


                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
