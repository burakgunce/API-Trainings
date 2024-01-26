using HastaneApi.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HastaneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HastalarController : ControllerBase
    {
        private readonly HastaneDbContext db;

        public HastalarController(HastaneDbContext _db)
        {
            db = _db;
        }

        //[HttpGet("getallwithhastaneler")]
        //public IActionResult GetAllWithHospitals() //DTO 1 kullan
        //{

        //}

        //[HttpGet("getallwithhastanename")]
        //public IActionResult GetAllWithHospitalNames() //DTO 2 kullan
        //{

        //}


    }
}
