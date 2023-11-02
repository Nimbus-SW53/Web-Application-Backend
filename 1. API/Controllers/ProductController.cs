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
    public class ProductController : ControllerBase
    {
        private IProductData _productData;
        private IProductDomain _productDomain;
        private IMapper _mapper;

        public ProductController(IProductData productData,IProductDomain productDomain, IMapper mapper)
        {
            _productData = productData;
            _productDomain = productDomain;
            _mapper = mapper;
        }
        
        // GET: api/Product
        /// <summary>
        ///  Get all software products without any filters
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<List<ProductResponse>> GetAsync()
        {
            var products = await _productData.GetAllAsync();
            var response = _mapper.Map<List<Product>, List<ProductResponse>>(products);
            return response;
        }
        
        // GET: api/Product/5
        /// <summary>
        /// Get a software product by its ID.
        /// </summary>
        [HttpGet("{id}", Name = "GetProduct")]
        [Produces("application/json")]
        public Product GetProduct(int id)
        {
            return _productData.GetById(id);
        }
        
        
        // POST: api/Product
        /// <summary>
        /// Create a new software product.
        /// </summary>
        /// <response code="200">Returns the newly created software product</response>
        /// <response code="400">If the software product is null or the required fields such as name, price, description or URL are empty</response>
        /// <response code="500">Unexpected error, maybe database is down</response>
        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post([FromBody] ProductRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = _mapper.Map<ProductRequest, Product>(request);
                    return Ok( _productDomain.Create(product));
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

        
        // PUT: api/Product/5
        /// <summary>
        /// Update an existing software product.
        /// </summary>
        [HttpPut("{id}")]
        [Produces("application/json")]
        public bool Put(int id, [FromBody] ProductRequest request)
        {
            Product product = new Product()
            {
                SoftwareName = request.SoftwareName,
                Price = request.Price,
                //UrlImages = request.UrlImages,
                Description = request.Description,
                UrlImagePreview = request.UrlImagePreview,
                CategoryId = request.CategoryId
            };
            return _productDomain.Update(product, id);
        }
        
        // DELETE: api/Product/5
        /// <summary>
        /// Delete a software product by its ID.
        /// </summary>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        public bool Delete(int id)
        {
            return _productDomain.Delete(id);
        }
    }
}
