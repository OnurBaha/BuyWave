using AutoMapper;
using BuyWave.Catalog.Dtos.CategoryDtos;
using BuyWave.Catalog.Entities;
using BuyWave.Catalog.Settings;
using MongoDB.Driver;

namespace BuyWave.Catalog.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }

    public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        var value = _mapper.Map<Category>(createCategoryDto);
        await _categoryCollection.InsertOneAsync(value);
    }

    public async Task DeleteCategoryAsync(string id)
    {
        await _categoryCollection.DeleteOneAsync(x=>x.CategoryID == id);
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
    {
        var values = await _categoryCollection.Find(x=>true).ToListAsync();
        return _mapper.Map<List<ResultCategoryDto>>(values);
    }

    public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
    {
        var values = await _categoryCollection.Find<Category>(x=>x.CategoryID == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdCategoryDto>(values);
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        var values = _mapper.Map<Category>(updateCategoryDto); 
        await _categoryCollection.FindOneAndReplaceAsync(x=>x.CategoryID==updateCategoryDto.CategoryID, values); 
    }
}
