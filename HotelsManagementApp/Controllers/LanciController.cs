using HotelsManagementApp.Interfaces;
using HotelsManagementApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelsManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanciController : ControllerBase
    {
        private readonly ILanacHotelaRepository _lanacHotelaRepository;

        public LanciController(ILanacHotelaRepository lanacHotelaRepository)
        {
            _lanacHotelaRepository = lanacHotelaRepository;
        }

        [HttpGet]
        public IActionResult GetLanci()
        {
            return Ok(_lanacHotelaRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetLanac(int id)
        {
            var lanac = _lanacHotelaRepository.GetById(id);

            if (lanac == null)
            {
                return BadRequest();
            }

            return Ok(lanac);
        }

        [HttpGet]
        [Route("/api/tradicija")]
        public IActionResult GetOldestTwo()
        {
            return Ok(_lanacHotelaRepository.GetOldestTwo());
        }

    }
}
