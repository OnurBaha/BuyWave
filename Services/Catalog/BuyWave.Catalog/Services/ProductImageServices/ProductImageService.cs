using AutoMapper;
using BuyWave.Catalog.Dtos.ProductImageDtos;
using BuyWave.Catalog.Entities;
using BuyWave.Catalog.Services.ProductImageServices;
using BuyWave.Catalog.Settings;
using MongoDB.Driver;

namespace BuyWave.Catalog.Services.ProductImageServices;

public class ProductImageService: IProductImageService
{
    private readonly IMongoCollection<ProductImage> _ProductImageCollection;
    private readonly IMapper _mapper;

    public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _ProductImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
        _mapper = mapper;
    }

    public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
    {
        var values = _mapper.Map<ProductImage>(createProductImageDto);
        await _ProductImageCollection.InsertOneAsync(values);
    }

    public async Task DeleteProductImageAsync(string id)
    {
        await _ProductImageCollection.DeleteOneAsync(x => x.ProductImageID == id);
    }

    public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
    {
        var values = await _ProductImageCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductImageDto>>(values);
    }

    public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
    {
        var values = _ProductImageCollection.Find<ProductImage>(x => x.ProductImageID == id);
        return _mapper.Map<GetByIdProductImageDto>(values);
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
    {
        var values = _mapper.Map<ProductImage>(updateProductImageDto);
        await _ProductImageCollection.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImageDto.ProductImageID, values);

    }
}
