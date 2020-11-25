using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBotTelegram.Infra.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBotTelegram.Controllers
{
    [EnableCors("AllowCors"), Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly CountryRepository _countryRepository;

        public CountryController()
        {
            _countryRepository = new CountryRepository();
        }

        [HttpGet("", Name = "GetCountries")]
        public IActionResult GetBooks()
        {
            var response = _countryRepository.GetAvailableCountries();            
            return Ok(response);
        }

        [HttpGet("{CountryName}", Name = "GetCountryByName")]
        public IActionResult GetBookById(string CountryName)
        {
            try
            {
                var response = _countryRepository.GetCountryByName(CountryName);
                return Ok(response);

            } catch (Exception e)
            {
                return BadRequest(e);
            }       
        }
    }
}