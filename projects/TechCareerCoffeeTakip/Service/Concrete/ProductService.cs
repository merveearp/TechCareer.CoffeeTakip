using Core.Shared;
using DataAccess.Repositories.Abstract;
using Model.Dtos.Request;
using Model.Dtos.Response;
using Model.Entities;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Response<ProductResponse> Add(AddProductRequest request)
        {
            Product product = AddProductRequest.ConvertToEntity(request);

            product.Id = new Guid();

            _productRepository.Add(product);
             var data=ProductResponse.ConvertToResponse(product);
            return new Response<ProductResponse>()
            { 
                Data = data,
                Message="Ürün eklendi.",
                StatusCode = System.Net.HttpStatusCode.Created
  
            };
        }

        public Response<ProductResponse> Delete(Guid id)
        {
            var product = _productRepository.GetById(id);
            _productRepository.Delete(product);

            var data = ProductResponse.ConvertToResponse(product);
            return new Response<ProductResponse>()
            {
                Data= data,
                Message ="Ürün silindi.",
                StatusCode =System.Net.HttpStatusCode.OK
            };
        }

        public Response<List<ProductResponse>> GetAll()
        {
            var products = _productRepository.GetAll();
            var response = products.Select(x=> ProductResponse.ConvertToResponse(x)).ToList();
            return new Response<List<ProductResponse>>()
            {
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }

        public Response<List<ProductDetailDto>> GetAllDetails()
        {
            var details = _productRepository.GetAllProductDetails();
            return new Response<List<ProductDetailDto>>()
            {
                Data = details,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }

        public Response<List<ProductDetailDto>> GetAllDetailsByCoffeeId(int coffeeId)
        {
            var details = _productRepository.GetDetailsByCoffeeId(coffeeId);
            return new Response<List<ProductDetailDto>>()
            {
                Data = details,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }

        public Response<ProductDetailDto> GetByDetailId(Guid id)
        {
            var detail = _productRepository.GetProductDetail(id);
            return new Response<ProductDetailDto>()
            {
                Data= detail,
                StatusCode= System.Net.HttpStatusCode.OK
            };
        }

        public Response<ProductResponse> GetById(Guid id)
        {
            var product = _productRepository.GetById(id);
            var response = ProductResponse.ConvertToResponse(product);


            return new Response<ProductResponse>()
            {
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }

        public Response<ProductResponse> Update(UpdateProductRequest request)
        {
            Product product = UpdateProductRequest.ConvertToEntity(request);
            _productRepository.Update(product);
            var response = ProductResponse.ConvertToResponse(product);
            return new Response<ProductResponse>()
            {
                Data = response,
                Message = "Ürün güncellendi.",
                StatusCode = System.Net.HttpStatusCode.OK
                
            };
        }
    }
}
