using _3._Data.Model;
namespace _3._Data;

public interface IReviewData
{
    Review GetById(int id);
    
    Task<List<Review>> GetAllAsync();
    Task<List<Review>> GetAllByScoreAsync(float score);
    Task<List<Review>> GetAllByScoreAndProductIdAsync(float score, int productId);
    Task<List<Review>> GetAllByUserIdAndProductIdAsync(int userId, int productId);
    Task<List<Review>> GetAllByUserIdAndProductIdAndScoreAsync(int userId, int productId, float score);
    
    bool Create(Review review);
    bool Update(Review review,int id);
    bool Delete(int id);
}