using BookAPICore31.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPICore31.Services
{
    public class CountryRepository : ICountryRepository
    {
        private readonly BookDbContext _dbContext;

        public CountryRepository(BookDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<bool> CountryExists(int countryId)
        {
            return await _dbContext.Countries.AnyAsync(c => c.Id == countryId);
        }

        public async Task<ICollection<Author>> GetAuthorsFromACountry(int countryId)
        {
            return await _dbContext.Authors.Where(a => a.Country.Id == countryId).ToListAsync();
        }

        public async Task<ICollection<Country>> GetCountries()
        {
            return await _dbContext.Countries.OrderBy(c=> c.Name).ToListAsync();
        }

        public async Task<Country> GetCountry(int countryId)
        {
            return await _dbContext.Countries.FirstOrDefaultAsync(c => c.Id == countryId);
        }

        public async Task<Country> GetCountryOfAnAuthor(int authorId)
        {
            return await _dbContext.Authors.Where(a => a.Id == authorId).Select(a => a.Country).FirstOrDefaultAsync();
        }
    }
}
