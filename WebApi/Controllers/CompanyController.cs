using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("getcompanylist")]
        public IActionResult GetCompanyList()
        {
            var result = _companyService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("addcompany")]
        public IActionResult AddCompany(Company company)
        {
            var result = _companyService.Add(company);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("deletecompany")]
        public IActionResult DeleteCompany(Company company)
        {
            var result = _companyService.Delete(company);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("updatecompany")]
        public IActionResult UpdateCompany(Company company)
        {
            var result = _companyService.Update(company);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getcompanybyid")]
        public IActionResult GetCompany(int id)
        {
            var result = _companyService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
