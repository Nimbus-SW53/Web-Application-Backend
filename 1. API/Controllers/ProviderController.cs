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
    public class ProviderController : ControllerBase
    {
        private IProviderData _providerData;
        private IProviderDomain _providerDomain;
        private IMapper _mapper;

        public ProviderController(IProviderData providerData, IProviderDomain providerDomain, IMapper mapper)
        {
            _providerData = providerData;
            _providerDomain = providerDomain;
            _mapper = mapper;
        }
        
        
        // GET: api/Provider
        /// <summary>
        ///  Get all providers without any filters
        /// </summary>
        [HttpGet]
        [Produces("aplication/json")]
        public async Task<List<ProviderResponse>> GetAsync()
        {
            var providers = await _providerData.GetAllAsync();
            var response = _mapper.Map<List<Provider>, List<ProviderResponse>>(providers);
            return response;
        }

        // GET: api/Provider/5
        /// <summary>
        /// Get a provider by its ID.
        /// </summary>
        [HttpGet("{id}", Name = "GetProvider")]
        [Produces("application/json")]
        public Provider GetProvider(int id)
        {
            return _providerData.GetById(id);
        }

        // POST: api/Provider
        /// <summary>
        /// Create a new provider.
        /// </summary>
        /// <response code="200">Returns the newly created provider</response>
        /// <response code="400">If the provider is null or the required fields are empty</response>
        /// <response code="500">Unexpected error, maybe database is down</response>
        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post([FromBody] ProviderRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var provider = _mapper.Map<ProviderRequest, Provider>(request);
                    return Ok( _providerDomain.Create(provider));
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

        // PUT: api/Provider/5
        /// <summary>
        /// Update an existing provider.
        /// </summary>
        [HttpPut("{id}")]
        [Produces("application/json")]
        public bool Put(int id, [FromBody] ProviderRequest request)
        {
            Provider provider = new Provider()
            {
                Name = request.Name,
                UrlLogo = request.UrlLogo
            };
            return _providerDomain.Update(provider, id);
        }

        // DELETE: api/Provider/5
        /// <summary>
        /// Delete a provider by its ID.
        /// </summary>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        public bool Delete(int id)
        {
            return _providerDomain.Delete(id);
        }
    }
}
