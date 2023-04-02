using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public  interface IDataRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetDataByIdNumberAsync(string idNumber);
        Task<T> AddDataAsync(T entity);
        Task<T> UpdateDataAsync(string idNumber, bool? mOf, int? Hmoid);
    }
}
