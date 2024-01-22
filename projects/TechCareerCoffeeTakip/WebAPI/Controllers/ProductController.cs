using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.Request;
using Service.Abstract;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpPost]
    public IActionResult Add([FromBody] AddProductRequest  addProductRequest) 
    {
        var result = _productService.Add(addProductRequest);
        if(result.StatusCode==System.Net.HttpStatusCode.Created)
        {
            return Created("/", result);
        }
        return BadRequest(result);
    }
    [HttpPut]
    public IActionResult Update(UpdateProductRequest updateProductRequest)
    {
        var result = _productService.Update(updateProductRequest);
        if(result.StatusCode==System.Net.HttpStatusCode.OK)
        {
            return Ok(result);

        }
        return BadRequest(result);

    }
    [HttpDelete]

    public IActionResult Delete([FromQuery] Guid id)
    {
        var result = _productService.Delete(id);
        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return Ok(result);

        }
        return BadRequest(result);

    }
    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery] Guid id)
    {
        var result = _productService.GetById(id);
        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return Ok(result);

        }
        return BadRequest(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _productService.GetAll();
        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return Ok(result);

        }
        return BadRequest(result);
    }
    [HttpGet("getbydetailid")]
    public IActionResult GetByDetailId([FromQuery] Guid id)
    {
        var result = _productService.GetByDetailId(id);
        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return Ok(result);

        }
        return BadRequest(result);

    }
    [HttpGet("details")]
    public IActionResult GetAllDetails()
    {
   var result = _productService.GetAllDetails();
        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return Ok(result);

        }
        return BadRequest(result);
    }
    [HttpGet("getalldetailsbycoffee")]
    public IActionResult GetAllDetailsByCoffeeId([FromQuery] int coffeeId)
    {
        var result = _productService.GetAllDetailsByCoffeeId(coffeeId);
        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return Ok(result);

        }
        return BadRequest(result);
    }

}
