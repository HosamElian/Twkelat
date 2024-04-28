using Microsoft.AspNetCore.Mvc;
using Twkelat.Persistence;
using Twkelat.Persistence.Consts;
using Twkelat.Persistence.DTOs;
using Twkelat.Persistence.Interfaces.IServices;

namespace Twkelat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwkelatController : ControllerBase
    {
        private readonly ITwkelatService _twkelatService;

        public TwkelatController(ITwkelatService twkelatService)
        {
            _twkelatService = twkelatService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll(string civilId)
        {
            var result = _twkelatService.GetAllBlcoksAsync(civilId);
            if (result.IsCompleted)
            {
                var respose = new APIResponse
                {
                    IsSuccess = result.IsCompleted,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Result = result.Value
                };
                return Ok(respose);
            }
            return Ok(result.Message);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int blockId)
        {
            var result = _twkelatService.GetBlcokByIdAsync(blockId);
            if (result.IsCompleted)
            {
                return Ok(result.Value);
            }
            return Ok(result.Message);
        }

        [HttpPost("AddNewBlcok")]
        public IActionResult AddNewBlcok(CreateBlockDTO model)
        {
            var result = _twkelatService.AddNewBlock(model);
            if (result.IsCompleted)
            {
                return Ok(ResultMessages.ProcessCompleted);
            }
            return Ok();
        }

        [HttpPut("ChangeStatus")]
        public IActionResult ChangeStatus(ChangeValidState model)
        {
            var result = _twkelatService.ChangeBlockValidState(model);
            if (result.IsCompleted)
            {
                return Ok(result.Message);
            }
            return Ok(result.Message);
        }
    }
}
