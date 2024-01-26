using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Trainings.Model;

namespace WebApi_Trainings.Controllers
{
    //SOA nedir
    //rest restful wcf
    
    //product modelı ıd productname brand  prıce
    //prodduct controller yap
    //bu controllerda bır urun lıstesı olsun ve ıcerısınde bırkactane urun olsun
    //butun urunlerın lıstesını donduren bır endpoint olsun
    //ıd ye gore bır urun donduren enddpoınt olsun
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products = new List<Product>() { 
            new Product { Id = 1, ProductName = "masa", 
                Brand = "Koçtaş" , Price = 4000},
            new Product { Id = 2, ProductName = "tahta", 
                Brand = "Ikea" , Price = 3000},
            new Product { Id = 3, ProductName = "silgi", 
                Brand = "fabe castel" , Price = 35},

        };

        [HttpGet("GetAll")]
        public List<Product> GetAll()
        {
            List<Product> products2 = products.ToList();
            return products2;
        }

        [HttpGet("GetById")]
        public Product GetById(int id)
        {
            Product product = products.SingleOrDefault(p => p.Id == id);
            return product;
        }
    }
}
