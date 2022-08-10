using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalChargeController : Controller
    {
        private readonly ILocalChargeService _localChargeService;

        public LocalChargeController(ILocalChargeService localChargeService)
        {
            _localChargeService = localChargeService;
        }

        [HttpGet("getlocalchargelist")]
        public IActionResult Index()
        {
            var result = _localChargeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
