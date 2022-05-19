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
    public class EmpresaParceiraController : ControllerBase
    {
        private IEmpresaParceiraBusiness _empresaParceiraBusiness;

        public EmpresaParceiraController(IEmpresaParceiraBusiness empresaParceiraBusiness)
        {
            _empresaParceiraBusiness = empresaParceiraBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<EmpresaParceira> empresaParceira = _empresaParceiraBusiness.FindAll();

            return Ok(empresaParceira);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var empresaParceira = _empresaParceiraBusiness.FindByID(id);

            if (empresaParceira == null)
            {
                return NotFound();
            }

            return Ok(empresaParceira);
        }

        [HttpPost]
        public IActionResult Post([FromBody] EmpresaParceira empresaParceira)
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

            if (empresaParceira == null) return BadRequest();

            return Ok(_empresaParceiraBusiness.Create(empresaParceira));
        }

        [HttpPut]
        public IActionResult Put([FromBody] EmpresaParceira empresaParceira)
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

            if (empresaParceira == null) return BadRequest();

            return Ok(_empresaParceiraBusiness.Update(empresaParceira));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _empresaParceiraBusiness.Delete(id);

            return NoContent();

        }
    }
}
