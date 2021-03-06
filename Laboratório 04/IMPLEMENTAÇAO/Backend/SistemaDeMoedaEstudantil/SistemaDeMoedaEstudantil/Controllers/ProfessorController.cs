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
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorBusiness _professorBusiness;

        public ProfessorController(IProfessorBusiness professorBusiness)
        {
            _professorBusiness = professorBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Professor> professor = _professorBusiness.FindAll();
            
            return Ok(professor);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var professor = _professorBusiness.FindByID(id);

            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Professor professor)
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

            if (professor == null) return BadRequest();

            return Ok(_professorBusiness.Create(professor));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Professor professor)
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

            if (professor == null) return BadRequest();

            return Ok(_professorBusiness.Update(professor));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _professorBusiness.Delete(id);

            return NoContent();
        }

    }
}
