using AutoMapper;
using BuyWave.Catalog.Dtos.CategoryDtos;
using BuyWave.Catalog.Dtos.ProductDetailDtos;
using BuyWave.Catalog.Dtos.ProductDtos;
using BuyWave.Catalog.Dtos.ProductImageDtos;
using BuyWave.Catalog.Entities;

namespace BuyWave.Catalog.Mapping;

public class GeneralMapping:Profile
{
    public GeneralMapping()
    {
        //------------------CATEGORY-----------------------
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, GetByIdCategoryDto>().ReverseMap();


        //-----------------PRODUCT---------------------------
        CreateMap<Product, ResultProductDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, GetByIdProductDto>().ReverseMap();


        //-----------------PRODUCT-DETAİL---------------------------
        CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();



        //-----------------PRODUCT-IMAGE---------------------------
        CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
        CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
        CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
        CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();

    }
}
