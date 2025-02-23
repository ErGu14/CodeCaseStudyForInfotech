using Commercium.Data.DbContexts;
using Commercium.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Data.Classes
{
    public class TransactionManager : ITransactionManager
    {
        private readonly CommerciumDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public TransactionManager(CommerciumDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericManager<T> GetManager<T>() where T : class
        {
            return _serviceProvider.GetRequiredService<IGenericManager<T>>();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
