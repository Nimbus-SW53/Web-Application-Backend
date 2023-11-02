using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.Api.Request;
using _2.Domain;
using _3.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {

        private IProveedorData _proveedorData;
        private IProveedorDomain _proveedorDomain;
        
        public ProveedoresController(IProveedorData proveedorData,IProveedorDomain proveedorDomain)
        {
            _proveedorData = proveedorData;
            _proveedorDomain = proveedorDomain;
        }

        // GET: api/Tutorial
        /// <summary>
        /// Get all proveedores without any filters.
        /// </summary>
        [HttpGet]
        public List<Proveedores>Get()
        {
            return _proveedorData.GetAll();
        }

        // GET: api/Tutorial/5
        [HttpGet("{id}", Name = "Get")]
        public Proveedores Get(int id)
        {
            return _proveedorData.GetById(id);
        }
        // POST: api/Tutorial
        [HttpPost]
        public bool Post([FromBody] ProveedoresRequest request)
        {
           // ProveedorDomain proveedorDomain = new ProveedorDomain();
           Proveedores proveedores = new Proveedores()
           {
               Name = request.Name,
               Year = request.Year,
               Cost = request.Cost
               
           };
            return _proveedorDomain.Create(proveedores);
        }
        
        // PUT: api/Tutorial/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] ProveedoresRequest request)
        {
            Proveedores proveedores = new Proveedores()
            {
                Name = request.Name,
                Year = request.Year,
                Cost = request.Cost
               
            };
            return _proveedorDomain.Update(proveedores,id);
        }

        // DELETE: api/Tutorial/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }

    }
}
