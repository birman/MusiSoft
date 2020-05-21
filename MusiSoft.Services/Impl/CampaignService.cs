using MusiSoft.Data.EF.Context;
using MusiSoft.Entities;
using MusiSoft.Mapper;
using MusiSoft.Repositories.Contract.Contract;
using MusiSoft.Services.Contract.Contract;
using System.Collections.Generic;

namespace MusiSoft.Services.Impl
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository campaignRepository;

        public CampaignService(ICampaignRepository campaignRepository)
        {
            this.campaignRepository = campaignRepository;
        }

        public void AddCampaign(CampaignViewModel campaignViewModel)
        {
            var campaign = campaignViewModel.ModelToEntity();
            campaignRepository.Add(campaign, true);
        }

        public void EditCampaign(CampaignViewModel campaignViewModel)
        {
            var campaign = campaignViewModel.ModelToEntity();
            campaignRepository.Edit(campaign, true);
        }

        public void DeleteCampaign(int campaignId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CampaignViewModel> GetCampaigns()
        {
            return campaignRepository.FindAll<Campaigns>().EntityToModel();
        }
    }
}