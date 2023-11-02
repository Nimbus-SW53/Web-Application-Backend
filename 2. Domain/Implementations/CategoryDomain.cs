using _3._Data;
using _3._Data.Model;
namespace _2._Domain;

public class CategoryDomain: ICategoryDomain
{
    private ICategoryData _categoryData;

    public CategoryDomain(ICategoryData categoryData)
    {
        _categoryData = categoryData;
    }
    
    public bool Create(Category category)
    {
        var existingCategory = _categoryData.GetByName(category.CategoryName);

        if (existingCategory == null)
        {
            return _categoryData.Create(category);
        }
        else
        {
            return false;
        }

    }

    public bool Update(Category category, int id)
    {
        var existingCategory = _categoryData.GetByName(category.CategoryName);
        
        if (existingCategory == null)
        {
            return _categoryData.Update(category, id);
        }
        else
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        var category = _categoryData.GetById(id);

        if (category != null)
        {
            return _categoryData.Delete(id);
        }
        else
        {
            return false;
        }
    }
}