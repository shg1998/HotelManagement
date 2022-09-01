using System.Threading.Tasks;
using HotelManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers.v2
{
    [ApiVersion("2.0")]
    [Route("api/country")]
    [ApiController]
    public class CountryV2Controller : ControllerBase
    {
        private readonly DatabaseContext _ctx;

        public CountryV2Controller(DatabaseContext context)
        {
            _ctx = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountries() => Ok(_ctx.Countries);
    }
}
