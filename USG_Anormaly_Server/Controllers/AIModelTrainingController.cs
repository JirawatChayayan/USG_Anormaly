using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using USG_Anormaly_Server.Models;

namespace USG_Anormaly_Server.Controllers
{
    [Route("usg_mvi_anormaly/[controller]")]
    [ApiController]
    public class AIModelTrainingController : ControllerBase
    {
        private readonly usg_anormaly_mvi_systemContext _dbcontext;
        public AIModelTrainingController(usg_anormaly_mvi_systemContext context)
        {
            _dbcontext = context;
        }

        [HttpGet("StatusDetail")]
        public async Task<ActionResult<List<TrainingStatusDetail>>> getStatus()
        {
            try
            {
                var res = await (new AIDatabaseProcess(_dbcontext)).statusDetail();
                if (res.Count == 0)
                    return NotFound();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet("NameInUse/{recipeName}")]
        public async Task<ActionResult<bool>>GetNameInuse(string recipeName)
        {
            return Ok(await (new AIDatabaseProcess(_dbcontext).nameInUse(recipeName)));
        }

        [HttpGet("ModelName/{mode}")]
        public async Task<ActionResult<List<ModelStatus>>>GetModelName(StatusMode mode)
        {
            var result = await (new AIDatabaseProcess(_dbcontext)).modelList(mode);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
        
        [HttpGet("ModelName")]
        public async Task<ActionResult<List<ModelStatus>>> GetModelName()
        {
            var result = await (new AIDatabaseProcess(_dbcontext)).modelList();
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("ModelNameOnTrainingInQueue")]
        public async Task<ActionResult<List<ModelStatus>>> GetOnTrainingInQueue()
        {
            var result = await (new AIDatabaseProcess(_dbcontext)).modelOnTrainingInQueue();
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("ModelInfo/{recipeName}")]
        public async Task<ActionResult<AITrainingModel>> GetModelInfo(string recipeName,bool reqAllImg = false)
        {
            var result = await (new AIDatabaseProcess(_dbcontext)).modelFinishedDetail(recipeName,reqAllImg);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }


        [HttpGet("ModelInfoTraining/{recipeName}")]
        public async Task<ActionResult<UploadFileModel>>GetDataForTraining(string recipeName)
        {
            var res = await (new AIDatabaseProcess(_dbcontext)).getTrainingData(recipeName);
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost("ModelDetail")]
        public async Task<ActionResult> PostModelDetail([FromBody] UploadFileModel model)
        {
            try
            {
                string res = await (new AIDatabaseProcess(_dbcontext)).uploadTrainingModelDetail(model);
                if(res == "OK")
                    return Ok();
                if (res == "InUse")
                    return BadRequest($"Recipe name {model.recipeName} are inuse.");
                return NotFound(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpPut("OnTraining/{recipeName}")]
        public async Task<ActionResult> OnTraining(string recipeName)
        {
            try
            {
                bool res = await (new AIDatabaseProcess(_dbcontext)).changeModeToOnTraining(recipeName);
                if(res)
                    return Ok();
                else
                    return BadRequest($"No data {recipeName} in system");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("TrainingFinished")]
        public async Task<ActionResult> TrainingFinish([FromBody] FinishedTrainingModel dataItem)
        {
            try
            {
                bool res = await (new AIDatabaseProcess(_dbcontext)).changeModeToFinish(dataItem);
                if (res)
                    return Ok();
                else
                    return BadRequest($"No data {dataItem.recipe} in system");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("TrainingError")]
        public async Task<ActionResult> TrainingFail([FromBody] ErrorTrainingModel dataItem)
        {
            try
            {
                bool res = await (new AIDatabaseProcess(_dbcontext)).changeModeToError(dataItem);
                if (res)
                    return Ok();
                else
                    return BadRequest($"No data {dataItem.recipe} in system");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
