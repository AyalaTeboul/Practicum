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
    public class FatherAndChildRepository : IDataRepository<FatherAndChild>
    {
        IContext _context;
        public FatherAndChildRepository(IContext context)
        {
            _context = context;
        }
        public async Task<FatherAndChild> AddDataAsync(FatherAndChild entity)
        {
            EntityEntry<FatherAndChild> e;

            //if (_context.FatherAndChildren.Any())
            //{
            //    FatherAndChild f = await _context.FatherAndChildren.FirstAsync(x => x.ChildId == entity.ChildId);
            //    if (f != null)
            //    {
            //        if (f.FatherId == null)
            //            f.FatherId = entity.FatherId;
            //        else f.MotherId = entity.MotherId;
            //        e = _context.FatherAndChildren.Update(f);
            //        await _context.SaveChangesAsync();
            //        return e.Entity;
            //    }
            //}

            //else
            //{
                e = await _context.FatherAndChildren.AddAsync(entity);
                await _context.SaveChangesAsync();
                return e.Entity;
            //}
            //return null;
        }

        public async Task<List<FatherAndChild>> GetAllAsync()
        {
            return await _context.FatherAndChildren.ToListAsync();
        }

        public Task<FatherAndChild> GetDataByIdNumberAsync(string idNumber)
        {
            return null;
        }

        public Task<FatherAndChild> UpdateDataAsync(string idNumber, bool? mOf, int? Hmoid)
        {
            return null;
        }
    }
}

