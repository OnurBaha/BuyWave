using AutoMapper;
using BuyWave.Catalog.Dtos.ProductDetailDtos;
using BuyWave.Catalog.Entities;
using BuyWave.Catalog.Settings;
using MongoDB.Driver;

namespace BuyWave.Catalog.Services.ProductDetailServices;

public class ProductDetailService: IProductDetailService
{
    private readonly IMongoCollection<ProductDetail> _ProductDetailCollection;
    private readonly IMapper _mapper;

    public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _ProductDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
        _mapper = mapper;
    }

    public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
    {
        var values = _mapper.Map<ProductDetail>(createProductDetailDto);
        await _ProductDetailCollection.InsertOneAsync(values);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await _ProductDetailCollection.DeleteOneAsync(x => x.ProductDetailID == id);
    }

    public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
    {
        var values = await _ProductDetailCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDetailDto>>(values);
    }

    public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
    {
        var values = _ProductDetailCollection.Find<ProductDetail>(x => x.ProductDetailID == id);
        return _mapper.Map<GetByIdProductDetailDto>(values);
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
    {
        var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
        await _ProductDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailID == updateProductDetailDto.ProductDetailID, values);

    }
}
