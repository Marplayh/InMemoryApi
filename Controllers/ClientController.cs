using InMemoryApi.Context;
using InMemoryApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InMemoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ApiContext Db;

        public ClientController(ApiContext db)
        {
            Db = db;
        }
        // GET: api/<ClientController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                
                return Ok(Db.Clients.ToList());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var client = Db.Clients.Where(x => x.Id == id).FirstOrDefault();
                    if(client == null)
                    return NotFound();
                else
                    return Ok(client);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // POST api/<ClientController>
        [HttpPost]
        public IActionResult Post([FromBody] Client client)
        {
            try
            {
                Db.Clients.Add(client);
                Db.SaveChanges();
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Client client)
        {
            try
            {
                var obj = Db.Clients.Where(x => x.Id == id).FirstOrDefault();
                if (obj == null)
                    return NotFound();
                else
                {
                    obj.Name = client.Name;
                    obj.Email = client.Email;
                    obj.Street = client.Street;
                    obj.Number = client.Number;
                    obj.City = client.City;
                    

                    Db.Update(obj);
                    Db.SaveChanges();
                }
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var client = Db.Clients.Where(x => x.Id == id).FirstOrDefault();
                if (client == null)
                    return NotFound();
                else
                {
                    Db.Clients.Remove(client);
                    Db.SaveChanges();
                }
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
