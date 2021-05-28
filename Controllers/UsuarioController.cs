using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TesteVaiVoa.Models;
using TesteVaiVoa.Repositories;

namespace TesteVaiVoa.Controllers{

    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("")]
       public IActionResult Create([FromBody]Usuario model, [FromServices]IUsuarioRepository repository)
       {
           if(!ModelState.IsValid)    
                return  BadRequest();
            
            repository.Create(model);
            return Ok();
       } 

        [HttpPost]
        [Route("login")]

        public IActionResult Login([FromBody]Usuario model, [FromServices]IUsuarioRepository repository)
        {
            if(!ModelState.IsValid)    
                return  BadRequest();
            
            Usuario usuario = repository.Read(model.Email);

            if(usuario == null)
                return Unauthorized();
            return Ok(new {
                usuario = usuario
            });
        }



    }

}