using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ExpenseLibrary;
using ExpenseModel;

namespace ExpenseBusiness
{
    public class SiteRepository
    {
        private readonly ExpenseSystemContext db;
        public SiteRepository()
        {
            db = new ExpenseSystemContext();
        }
        public Site AddSite(Site site)
        {
            if (db.tblSites.Any(s => s.Name == site.Name))
            {
                return null;
            }
            else
            {
                var result = db.tblSites.Add(site);
                db.SaveChanges();
                return result;
            }
        }
        public IEnumerable<Site> GetAllSites()
        {
            return db.tblSites.ToList();
        }
        public Site GetSiteByID(int id)
        {
            return db.tblSites.Where(s => s.Id == id).SingleOrDefault();
        }
        public void DeleteSite(Site site)
        {
            db.tblSites.Remove(site);
            db.SaveChanges();
        }
        public void DeleteSite(int id)
        {
            Site site = GetSiteByID(id);
            db.tblSites.Remove(site);
            db.SaveChanges();
        }
        public void UpdateSite(Site site)
        {
            db.tblSites.Attach(site);
            db.Entry(site).State = EntityState.Modified;
            db.SaveChanges();

        }

        public int checkLoginDetail(Site site)
        {
            if (db.tblSites.Any(s => s.Name == site.Name && s.Password == site.Password))
            {
                return db.tblSites.Where(s => s.Name == site.Name && s.Password == site.Password).Select(s => s.Id).SingleOrDefault();
            }
            return 0;
        }

        ~SiteRepository()
        {
            db.Dispose();
        }
    }
}
