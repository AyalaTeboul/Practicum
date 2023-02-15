using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IContext
    {
        DbSet<Hmo> Hmos { get; set; }
        DbSet<Person> Persons { get; set; }
        DbSet<FatherAndChild> FatherAndChildren { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
