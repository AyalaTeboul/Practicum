using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IDataService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetDataByIdAsync(string idNumber);
        Task<T> AddDataAsync(T entity);
        Task<T> UpdateDataAsync(string idNumber, bool? mOf, int? Hmoid);
    }
}
