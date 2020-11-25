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
    public class CountrySituationController : Controller
    {
        private readonly CountrySituationRepository _countrySituationRepository;

        public CountrySituationController()
        {
            _countrySituationRepository = new CountrySituationRepository();
        }

        [HttpGet("", Name = "GetAllCountriesSituation")]
        public IActionResult GetAllCountriesSituation()
        {
            var response = _countrySituationRepository.GetAllCountriesSituation();            
            return Ok(response);
        }

        [HttpGet("{CountryName}", Name = "GetCountryDataByName")]
        public IActionResult GetCountryDataByName(string CountryName)
        {
            try
            {
                var response = _countrySituationRepository.GetCountryDataByName(CountryName);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}