using Core.Shared;
using Model.Dtos.Request;
using Model.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract;

public interface ICoffeeService
{
    Response<CoffeeResponse> Add(AddCoffeeRequest addCoffeeRequest);
    Response<CoffeeResponse> Update(UpdateCoffeeRequest updateCoffeeRequest);
    Response<CoffeeResponse> Delete(int  id);
    Response<CoffeeResponse> GetById(int id);

    Response<List<CoffeeResponse>> GetAll();
}
