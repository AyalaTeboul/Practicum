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
    public class PersonServices : IDataService<PersonDto>
    {
        private readonly IDataRepository<Person> dataRepository;
        private readonly IMapper mapper;
        public PersonServices(IDataRepository<Person> dataRepository, IMapper mapper)
        {
            this.dataRepository = dataRepository;
            this.mapper = mapper;
        }
        public async Task<PersonDto> AddDataAsync(PersonDto entity)
        {
            Person e = mapper.Map<Person>(entity);
            return mapper.Map<PersonDto>(await dataRepository.AddDataAsync(e));
        }
        public async Task<List<PersonDto>> GetAllAsync()
        {
            return mapper.Map<List<PersonDto>>(await dataRepository.GetAllAsync());
        }
        public async Task<PersonDto> GetDataByIdAsync(string idNumber)
        {
            return mapper.Map<PersonDto>(await dataRepository.GetDataByIdNumberAsync(idNumber));
        }
        public async Task<PersonDto> UpdateDataAsync(string idNumber, bool? mOf, int? hmoid)
        {
            return mapper.Map<PersonDto>(await dataRepository.UpdateDataAsync(idNumber,mOf,hmoid));
        }
    }
}
