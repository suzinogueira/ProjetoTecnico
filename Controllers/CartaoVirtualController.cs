using System;
using Microsoft.AspNetCore.Mvc;
using TesteVaiVoa.Models;
using TesteVaiVoa.Repositories;

namespace TesteVaiVoa.Controllers{
    
    [ApiController]
    [Route("cartaovirtual")]
    public class CartaoVirtualController: ControllerBase{

        [HttpGet("{email}")]

        public IActionResult Read(String email,[FromServices]ICartaoVirtualRepository repository){
            
            var cartaovirtual = repository.Read(email);
            return Ok(cartaovirtual);
        }

        

       
        [HttpPost]
        public IActionResult Create([FromBody]CartaoVirtual model, [FromServices]ICartaoVirtualRepository repository)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            
            repository.Create(model);

            var cartaovirtual = repository.ReadSingle();
            return Ok(cartaovirtual); 
            
        }

        [HttpDelete("{id}")]
         public IActionResult Delete(string id, [FromServices]ICartaoVirtualRepository repository)
        {
            repository.Delete(new Guid(id));

            return Ok();
        }

    
    }
   

}