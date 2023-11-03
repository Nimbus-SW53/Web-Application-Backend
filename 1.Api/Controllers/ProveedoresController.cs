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
        
        public ProveedoresController(IProveedorData proveedorData, IProveedorDomain proveedorDomain)
        {
            _proveedorData = proveedorData;
            _proveedorDomain = proveedorDomain;
        }

        // GET: api/Proveedores
        /// <summary>
        /// Obtiene todos los proveedores sin ningún filtro.
        /// </summary>
        [HttpGet]
        public List<Proveedores> Get()
        {
            // Recupera y devuelve una lista de todos los proveedores
            return _proveedorData.GetAll();
        }

        // GET: api/Proveedores/5
        [HttpGet("{id}", Name = "Get")]
        public Proveedores Get(int id)
        {
            // Obtiene un proveedor por su ID y lo devuelve
            return _proveedorData.GetById(id);
        }

        // POST: api/Proveedores
        [HttpPost]
        public bool Post([FromBody] ProveedoresRequest request)
        {
            if (request == null)
            {
                return false;
            }

            // Crea un objeto Proveedores a partir de la solicitud
            Proveedores proveedores = new Proveedores()
            {
                Name = request.Name,
                Year = request.Year,
                Cost = request.Cost
            };

            // Llama al dominio para crear un nuevo proveedor
            return _proveedorDomain.Create(proveedores);
        }

        // PUT: api/Proveedores/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] ProveedoresRequest request)
        {
            if (request == null)
            {
                return false;
            }

            // Crea un objeto Proveedores a partir de la solicitud
            Proveedores proveedores = new Proveedores()
            {
                Name = request.Name,
                Year = request.Year,
                Cost = request.Cost
            };

            // Llama al dominio para actualizar el proveedor por su ID
            return _proveedorDomain.Update(proveedores, id);
        }

        // DELETE: api/Proveedores/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Implementa la lógica para eliminar un proveedor por su ID
            // Puede eliminarlo de la fuente de datos o marcarlo como eliminado según su lógica de negocio
        }
    }
}
