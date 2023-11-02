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
    public class UserController : ControllerBase
    {
        private IUserData _userData;
        private IUserDomain _userDomain;
        private IMapper _mapper;

        public UserController(IUserData userData, IUserDomain userDomain, IMapper mapper)
        {
            _userData = userData;
            _userDomain = userDomain;
            _mapper = mapper;
        }
        
        
        // GET: api/User
        /// <summary>
        ///  Get all users without filters
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<List<UserResponse>> GetAsync()
        {
            var users = await _userData.GetAllAsync();
            var response = _mapper.Map<List<User>, List<UserResponse>>(users);
            return response;
        }

        // GET: api/User/5
        /// <summary>
        /// Get a user by their ID.
        /// </summary>
        [HttpGet("{id}", Name = "GetUser")]
        [Produces("application/json")]
        public User GetUser(int id)
        {
            return _userData.GetById(id);
        }

        // POST: api/User
        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <response code="200">Returns newly created users.</response>
        /// <response code="400">If the user is null or the required fields are empty</response>
        /// <response code="500">Unexpected error, maybe database is down</response>
        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post([FromBody] UserRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _mapper.Map<UserRequest, User>(request);
                    return Ok( _userDomain.Create(user));
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

        // PUT: api/User/5
        /// <summary>
        /// Update an existing user.
        /// </summary>
        [HttpPut("{id}")]
        [Produces("application/json")]
        public bool Put(int id, [FromBody] UserRequest request)
        {
            User user = new User()
            {
                FullName = request.FullName,
                UserName = request.UserName,
                UrlAvatar = request.UrlAvatar,
                Email = request.Email,
                Password = request.Password
            };
            return _userDomain.Update(user, id);
        }

        // DELETE: api/User/5
        /// <summary>
        /// Delete a user by their ID.
        /// </summary>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        public bool Delete(int id)
        {
            return _userDomain.Delete(id);
        }
    }
}
