using MusiSoft.Data.EF.Context;
using MusiSoft.Entities;
using System.Collections.Generic;

namespace MusiSoft.Mapper
{
    public static class CampaignMapper
    {
        public static CampaignViewModel EntityToModel(this Campaigns campaign)
        {
            return new CampaignViewModel
            {
                Id = campaign.Id,
                CompanyId = campaign.CompanyId,
                Name = campaign.Name,
                Objective = campaign.Objective,
                Description = campaign.Description,
                MusicalGenreId = campaign.MusicalGenreId,
                StartDate = campaign.StartDate.Date,
                EndDate = campaign.EndDate?.Date
            };
        }

        public static IEnumerable<CampaignViewModel> EntityToModel(this IEnumerable<Campaigns> campaigns)
        {
            if (campaigns == null) yield return null;
            else
                foreach (var campaign in campaigns)
                {
                    yield return EntityToModel(campaign);
                }
        }

        public static Campaigns ModelToEntity(this CampaignViewModel campaignViewModel)
        {
            return new Campaigns
            {
                Id = campaignViewModel.Id,
                CompanyId = campaignViewModel.CompanyId,
                Name = campaignViewModel.Name,
                Objective = campaignViewModel.Objective,
                Description = campaignViewModel.Description,
                MusicalGenreId = campaignViewModel.MusicalGenreId,
                StartDate = campaignViewModel.StartDate,
                EndDate = campaignViewModel.EndDate
            };
        }

        public static IEnumerable<Campaigns> ModelToEntity(this IEnumerable<CampaignViewModel> campaignsViewModel)
        {
            if (campaignsViewModel == null) yield return null;
            else
                foreach (var campaign in campaignsViewModel)
                {
                    yield return ModelToEntity(campaign);
                }
        }
    }
}