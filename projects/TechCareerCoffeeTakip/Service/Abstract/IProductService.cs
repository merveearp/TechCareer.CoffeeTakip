using Core.Shared;
using Model.Dtos.Request;
using Model.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract;

public interface IProductService
{
    Response<ProductResponse> Add(AddProductRequest request);
    Response<ProductResponse> Update(UpdateProductRequest request);
    Response<ProductResponse> Delete(Guid id);

    Response<ProductResponse> GetById(Guid id);

    Response<List<ProductResponse>> GetAll();
    Response<ProductDetailDto> GetByDetailId(Guid id);

    Response<List<ProductDetailDto>> GetAllDetails();
    Response<List<ProductDetailDto>> GetAllDetailsByCoffeeId(int coffeeId);

}
