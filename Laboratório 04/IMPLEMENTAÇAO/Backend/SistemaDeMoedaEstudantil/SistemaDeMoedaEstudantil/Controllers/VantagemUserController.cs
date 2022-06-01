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
    public class VantagemUserController : ControllerBase
    {
        private IVantagemUserBusiness _vantagemUserBusiness;

        public VantagemUserController(IVantagemUserBusiness vantagemUserBusiness)
        {
            _vantagemUserBusiness = vantagemUserBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VantagemUser> vantagemUser = _vantagemUserBusiness.FindAll();
            
            return Ok(vantagemUser);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var vantagemUser = _vantagemUserBusiness.FindByID(id);

            if (vantagemUser == null)
            {
                return NotFound();
            }

            return Ok(vantagemUser);
        }

        [HttpPost]
        public IActionResult Post([FromBody] VantagemUser vantagemUser)
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

            if (vantagemUser == null) return BadRequest();

            return Ok(_vantagemUserBusiness.Create(vantagemUser));
        }

        [HttpPut]
        public IActionResult Put([FromBody] VantagemUser vantagemUser)
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

            if (vantagemUser == null) return BadRequest();

            return Ok(_vantagemUserBusiness.Update(vantagemUser));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _vantagemUserBusiness.Delete(id);

            return NoContent();
        }

    }
}
