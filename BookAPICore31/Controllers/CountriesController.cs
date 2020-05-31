using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPICore31.DTOS;
using BookAPICore31.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace BookAPICore31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            this._countryRepository = countryRepository;
        }

        //api/countries
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CountryDTO>))]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _countryRepository.GetCountries();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countriesDto = new List<CountryDTO>();
            foreach (var country in countries)
            { 
                countriesDto.Add(new CountryDTO()
                {
                    Id = country.Id,
                    Name = country.Name
                });                
            }

            return Ok(countriesDto);
        }
    }
}
