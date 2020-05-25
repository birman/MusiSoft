using MusiSoft.Entities;
using MusiSoft.Services.Contract.Contract;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace MusiSoft.WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [ResponseType(typeof(CustomerViewModel))]
        public IHttpActionResult GetCustomer()
        {
            return Ok(customerService.GetCustomers());
        }

        [ResponseType(typeof(CustomerViewModel))]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = customerService.GetCustomerById(id);

            if (customer == null)
            {
                return Content(HttpStatusCode.BadRequest, "Customer doesn't exist");
            }

            return Ok(customer);
        }

        [ResponseType(typeof(bool))]
        public IHttpActionResult PutCustomer(int id, CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return Content(HttpStatusCode.BadRequest, "Invalid content data");
            }

            if (customerService.EditCustomer(customer))
            {
                return Ok(true);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(CustomerViewModel))]
        public IHttpActionResult PostCustomer(CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (customerService.AddCustomer(customer))
            {
                return Ok(customer);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Customer already exists");
            }
        }

        [ResponseType(typeof(bool))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (customerService.DeleteCustomer(id))
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