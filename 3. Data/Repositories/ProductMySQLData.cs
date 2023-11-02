using _3._Data.Context;
using _3._Data.Model;
using Microsoft.EntityFrameworkCore;
namespace _3._Data.Repositories;

public class ProductMySQLData : IProductData
{
    private NimbusDB _nimbusDb;

    public ProductMySQLData(NimbusDB nimbusDb)
    {
        _nimbusDb = nimbusDb;
    }
    
    public Product GetById(int id)
    {
        return _nimbusDb.Products.Where(p => p.Id == id && p.IsActive).First();
    }

    public Product GetBySoftwareName(string name)
    {
        return _nimbusDb.Products.Where(p => p.SoftwareName == name && p.IsActive).FirstOrDefault();
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _nimbusDb.Products.Where(p => p.IsActive).ToListAsync();
    }

    public async Task<List<Product>> GetAllByCategoryAsync(int categoryId)
    {
        return await _nimbusDb.Products.Where(p =>  p.CategoryId == categoryId && p.IsActive).ToListAsync();
    }

    public async Task<List<Product>> GetAllByPriceAsync(decimal price)
    {
        return await _nimbusDb.Products.Where(p =>  p.Price == price && p.IsActive).ToListAsync();

    }

    public async Task<List<Product>> GetAllByCategoryAndPriceAsync(int categoryId, decimal price)
    {
        return await _nimbusDb.Products.Where(p => p.CategoryId == categoryId && p.Price == price && p.IsActive).ToListAsync();
    }

    public bool Create(Product product)
    {
        try
        {
            _nimbusDb.Products.Add(product);
            _nimbusDb.SaveChanges();
            return true;
        }
        catch (Exception error)
        {
            return false;
        }
    }

    public bool Update(Product product, int id)
    {
        try
        {
            var productToBeUpdated = _nimbusDb.Products.Where(p => p.Id == id).First();

            productToBeUpdated.SoftwareName = product.SoftwareName;
            productToBeUpdated.Price = product.Price;
            productToBeUpdated.Description = product.Description;
            productToBeUpdated.UrlImagePreview = product.UrlImagePreview;
            productToBeUpdated.CategoryId = product.CategoryId;
            productToBeUpdated.DateUpdate = DateTime.Now;
            
            _nimbusDb.Products.Update(productToBeUpdated);
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
            var productToBeUpdated = _nimbusDb.Products.Where(p => p.Id == id).First();
            
            productToBeUpdated.DateUpdate = DateTime.Now;
            productToBeUpdated.IsActive = false;
            
            _nimbusDb.Products.Update(productToBeUpdated);
            _nimbusDb.SaveChanges();
            
            return true;
        }
        catch (Exception error)
        {
            return false;
        }
    }
}