using _3._Data.Context;
using _3._Data.Model;
using Microsoft.EntityFrameworkCore;
namespace _3._Data.Repositories;

public class ReviewMySQLData: IReviewData
{
    private NimbusDB _nimbusDb;
    
    public ReviewMySQLData(NimbusDB nimbusDb)
    {
        _nimbusDb = nimbusDb;
    }
    
    public Review GetById(int id)
    {
        return _nimbusDb.Reviews.Where(r => r.Id == id && r.IsActive).First();
    }

    public async Task<List<Review>> GetAllAsync()
    {
        return await _nimbusDb.Reviews.Where(r => r.IsActive).ToListAsync();
    }

    public async Task<List<Review>> GetAllByScoreAsync(float score)
    {
        return await _nimbusDb.Reviews.Where(r => r.Score == score && r.IsActive).ToListAsync();
    }

    public async Task<List<Review>> GetAllByScoreAndProductIdAsync(float score, int productId)
    {
        return await _nimbusDb.Reviews.Where(r => r.Score == score && r.ProductId == productId && r.IsActive).ToListAsync();
    }

    public async Task<List<Review>> GetAllByUserIdAndProductIdAsync(int userId, int productId)
    {
        return await _nimbusDb.Reviews.Where(r => r.UserId == userId && r.ProductId == productId && r.IsActive).ToListAsync();
    }

    public async Task<List<Review>> GetAllByUserIdAndProductIdAndScoreAsync(int userId, int productId, float score)
    {
        return await _nimbusDb.Reviews.Where(r => r.UserId == userId && r.ProductId == productId && r.Score == score && r.IsActive).ToListAsync();
    }

    public bool Create(Review review)
    {
        try
        {
            _nimbusDb.Reviews.Add(review);
            _nimbusDb.SaveChanges();
            return true;
        }
        catch (Exception error)
        {
            return false;
        }
    }

    public bool Update(Review review, int id)
    {
        try
        {
            var reviewToBeUpdated = _nimbusDb.Reviews.Where(r => r.Id == id).First();

            reviewToBeUpdated.Score = review.Score;
            reviewToBeUpdated.Description = review.Description;
            reviewToBeUpdated.UserId = review.UserId;
            reviewToBeUpdated.ProductId = review.ProductId;
            reviewToBeUpdated.DateUpdate = DateTime.Now;
            
            _nimbusDb.Reviews.Update(reviewToBeUpdated);
            _nimbusDb.SaveChanges();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            var reviewToBeUpdated = _nimbusDb.Reviews.Where(r => r.Id == id).First();
            
            reviewToBeUpdated.DateUpdate = DateTime.Now;
            reviewToBeUpdated.IsActive = false;
            
            _nimbusDb.Reviews.Update(reviewToBeUpdated);
            _nimbusDb.SaveChanges();
            
            return true;
        }
        catch (Exception error)
        {
            return false;
        }
    }
}