using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPICore31.DTOS;
using BookAPICore31.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPICore31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        //api/categories
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryDTO>))]
        public async Task<IActionResult> GetCountries()
        {
            var categories = await _categoryRepository.GetCategories();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoriesDTO = new List<CategoryDTO>();
            foreach (var cat in categories)
            {
                categoriesDTO.Add(new CategoryDTO()
                {
                    Id = cat.Id,
                    Name = cat.Name
                });
            }

            return Ok(categoriesDTO);
        }


        //api/categories/{categoryId}
        [HttpGet("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDTO))]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            if (!await _categoryRepository.CategoryExists(categoryId))
                return StatusCode(StatusCodes.Status404NotFound);

            var category = await _categoryRepository.GetCategory(categoryId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var catDTO = new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name
            };


            return Ok(catDTO);
        }


        //api/categories/books/{bookId}
        [HttpGet("books/{bookId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryDTO>))]
        public async Task<IActionResult> GetAllCategoriesForABook(int bookId)
        {

            var categories = await _categoryRepository.GetAllCategoriesForABook(bookId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoriesDTO = new List<CategoryDTO>();
            foreach (var cat in categories)
            {
                categoriesDTO.Add(new CategoryDTO()
                {
                    Id = cat.Id,
                    Name = cat.Name
                });
            }

            return Ok(categoriesDTO);
        }
    }
}
