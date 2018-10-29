using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewStar.Data.Insfrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private NewStarDBContext dbContext;

        public NewStarDBContext Init()
        {
            return dbContext ?? (dbContext = new NewStarDBContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
