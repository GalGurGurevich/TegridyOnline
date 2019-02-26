using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DBManager : IDisposable
    {
        private WeedShopDBContext context = new WeedShopDBContext();
        private UserRepository userRepository;
        private WeedRepository weedRepository;

        public UserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }

        public WeedRepository WeedRepository
        {
            get
            {
                if (weedRepository == null)
                    weedRepository = new WeedRepository(context);
                return weedRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
