using ExpenseModel;
using System.Collections.Generic;

namespace IExpenseBusiness
{
    public interface ISiteRepository
    {
        Site AddSite(Site site);
        IEnumerable<Site> GetAllSites();
        Site GetSiteByID(int id);
        void DeleteSite(Site site);
        void DeleteSite(int id);
        void UpdateSite(Site site);
        int checkLoginDetail(Site site);

    }
}
