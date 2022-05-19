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
using SistemaDeMoedaEstudantil.ViewModel;

namespace SistemaDeMoedaEstudantil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtratoController : ControllerBase
    {
        private IExtratoBusiness _extratoBusiness;

        public ExtratoController(IExtratoBusiness extratoBusiness)
        {
            _extratoBusiness = extratoBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Extrato> extrato = _extratoBusiness.FindAll();

            return Ok(extrato);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var extrato = _extratoBusiness.FindByID(id);

            if (extrato == null)
            {
                return NotFound();
            }

            return Ok(extrato);
        }

        // GET: api/Extrato/5
        [HttpGet("extratoConta/{id}")]
        public List<Extrato> GetExtratoConta(long id)
        {
            return _extratoBusiness.GetExtratoConta(id);

        }

        [HttpPost]
        public IActionResult Post([FromBody] ExtratoViewModel extratoViewModel)
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

            if (extratoViewModel == null) return BadRequest();

            return Ok(_extratoBusiness.Create(extratoViewModel));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Extrato extrato)
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

            if (extrato == null) return BadRequest();

            return Ok(_extratoBusiness.Update(extrato));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _extratoBusiness.Delete(id);

            return NoContent();

        }
    }
}
