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

        public bool AddCampaign(CampaignViewModel campaignViewModel)
        {
            bool saved = false;

            var _campaign = campaignRepository.GetCampaignById(campaignViewModel.Id);

            if ((_campaign == null))
            {
                var campaign = campaignViewModel.ModelToEntity();
                campaignRepository.Add(campaign, true);
                saved = true;
            }

            return saved;
        }

        public bool DeleteCampaign(int campaignId)
        {
            bool deleted = false;

            var campaign = campaignRepository.GetCampaignById(campaignId);

            if ((campaign != null))
            {
                campaignRepository.Delete(campaign, true);
                deleted = true;
            }

            return deleted;
        }

        public bool EditCampaign(CampaignViewModel campaignViewModel)
        {
            bool edited = false;

            var campaign = campaignViewModel.ModelToEntity();

            if ((campaign != null) && (ExistCampaign(campaign.Id)))
            {
                campaignRepository.Edit(campaign, true);
                edited = true;
            }

            return edited;
        }

        public IEnumerable<CampaignViewModel> GetCampaigns()
        {
            return campaignRepository.FindAll<Campaigns>().EntityToModel();
        }

        public CampaignViewModel GetCampaignById(int campaignId)
        {
            var campaign = campaignRepository.GetCampaignById(campaignId);

            return campaign != null ? campaign.EntityToModel() : null;
        }

        private bool ExistCampaign(int campaignId)
        {
            bool existCampaign = false;
            var campaign = campaignRepository.GetCampaignById(campaignId);

            if (campaign != null)
            {
                campaignRepository.Detach(campaign);
                existCampaign = true;
            }

            return existCampaign;
        }
    }
}