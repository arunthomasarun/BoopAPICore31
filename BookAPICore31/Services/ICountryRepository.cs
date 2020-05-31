using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPICore31.Models;

namespace BookAPICore31.Services
{
    public interface ICountryRepository
    {
        Task<ICollection<Country>> GetCountries();
        Task<Country> GetCountry(int countryId);
        Task<Country> GetCountryOfAnAuthor(int authorId);
        Task<ICollection<Author>> GetAuthorsFromACountry(int countryId);
        Task<Boolean> CountryExists(int countryId);

    }
}
