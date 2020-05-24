using MusiSoft.Entities;
using MusiSoft.Services.Contract.Contract;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace MusiSoft.API.Controllers
{
    public class CompanyController : ApiController
    {
        private ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [ResponseType(typeof(CompanyViewModel))]
        public IHttpActionResult GetCompany()
        {
            return Ok(companyService.GetCompanies());
        }

        [ResponseType(typeof(CompanyViewModel))]
        public IHttpActionResult GetCompany(int id)
        {
            var company = companyService.GetCompanyById(id);

            if (company == null)
            {
                return Content(HttpStatusCode.BadRequest, "Company doesn't exist");
            }

            return Ok(company);
        }

        [ResponseType(typeof(bool))]
        public IHttpActionResult PutCompany(int id, CompanyViewModel company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company.Id)
            {
                return Content(HttpStatusCode.BadRequest, "Invalid content data");
            }

            if (companyService.EditCompany(company))
            {
                return Ok(true);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(CompanyViewModel))]
        public IHttpActionResult PostCompany(CompanyViewModel company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (companyService.AddCompany(company))
            {
                return Ok(company);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Company already exists");
            }
        }

        [ResponseType(typeof(bool))]
        public IHttpActionResult DeleteCompany(int id)
        {
            if (companyService.DeleteCompany(id))
            {
                return Ok(true);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Can't delete");
            }
        }
    }
}