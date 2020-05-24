using MusiSoft.Data.EF.Context;

namespace MusiSoft.Repositories.Contract.Contract
{
    public interface ICampaignRepository: IEFBaseRepository
    {
        Campaigns GetCampaignById(int campaignId);
    }
}