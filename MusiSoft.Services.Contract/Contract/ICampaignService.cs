using MusiSoft.Entities;
using System.Collections.Generic;

namespace MusiSoft.Services.Contract.Contract
{
    public interface ICampaignService
    {
        bool AddCampaign(CampaignViewModel campaignViewModel);

        bool EditCampaign(CampaignViewModel campaignViewModel);

        bool DeleteCampaign(int campaignId);

        IEnumerable<CampaignViewModel> GetCampaigns();

        CampaignViewModel GetCampaignById(int campaign);
    }
}