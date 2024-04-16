using AuthServer.Core.DTOs;
using AuthServer.Core.Entity;
using AuthServer.Core.Services;
using AuthServer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.EntityFrameworkCore.Storage;

namespace AuthServer.Apı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {


       
         
        private readonly IServiceGeneric<Product, ProductDto> _productService;
        


        public ProductController(IServiceGeneric<Product, ProductDto> productService)
        {

            _productService = productService;
            

        }
       


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return ActionResultInstance(await _productService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public   async Task<IActionResult> GetProductsId(int id)
        {


            return ActionResultInstance(await _productService.GetByIdAsync(id));
            

        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductDto productDto)
        {
            return ActionResultInstance(await _productService.AddAsnyc(productDto));

        }

        [HttpPut]

        public async Task<IActionResult> UpdateProduct(ProductDto productDto)
        {
            return ActionResultInstance(await _productService.Update(productDto, productDto.Id));
        }

        //api/product/2
        [HttpDelete("delete/{id}")]
      //  [Route("api/delete/{id}")]

        public async Task<IActionResult>DeleteProduct(int id)
        {


            return ActionResultInstance(await _productService.Remove(id)) ;

            
        }

        //api/product/2

      /*  [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteProducts(int id)
        {


            return ActionResultInstance(await _productService.Delete(id));

            


        }
      */





    }
}
