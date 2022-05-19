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
    public class InstituicaoEnsinoController : ControllerBase
    {
        private IInstituicaoEnsinoBusiness _instituicaoEnsinoBusiness;

        public InstituicaoEnsinoController(IInstituicaoEnsinoBusiness instituicaoEnsinoBusiness)
        {
            _instituicaoEnsinoBusiness = instituicaoEnsinoBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<InstituicaoEnsino> instituicaoEnsino = _instituicaoEnsinoBusiness.FindAll();

            return Ok(instituicaoEnsino);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var instituicaoEnsino = _instituicaoEnsinoBusiness.FindByID(id);

            if (instituicaoEnsino == null)
            {
                return NotFound();
            }

            return Ok(instituicaoEnsino);
        }

        [HttpPost]
        public IActionResult Post([FromBody] InstituicaoEnsino instituicaoEnsino)
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

            if (instituicaoEnsino == null) return BadRequest();

            return Ok(_instituicaoEnsinoBusiness.Create(instituicaoEnsino));
        }

        [HttpPut]
        public IActionResult Put([FromBody] InstituicaoEnsino instituicaoEnsino)
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

            if (instituicaoEnsino == null) return BadRequest();

            return Ok(_instituicaoEnsinoBusiness.Update(instituicaoEnsino));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _instituicaoEnsinoBusiness.Delete(id);

            return NoContent();

        }
    }
}
