using AutoMapper;
using Common.Dto_s;
using Repository.Entity;
using Repository.Interfaces;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class HmoServices:IDataService<HmoDto>
    {
        private readonly IDataRepository<Hmo> dataRepository;
        private readonly IMapper mapper;
        public HmoServices(IDataRepository<Hmo> dataRepository, IMapper mapper)
        {
            this.dataRepository = dataRepository;
            this.mapper = mapper;
        }
        public async Task<HmoDto> AddDataAsync(HmoDto entity)
        {
            Hmo e = mapper.Map<Hmo>(entity);
            return mapper.Map<HmoDto>(await dataRepository.AddDataAsync(e));
        }
        public async Task<List<HmoDto>> GetAllAsync()
        {
            return mapper.Map<List<HmoDto>>(await dataRepository.GetAllAsync());
        }
        public async Task<HmoDto> GetDataByIdAsync(string idNumber)
        {
            return null;
        }

        public Task<HmoDto> UpdateDataAsync(string idNumber, bool? mOf, int? hmoid)
        {
            return null;
        }

    }
}
