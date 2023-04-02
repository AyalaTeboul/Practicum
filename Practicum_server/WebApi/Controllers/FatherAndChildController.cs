using Common.Dto_s;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FatherAndChildController : ControllerBase
    {
        private readonly IDataService<FatherAndChildDto> dataServices;
        public FatherAndChildController(IDataService<FatherAndChildDto> dataServices)
        {
            this.dataServices = dataServices;
        }
        // GET: api/<PersonController>
        [HttpGet]
        public async Task<List<FatherAndChildDto>> Get()
        {
            return await dataServices.GetAllAsync();
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<FatherAndChildDto> Post([FromBody] FatherAndChildModel person)
        {
            FatherAndChildDto data = new FatherAndChildDto();
           data.ChildId= person.ChildId;
            data.FatherId= person.FatherId;
            data.MotherId= person.MotherId;
            return await dataServices.AddDataAsync(data);
        }
       
    }
}
