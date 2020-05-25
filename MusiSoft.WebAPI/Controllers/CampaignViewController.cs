using MusiSoft.Entities;
using MusiSoft.Helpers;
using MusiSoft.Services.Contract.Contract;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace MusiSoft.WebAPI.Controllers
{
    public class CampaignViewController : Controller
    {
        private ICampaignService campaignService;

        public CampaignViewController() : this(DependencyFactory.Resolve<ICampaignService>())
        {
        }

        public CampaignViewController(ICampaignService campaignService)
        {
            this.campaignService = campaignService;
        }

        // GET: CampaignView
        public ActionResult Index()
        {
            var campaigns = campaignService.GetCampaigns();
            return View(campaigns);
        }

        // GET: CampaignView/Details/5
        public ActionResult Details(int id)
        {
            var campaign = campaignService.GetCampaignById(id);
            return View(campaign);
        }

        // GET: CampaignView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CampaignView/Create
        [HttpPost]
        [Obsolete]
        public ActionResult Create(CampaignViewModel campaign)
        {
            try
            {
                var _company = ConfigurationSettings.AppSettings["company"];
                campaign.CompanyId = Int32.Parse(_company);

                campaignService.AddCampaign(campaign);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CampaignView/Edit/5
        public ActionResult Edit(int id)
        {
            var campaign = campaignService.GetCampaignById(id);
            return View(campaign);
        }

        // POST: CampaignView/Edit/5
        [HttpPost]
        [Obsolete]
        public ActionResult Edit(int id, CampaignViewModel campaign)
        {
            try
            {
                var _company = ConfigurationSettings.AppSettings["company"];
                campaign.CompanyId = Int32.Parse(_company);
                campaignService.EditCampaign(campaign);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CampaignView/Delete/5
        public ActionResult Delete(int id)
        {
            var campaign = campaignService.GetCampaignById(id);
            return View(campaign);
        }

        // POST: CampaignView/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                campaignService.DeleteCampaign(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}