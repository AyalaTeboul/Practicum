using Common.Dto_s;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonController : ControllerBase
    {

        private readonly IDataService<PersonDto> dataServices;
        public PersonController(IDataService<PersonDto> dataServices)
        {
            this.dataServices = dataServices;
        }
        // GET: api/<PersonController>
        [HttpGet]
        public async Task<List<PersonDto>> Get()
        {
            return await dataServices.GetAllAsync();

        }

        // GET api/<PersonController>/5
        [HttpGet("{idNumber}")]
        public async Task<PersonDto> Get(string idNumber)
        {
            return await dataServices.GetDataByIdAsync(idNumber);
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<PersonDto> Post([FromBody] PersonModel person)
        {
            PersonDto data = new PersonDto();
            data.LastName = person.LastName;
            data.FirstName = person.FirstName;
            data.DateOfBirth = person.DateOfBirth;
            data.IdNumber = person.IdNumber;
            data.MaleOrFemale = person.MaleOrFemale;
            data.Hmoid = person.Hmoid;
            return await dataServices.AddDataAsync(data);
        }
        [HttpPut("{idNumber}/{mOf}/{hmoid}")]
        public async Task<PersonDto> Put(string idNumber,bool mOf,int hmoid)
        {
            return await dataServices.UpdateDataAsync(idNumber, mOf,hmoid);
        }
    }
}
