using MusiSoft.Entities;
using System.Collections.Generic;

namespace MusiSoft.Services.Contract.Contract
{
    public interface ICampaignService
    {
        void AddCampaign(CampaignViewModel campaignViewModel);

        void EditCampaign(CampaignViewModel campaignViewModel);

        void DeleteCampaign(int campaignId);

        IEnumerable<CampaignViewModel> GetCampaigns();
    }
}