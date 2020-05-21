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
    }
}