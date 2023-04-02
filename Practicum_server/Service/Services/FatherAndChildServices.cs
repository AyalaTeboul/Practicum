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
    public class FatherAndChildServices:IDataService<FatherAndChildDto>
    {
        private readonly IDataRepository<FatherAndChild> dataRepository;
        private readonly IMapper mapper;
        public FatherAndChildServices(IDataRepository<FatherAndChild> dataRepository, IMapper mapper)
        {
            this.dataRepository = dataRepository;
            this.mapper = mapper;
        }
        public async Task<FatherAndChildDto> AddDataAsync(FatherAndChildDto entity)
        {
            FatherAndChild e = mapper.Map<FatherAndChild>(entity);
            return mapper.Map<FatherAndChildDto>(await dataRepository.AddDataAsync(e));
        }

        public async Task<List<FatherAndChildDto>> GetAllAsync()
        {
            return mapper.Map<List<FatherAndChildDto>>(await dataRepository.GetAllAsync());
        }

        public async Task<FatherAndChildDto> GetDataByIdAsync(string idNumber)
        {
            return null;
        }

        public Task<FatherAndChildDto> UpdateDataAsync(string idNumber,bool? mOf,int? hmoid)
        {
            return null;
        }
    }
}
