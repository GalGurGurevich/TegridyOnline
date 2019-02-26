using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class WeedRepository : IDisposable
    {
        private WeedShopDBContext context;

        public WeedRepository(WeedShopDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Weed> GetWeed()
        {
            return context.WeedProducts.ToList();
        }

        public Weed GetWeedByID(int id)
        {
            return context.WeedProducts.Find(id);
        }

        public void InsertWeed(Weed weed)
        {
            context.WeedProducts.Add(weed);
        }

        public void DeleteWeed(int weedID)
        {
            Weed weed = context.WeedProducts.Find(weedID);
            context.WeedProducts.Remove(weed);
        }

        public void UpdateWeed(Weed weed)
        {
            context.Entry(weed).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
