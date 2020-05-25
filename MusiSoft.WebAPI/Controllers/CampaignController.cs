using MusiSoft.Entities;
using MusiSoft.Services.Contract.Contract;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace MusiSoft.WebAPI.Controllers
{
    public class CampaignController : ApiController
    {
        private ICampaignService campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            this.campaignService = campaignService;
        }

        [ResponseType(typeof(CampaignViewModel))]
        public IHttpActionResult GetCampaign()
        {
            return Ok(campaignService.GetCampaigns());
        }

        [ResponseType(typeof(CampaignViewModel))]
        public IHttpActionResult GetCampaign(int id)
        {
            var campaign = campaignService.GetCampaignById(id);

            if (campaign == null)
            {
                return Content(HttpStatusCode.BadRequest, "Campaign doesn't exist");
            }

            return Ok(campaign);
        }

        [ResponseType(typeof(bool))]
        public IHttpActionResult PutCampaign(int id, CampaignViewModel campaign)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != campaign.Id)
            {
                return Content(HttpStatusCode.BadRequest, "Invalid content data");
            }

            if (campaignService.EditCampaign(campaign))
            {
                return Ok(true);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(CampaignViewModel))]
        public IHttpActionResult PostCampaign(CampaignViewModel campaign)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (campaignService.AddCampaign(campaign))
            {
                return Ok(campaign);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Campaign already exists");
            }
        }

        [ResponseType(typeof(bool))]
        public IHttpActionResult DeleteCampaign(int id)
        {
            if (campaignService.DeleteCampaign(id))
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