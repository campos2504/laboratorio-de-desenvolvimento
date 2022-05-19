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
    public class ContaController : ControllerBase
    {
        private IContaBusiness _contaBusiness;

        public ContaController(IContaBusiness contaBusiness)
        {
            _contaBusiness = contaBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Conta> conta = _contaBusiness.FindAll();

            return Ok(conta);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var conta = _contaBusiness.FindByID(id);

            if (conta == null)
            {
                return NotFound();
            }

            return Ok(conta);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Conta conta)
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

            if (conta == null) return BadRequest();

            return Ok(_contaBusiness.Create(conta));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Conta conta)
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

            if (conta == null) return BadRequest();

            return Ok(_contaBusiness.Update(conta));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _contaBusiness.Delete(id);

            return NoContent();

        }
    }
}
