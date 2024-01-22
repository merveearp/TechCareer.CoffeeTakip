using Azure.Core;
using Core.Shared;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Model.Dtos.Request;
using Model.Dtos.Response;
using Model.Entities;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete;

public class CoffeeService : ICoffeeService  
{ 
    
    private readonly ICoffeeRepository _coffeeRepository;

    public CoffeeService(ICoffeeRepository coffeeRepository)
    {
        _coffeeRepository = coffeeRepository;
    }

    public Response<CoffeeResponse> Add(AddCoffeeRequest addCoffeeRequest)
    {
       Coffee coffee = AddCoffeeRequest.ConvertToEntity(addCoffeeRequest);


        _coffeeRepository.Add(coffee);
        var data = CoffeeResponse.ConvertToResponse(coffee);
        return new Response<CoffeeResponse>()
        {
            Data = data,
            Message = "Kafe eklendi.",
            StatusCode = System.Net.HttpStatusCode.Created

        };
    }

    public Response<CoffeeResponse> Delete(int id)
    {
        var coffee = _coffeeRepository.GetById(id);
        _coffeeRepository.Delete(coffee);

        var data = CoffeeResponse.ConvertToResponse(coffee);
        return new Response<CoffeeResponse>()
        {
            Data = data,
            Message = "Kafe silindi.",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<CoffeeResponse>> GetAll()
    {
        var coffee = _coffeeRepository.GetAll();
        var response = coffee.Select(x => CoffeeResponse.ConvertToResponse(x)).ToList();
        return new Response<List<CoffeeResponse>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<CoffeeResponse> GetById(int id)
    {
        var coffee = _coffeeRepository.GetById(id);
        var response = CoffeeResponse.ConvertToResponse(coffee);


        return new Response<CoffeeResponse>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<CoffeeResponse> Update(UpdateCoffeeRequest updateCoffeeRequest)
    {
        Coffee coffee = UpdateCoffeeRequest.ConvertToEntity(updateCoffeeRequest);
        _coffeeRepository.Update(coffee);
        var response = CoffeeResponse.ConvertToResponse(coffee);
        return new Response<CoffeeResponse>()
        {
            Data = response,
            Message = "Kafe güncellendi.",
            StatusCode = System.Net.HttpStatusCode.OK

        };
    }
}
