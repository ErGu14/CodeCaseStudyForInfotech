using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Data.Interfaces
{
    public interface ITransactionManager
    {
        IGenericManager<T> GetManager<T>() where T : class;
        Task<int> SaveAsync();
    }
}
