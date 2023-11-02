using _3._Data;
using _3._Data.Model;
namespace _2._Domain;

public class ReviewDomain: IReviewDomain
{
    private IReviewData _reviewData;
    private IUserData _userData;
    private IProductData _productData;

    public ReviewDomain(IReviewData reviewData,IUserData userData, IProductData productData)
    {
        _reviewData = reviewData;
        _userData = userData;
        _productData = productData;
    }

    public bool Create(Review review)
    {
        if (review.Score <=0 || review.Score > 5) throw new Exception("The score must be between 1 and 5");

        var user = _userData.GetById(review.UserId);
        var product = _productData.GetById(review.ProductId);

        if (user != null && product != null)
        {
            return _reviewData.Create(review);
        }
        else
        {
            return false;
        }
    }

    public bool Update(Review review, int id)
    {
        var existingReview = _reviewData.GetById(id);

        if (existingReview == null)
        {
            return false;
        }
        
        if (review.Score <=0 || review.Score > 5) throw new Exception("The score must be between 1 and 5");
        
        var user = _userData.GetById(review.UserId);
        var product = _productData.GetById(review.ProductId);
        
        if (user != null && product != null)
        {
            return _reviewData.Update(review, id);
        }
        else
        {
            return false;
        }
        
    }

    public bool Delete(int id)
    {
        var review = _reviewData.GetById(id);

        if (review != null)
        {
            return _reviewData.Delete(id);
        }
        else
        {
            return false;
        }
    }
}