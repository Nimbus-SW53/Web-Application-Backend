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
    public class ReviewController : ControllerBase
    {
        private IReviewData _reviewData;
        private IReviewDomain _reviewDomain;
        private IMapper _mapper;

        public ReviewController(IReviewData reviewData,IReviewDomain reviewDomain, IMapper mapper)
        {
            _reviewData = reviewData;
            _reviewDomain = reviewDomain;
            _mapper = mapper;
        }
        
        
        // GET: api/Review
        /// <summary>
        ///  Get all software product reviews without filters
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<List<ReviewResponse>> GetAsync()
        {
            var reviews = await _reviewData.GetAllAsync();
            var response = _mapper.Map<List<Review>, List<ReviewResponse>>(reviews);
            return response;
        }

        // GET: api/Review/5
        /// <summary>
        /// Get a software product review by its ID.
        /// </summary>
        [HttpGet("{id}", Name = "GetReview")]
        [Produces("application/json")]
        public Review GetReview(int id)
        {
            return _reviewData.GetById(id);
        }

        // POST: api/Review
        /// <summary>
        /// Create a new software product review.
        /// </summary>
        /// <response code="200">Returns newly created reviews of software products.</response>
        /// <response code="400">If the review is null or the required fields are empty</response>
        /// <response code="500">Unexpected error, maybe database is down</response>
        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post([FromBody] ReviewRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var review = _mapper.Map<ReviewRequest, Review>(request);
                    return Ok( _reviewDomain.Create(review));
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

        // PUT: api/Review/5
        /// <summary>
        /// Update an existing software product review.
        /// </summary>
        [HttpPut("{id}")]
        [Produces("application/json")]
        public bool Put(int id, [FromBody] ReviewRequest request)
        {
            Review review = new Review()
            {
                Score = request.Score,
                Description = request.Description,
                UserId = request.UserId,
                ProductId = request.ProductId
            };
            return _reviewDomain.Update(review, id);
        }

        // DELETE: api/Review/5
        /// <summary>
        /// Delete a software product review by its ID.
        /// </summary>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        public bool Delete(int id)
        {
            return _reviewDomain.Delete(id);
        }
    }
}
