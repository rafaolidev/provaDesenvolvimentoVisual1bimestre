
using Microsoft.AspNetCore.Mvc;
using API_AMIGO.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using API_AMIGO.Data;

//Controle Dog aqui ficam os metodos do modelo/classe Dog

namespace API_AMIGO.Controllers
{
    [ApiController]
    [Route("api/carro")]
    public class CarroController : ControllerBase
    {
        private readonly DataContext _context;
        public CarroController([FromBody] DataContext context)
        {
            _context = context;
        }
        //inserção de Dados no banco assincrona POST:api/dog/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] Carro carro)
        {
            await _context.Carros.AddAsync(carro);
            _context.SaveChanges();
            return Created("", carro);
        }

        // listagen dados GET:api/dog/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List() => Ok(await _context.Carros.ToListAsync());

        // listagen dados por id GET:api/dog/listbyid/{id}
        [HttpGet]
        [Route("listbyid/{id}")]
        public async Task<IActionResult> ListIdAsync([FromRoute] int id)
        {
            Carro carro = await _context.Carros.FindAsync(id);
            if (carro != null)
            {   
                Console.WriteLine($"Id : {id}");
                return Ok(carro);
            }
            return NotFound("Nenhum dado Referente a pesquisa foi encontrado");
        }

        // Delete por id DELETE:api/dog/deleteid/{id}
        [HttpDelete]
        [Route("deleteid/{id}")]
        public async Task<IActionResult> DeleteIdAsync([FromRoute] int id)
        {       
            Carro carro = await _context.Carros.FindAsync(id);
            if (carro == null)
            {
                return NotFound("Nenhum dado Referente a pesquisa foi encontrado");
            }
            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();
            return Ok("Registro apagado do sistema");
        }

         // Delete por qualquer item do item DELETE:api/dog/deletenome/{nome}
        [HttpDelete]
        [Route("delete/{name}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string name)
        {       
            Carro carro = _context.Carros.FirstOrDefault
            (
                carro => carro.Modelo == name
            );
            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();
            return Ok();
        }
        // PUT: api/dog/update/id
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] Carro Carro)
        {
            _context.Carros.Update(carro);
            await _context.SaveChangesAsync();
            return Ok(carro);
        }
    }
}
