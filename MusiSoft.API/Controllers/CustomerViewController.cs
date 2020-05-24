using MusiSoft.Entities;
using MusiSoft.Helpers;
using MusiSoft.Services.Contract.Contract;
using System.Web.Mvc;

namespace MusiSoft.API.Controllers
{
    public class CustomerViewController : Controller
    {
        private ICustomerService customerService;

        public CustomerViewController() : this(DependencyFactory.Resolve<ICustomerService>())
        {

        }

        public CustomerViewController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET: CustomerView
        public ActionResult Index()
        {
            var customers = customerService.GetCustomers();
            return View(customers);
        }

        // GET: CustomerView/Details/5
        public ActionResult Details(int id)
        {
            var customer = customerService.GetCustomerById(id);
            return View(customer);
        }

        // GET: CustomerView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerView/Create
        [HttpPost]
        public ActionResult Create(CustomerViewModel customer)
        {
            try
            {
                customerService.AddCustomer(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerView/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = customerService.GetCustomerById(id);
            return View(customer);
        }

        // POST: CustomerView/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CustomerViewModel customer)
        {
            try
            {
                customerService.EditCustomer(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerView/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = customerService.GetCustomerById(id);
            return View(customer);
        }

        // POST: CustomerView/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CustomerViewModel customer)
        {
            try
            {
                customerService.DeleteCustomer(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}