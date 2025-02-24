using AutoMapper;
using Commercium.Data.Interfaces;
using Commercium.Entity;
using Commercium.Service.Interfaces;
using Commercium.Shared.CategoryRMs;
using Commercium.Shared.ProductRMs;
using Commercium.Shared.ReturnRMs;
using Microsoft.EntityFrameworkCore;

public class CategoryService : ICategoryService
{
    private readonly IGenericManager<Category> _categoryManager;
    private readonly IGenericManager<Product> _productManager;
    private readonly ITransactionManager _transactionManager;
    private readonly IMapper _mapper;

    public CategoryService(
        IGenericManager<Category> categoryManager,
        IGenericManager<Product> productManager,
        ITransactionManager transactionManager,
        IMapper mapper)
    {
        _categoryManager = categoryManager;
        _productManager = productManager;
        _transactionManager = transactionManager;
        _mapper = mapper;
    }

    //  Kategori ID'ye göre getir
    public async Task<ReturnRM<CategoryRM>> GetCategoryByIdAsync(int categoryId)
    {
        var category = await _categoryManager.GetAsync(
            x => x.CategoryId == categoryId,
            x => x.Include(c => c.ProductCategories));

        if (category == null)
        {
            return ReturnRM<CategoryRM>.Fail("Kategori bulunamadı.", 404);
        }

        var categoryRM = _mapper.Map<CategoryRM>(category);
        return ReturnRM<CategoryRM>.Success(categoryRM, 200);
    }

    //  Tüm kategorileri getir
    public async Task<ReturnRM<IEnumerable<CategoryRM>>> GetAllCategoriesAsync()
    {
        var categories = await _categoryManager.GetAllAsync(
            includes: x => x.Include(c => c.ProductCategories));

        if (categories == null || !categories.Any())
        {
            return ReturnRM<IEnumerable<CategoryRM>>.Fail("Hiç kategori bulunamadı.", 404);
        }

        var categoryRMs = _mapper.Map<IEnumerable<CategoryRM>>(categories);
        return ReturnRM<IEnumerable<CategoryRM>>.Success(categoryRMs, 200);
    }

    //  Yeni kategori oluştur
    public async Task<ReturnRM<string>> CreateCategoryAsync(CreateCategoryRM createCategoryRM)
    {
        var category = _mapper.Map<Category>(createCategoryRM);

        await _categoryManager.AddAsync(category);
        var save = await _transactionManager.SaveAsync();

        if (save <= 0)
        {
            return ReturnRM<string>.Fail("Kategori oluşturulamadı.", 500);
        }

        return ReturnRM<string>.Success("Kategori başarıyla oluşturuldu.", 201);
    }

    //  Kategori bilgilerini güncelle
    public async Task<ReturnRM<string>> UpdateCategoryAsync(UpdateCategoryRM updateCategoryRM)
    {
        var category = await _categoryManager.GetByIdAsync(updateCategoryRM.CategoryId);

        if (category == null)
        {
            return ReturnRM<string>.Fail("Kategori bulunamadı.", 404);
        }

        _mapper.Map(updateCategoryRM, category);
        _categoryManager.Update(category);
        var save = await _transactionManager.SaveAsync();

        if (save <= 0)
        {
            return ReturnRM<string>.Fail("Kategori güncellenemedi.", 500);
        }

        return ReturnRM<string>.Success("Kategori başarıyla güncellendi.", 200);
    }

    //  Kategoriyi sil
    public async Task<ReturnRM<string>> DeleteCategoryAsync(int categoryId)
    {
        var category = await _categoryManager.GetByIdAsync(categoryId);

        if (category == null)
        {
            return ReturnRM<string>.Fail("Kategori bulunamadı.", 404);
        }

        _categoryManager.Delete(category);
        var save = await _transactionManager.SaveAsync();

        if (save <= 0)
        {
            return ReturnRM<string>.Fail("Kategori silinemedi.", 500);
        }

        return ReturnRM<string>.Success("Kategori başarıyla silindi.", 200);
    }

    //  Kategoriye bağlı ürünleri getir
    public async Task<ReturnRM<IEnumerable<ProductRM>>> GetProductsByCategoryAsync(int categoryId)
    {
        var products = await _productManager.GetAllAsync(
            x => x.ProductCategories.Any(pc => pc.CategoryId == categoryId),
            includes: x => x.Include(p => p.BusinessProfile)
                            .Include(p => p.ProductTags)
                            .Include(p => p.Reviews));

        if (products == null || !products.Any())
        {
            return ReturnRM<IEnumerable<ProductRM>>.Fail("Bu kategoriye ait ürün bulunamadı.", 404);
        }

        var productRMs = _mapper.Map<IEnumerable<ProductRM>>(products);
        return ReturnRM<IEnumerable<ProductRM>>.Success(productRMs, 200);
    }

    //  Kategorilere göre ürün sayısını getir
    public async Task<ReturnRM<int>> GetProductCountByCategoryAsync(int categoryId)
    {
        var productCount = await _productManager.CountAsync(x => x.ProductCategories.Any(pc => pc.CategoryId == categoryId));

        return ReturnRM<int>.Success(productCount, 200);
    }

    //  En popüler kategorileri getir (ürün sayısına göre sıralı)
    public async Task<ReturnRM<IEnumerable<CategoryRM>>> GetTopCategoriesAsync(int count)
    {
        var topCategories = await _categoryManager.GetTopAsync(
            count,
            orderBy: q => q.OrderByDescending(c => c.ProductCategories.Count),
            includes: x => x.Include(c => c.ProductCategories));

        if (topCategories == null || !topCategories.Any())
        {
            return ReturnRM<IEnumerable<CategoryRM>>.Fail("Popüler kategori bulunamadı.", 404);
        }

        var categoryRMs = _mapper.Map<IEnumerable<CategoryRM>>(topCategories);
        return ReturnRM<IEnumerable<CategoryRM>>.Success(categoryRMs, 200);
    }
}
