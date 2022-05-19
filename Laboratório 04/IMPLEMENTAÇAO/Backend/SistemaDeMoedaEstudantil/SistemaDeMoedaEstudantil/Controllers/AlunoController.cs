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
    public class AlunoController : ControllerBase
    {
        private IAlunoBusiness _alunoBusiness;

        public AlunoController(IAlunoBusiness alunoBusiness)
        {
            _alunoBusiness = alunoBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Aluno> aluno = _alunoBusiness.FindAll();
            
            return Ok(aluno);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var aluno = _alunoBusiness.FindByID(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }


        // GET: api/Alunos/ie/5
        [HttpGet("ie/{ie}")]
        public List<Aluno> GetAlunoIe(long ie)
        {
            return _alunoBusiness.GetAlunoIe(ie);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Aluno aluno)
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

            if (aluno == null) return BadRequest();

            return Ok(_alunoBusiness.Create(aluno));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Aluno aluno)
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

            if (aluno == null) return BadRequest();

            return Ok(_alunoBusiness.Update(aluno));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _alunoBusiness.Delete(id);

            return NoContent();
        }

    }
}
