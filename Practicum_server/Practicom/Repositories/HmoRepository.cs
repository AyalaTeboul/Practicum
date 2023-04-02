using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.Entity;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class HmoRepository : IDataRepository<Hmo>
    {
        IContext _context;
        public HmoRepository(IContext context)
        {
            _context = context;
        }
        public async Task<Hmo> AddDataAsync(Hmo entity)
        {
            EntityEntry<Hmo> e = await _context.Hmos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return e.Entity;
        }
        public async Task<List<Hmo>> GetAllAsync()
        {
            return await _context.Hmos.ToListAsync();
        }
        public async Task<Hmo> GetDataByIdNumberAsync(string idNumber)
        {
            return null;
        }

        public Task<Hmo> UpdateDataAsync(string idNumber, bool? mOf, int? Hmoid)
        {
            return null;
        }
    }
}
