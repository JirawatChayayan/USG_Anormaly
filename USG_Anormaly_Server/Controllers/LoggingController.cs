using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using USG_Anormaly_Server.Models;

namespace USG_Anormaly_Server.Controllers
{

    public class QueryParam
    {
        public DateTime fromDate { get; set; }
        public DateTime? toDate { get; set; }
    }

    [Route("usg_mvi_anormaly/[controller]")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        private readonly usg_anormaly_mvi_systemContext _dbcontext;
        public LoggingController(usg_anormaly_mvi_systemContext context)
        {
            _dbcontext = context;
        }

        [HttpPost("log-inference")]
        public async Task<ActionResult> Post_logInference([FromBody] LogInferenceInsertModel model)
        {
            try
            {
                bool res = await (new Logging(_dbcontext)).InsertLogInfer(model);
                if (res)
                    return Ok();
                return NotFound(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("log-training")]
        public async Task<ActionResult> Post_logTraining([FromBody] LogTrainingInsertModel model)
        {
            try
            {
                bool res = await (new Logging(_dbcontext)).InsertLogTraining(model);
                if (res)
                    return Ok();
                return NotFound(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("log-inference/")]
        public async Task<ActionResult<List<LogInferenceModel>>> get_logInfer([FromQuery] QueryParam queryParam)
        {
            if (queryParam == null)
                return BadRequest();
            if (queryParam.fromDate == null)
                return BadRequest();
            try
            {
                var res = await (new Logging(_dbcontext)).GetInferenceLogs(queryParam.fromDate, queryParam.toDate);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }



        }

        [HttpGet("log-training/")]
        public async Task<ActionResult<List<LogTrainingModel>>> get_logTraining([FromQuery] QueryParam queryParam)
        {
            if (queryParam == null)
                return BadRequest();
            if (queryParam.fromDate == null)
                return BadRequest();
            try
            {
                var res = await (new Logging(_dbcontext)).getLogTraining(queryParam.fromDate, queryParam.toDate);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("retrieve-log-training/")]
        public async Task<ActionResult<List<LogTrainingModel>>> retrieve_logTraining([FromBody] QueryParam queryParam)
        {
            if (queryParam == null)
                return BadRequest();
            if (queryParam.fromDate == null)
                return BadRequest();
            try
            {
                var res = await (new Logging(_dbcontext)).getLogTraining(queryParam.fromDate, queryParam.toDate);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("retrieve-log-inference/")]
        public async Task<ActionResult<List<LogInferenceModel>>> retrieve_logInfer([FromBody] QueryParam queryParam)
        {
            if (queryParam == null)
                return BadRequest();
            if (queryParam.fromDate == null)
                return BadRequest();
            try
            {
                var res = await (new Logging(_dbcontext)).GetInferenceLogs(queryParam.fromDate, queryParam.toDate);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
