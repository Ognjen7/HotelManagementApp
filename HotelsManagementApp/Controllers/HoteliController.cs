using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelsManagementApp.Interfaces;
using HotelsManagementApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HotelsManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoteliController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HoteliController(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/zaposleni")]
        public IActionResult GetAllWithAverageEmployee()
        {
            return Ok(_hotelRepository.GetAllWithAverageEmployees().ToList());
        }

        [HttpGet]
        public IActionResult GetHoteli()
        {
            return Ok(_hotelRepository.GetAll().ProjectTo<HotelDTO>(_mapper.ConfigurationProvider).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetHotel(int id)
        {
            var hotel = _hotelRepository.GetById(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<HotelDTO>(hotel));
        }

        [HttpPost]
        public IActionResult PostHotel(Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _hotelRepository.Add(hotel);
            return CreatedAtAction("GetHotel", new { id = hotel.Id }, _mapper.Map<HotelDTO>(hotel));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            var slika = _hotelRepository.GetById(id);
            if (slika == null)
            {
                return NotFound();
            }

            _hotelRepository.Delete(slika);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutHotel(int id, Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotel.Id)
            {
                return BadRequest();
            }

            try
            {
                _hotelRepository.Update(hotel);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(hotel);
        }

        [HttpGet("zaposleni")]
        public IActionResult GetByEmployeeCount([FromQuery] int minimum)
        {
            var hoteli = _hotelRepository.GetByEmployeeCount(minimum);

            if (hoteli == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<HotelDTO>>(hoteli));
        }

        [HttpPost]
        [Route("/api/kapacitet")]
        public IActionResult Search(SearchDTO dto)
        {
            if (dto.Najmanje < 0 || dto.Najvise < 0 || dto.Najmanje > dto.Najvise)
            {
                return BadRequest();
            }
            return Ok(_hotelRepository.GetAllBySearchParams(dto.Najmanje, dto.Najvise).ProjectTo<HotelDTO>(_mapper.ConfigurationProvider).ToList());
        }

    }
}
