using _3._Data;
using _3._Data.Model;
namespace _2._Domain;

public class ProductDomain: IProductDomain
{
    private IProductData _productData;


    public ProductDomain(IProductData productData)
    {
        _productData = productData;
    }
    
    public bool Create(Product product)
    {
        if (product.Price <= 0) throw new Exception("Price must be greater than 0");
        var existingProduct = _productData.GetBySoftwareName(product.SoftwareName);
        
        if (existingProduct == null)
        {
            return _productData.Create(product);
        }
        else
        {
            return false;
        }
    }

    public bool Update(Product product, int id)
    {
        var existingProduct = _productData.GetBySoftwareName(product.SoftwareName);
        
        if (existingProduct == null)
        {
            return _productData.Update(product, id);
        }
        else
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        var product = _productData.GetById(id);

        if (product != null)
        {
            return _productData.Delete(id);
        }
        else
        {
            return false;
        }
    }
}