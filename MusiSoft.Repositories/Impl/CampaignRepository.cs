using MusiSoft.Data.EF.Context;
using MusiSoft.Repositories.Base;
using MusiSoft.Repositories.Contract.Contract;

namespace MusiSoft.Repositories.Impl
{
    public class CampaignRepository : EFBaseRepository, ICampaignRepository
    {
        public CampaignRepository(MusiSoftBDEntities dbContext)
        {
            _context = dbContext;
        }

        public Campaigns GetCampaignById(int campaignId)
        {
            return _context.Campaigns.Find(campaignId);
        }
    }
}