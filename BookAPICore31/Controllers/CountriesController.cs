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


        //api/countries/{countryId}
        [HttpGet("{countryId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountryDTO))]
        public async Task<IActionResult> GetCountry(int countryId)
        {
            if (!await _countryRepository.CountryExists(countryId))
                return StatusCode(StatusCodes.Status404NotFound);

            var countries = await _countryRepository.GetCountry(countryId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var countriesDto = new CountryDTO() {
                Id = countries.Id,
                Name = countries.Name
            };
            

            return Ok(countriesDto);
        }


        //api/countries/Authors/{authorId}
        [HttpGet("Authors/{authorId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountryDTO))]
        public async Task<IActionResult> GetCountryOfAnAuthor(int authorId)
        {            

            var countries = await _countryRepository.GetCountryOfAnAuthor(authorId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countriesDto = new CountryDTO()
            {
                Id = countries.Id,
                Name = countries.Name
            };

            return Ok(countriesDto);
        }
    }
}
