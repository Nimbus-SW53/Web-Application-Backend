using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1._API.Request;
using _1._API.Response;
using _2._Domain;
using _3._Data;
using _3._Data.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryData _categoryData;
        private ICategoryDomain _categoryDomain;
        private IMapper _mapper;

        public CategoryController(ICategoryData categoryData, ICategoryDomain categoryDomain, IMapper mapper)
        {
            _categoryData = categoryData;
            _categoryDomain = categoryDomain;
            _mapper = mapper;
        }
        
        
        // GET: api/Category
        /// <summary>
        ///  Get all categories without filters
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<List<CategoryResponse>> GetAsync()
        {
            var categories = await _categoryData.GetAllAsync();
            var response = _mapper.Map<List<Category>, List<CategoryResponse>>(categories);
            return response;
        }

        // GET: api/Category/5
        /// <summary>
        ///     Get a category by its ID.
        /// </summary>
        [HttpGet("{id}", Name = "GetCategory")]
        [Produces("application/json")]
        public Category GetCategory(int id)
        {
            return _categoryData.GetById(id);
        }

        // POST: api/Category
        /// <summary>
        /// Create a new category.
        /// </summary>
        /// <response code="200">Returns newly created category.</response>
        /// <response code="400">If the category is null or the required fields are empty</response>
        /// <response code="500">Unexpected error, maybe database is down</response>
        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post([FromBody] CategoryRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var category = _mapper.Map<CategoryRequest, Category>(request);
                    return Ok( _categoryDomain.Create(category));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Category/5
        /// <summary>
        ///     Update an existing category.
        /// </summary>
        [HttpPut("{id}")]
        [Produces("application/json")]
        public bool Put(int id, [FromBody] CategoryRequest request)
        {
            Category category = new Category()
            {
                CategoryName = request.CategoryName
            };
            return _categoryDomain.Update(category, id);
        }

        // DELETE: api/Category/5
        /// <summary>
        ///     Delete a category by its ID.
        /// </summary>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        public bool Delete(int id)
        {
            return _categoryDomain.Delete(id);
        }
    }
}
