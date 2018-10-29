using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewStar.Data.Insfrastructure
{
    public interface IDbFactory : IDisposable
    {
        NewStarDBContext Init();
    }
}
