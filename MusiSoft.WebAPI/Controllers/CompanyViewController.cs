using MusiSoft.Entities;
using MusiSoft.Helpers;
using MusiSoft.Services.Contract.Contract;
using System.Web.Mvc;

namespace MusiSoft.WebAPI.Controllers
{
    public class CompanyViewController : Controller
    {
        private ICompanyService companyService;

        public CompanyViewController() : this(DependencyFactory.Resolve<ICompanyService>())
        {
        }

        public CompanyViewController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        // GET: CompanyView
        public ActionResult Index()
        {
            var companies = companyService.GetCompanies();
            return View(companies);
        }

        // GET: CompanyView/Details/5
        public ActionResult Details(int id)
        {
            var company = companyService.GetCompanyById(id);
            return View(company);
        }

        // GET: CompanyView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyView/Create
        [HttpPost]
        public ActionResult Create(CompanyViewModel company)
        {
            try
            {
                companyService.AddCompany(company);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyView/Edit/5
        public ActionResult Edit(int id)
        {
            var company = companyService.GetCompanyById(id);
            return View(company);
        }

        // POST: CompanyView/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CompanyViewModel company)
        {
            try
            {
                companyService.EditCompany(company);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyView/Delete/5
        public ActionResult Delete(int id)
        {
            var company = companyService.GetCompanyById(id); 
            return View(company);
        }

        // POST: CompanyView/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                companyService.DeleteCompany(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}