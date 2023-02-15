using Common.Dto_s;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HmoController : ControllerBase
    {
        private readonly IDataService<HmoDto> dataServices;
        public HmoController(IDataService<HmoDto> dataServices)
        {
            this.dataServices = dataServices;
        }
        // GET: api/<PersonController>
        [HttpGet]
        public async Task<List<HmoDto>> Get()
        {
            List<HmoDto> l = await dataServices.GetAllAsync();
            return await dataServices.GetAllAsync();
        }
       
        [HttpPost]
        public async Task<HmoDto> Post([FromBody] HmoModel person)
        {
            HmoDto data = new HmoDto();
            data.Hmoname = person.Hmoname;
            return await dataServices.AddDataAsync(data);
        }

    }
}
