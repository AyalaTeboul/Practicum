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
    public class PersonRepository : IDataRepository<Person>
    {
        IContext _context;
        public PersonRepository(IContext context)
        {
            _context = context;
        }
        public async Task<Person> AddDataAsync(Person entity)
        {
            Person p = await GetDataByIdNumberAsync(entity.IdNumber);
            if (p == null)
            {
                EntityEntry<Person> e = await _context.Persons.AddAsync(entity);
                await _context.SaveChangesAsync();
                return e.Entity;
            }
            else
            {
                return await UpdateDataAsync(entity.IdNumber, entity.MaleOrFemale, entity.Hmoid);
            }
        }
        public async Task<List<Person>> GetAllAsync()
        {
            List<Person> lst = await _context.Persons.ToListAsync();
            return await _context.Persons.ToListAsync();
        }
        public async Task<Person> GetDataByIdNumberAsync(string idNumber)
        {
            return await _context.Persons.FirstOrDefaultAsync(x => x.IdNumber == idNumber);
        }

        public async Task<Person> UpdateDataAsync(string idNumber, bool? mOf, int? hmoid)
        {
            Person p = await _context.Persons.FirstAsync(x => x.IdNumber == idNumber);
            p.MaleOrFemale = mOf;
            p.Hmoid = hmoid;
            EntityEntry<Person> e = _context.Persons.Update(p);
            await _context.SaveChangesAsync();
            return e.Entity;
        }
    }
}