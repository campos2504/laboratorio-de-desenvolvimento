using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeMoedaEstudantil.Business;
using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repositorys;

namespace SistemaDeMoedaEstudantil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<User> user = _userBusiness.FindAll();
            
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var user = _userBusiness.FindByID(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))
                });
            }

            if (user == null) return BadRequest();

            return Ok(_userBusiness.Create(user));
        }

        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))
                });
            }

            if (user == null) return BadRequest();

            return Ok(_userBusiness.Update(user));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _userBusiness.Delete(id);

            return NoContent();
        }

    }
}
