using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repositorys;

namespace SistemaDeMoedaEstudantil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoEnsinoController : ControllerBase
    {
        private readonly SistemaMoedaEstudantilContext _context;

        public InstituicaoEnsinoController(SistemaMoedaEstudantilContext context)
        {
            _context = context;
        }

        // GET: api/InstituicaoEnsino
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstituicaoEnsino>>> GetInstituicaoEnsino()
        {
            return await _context.InstituicaoEnsino.ToListAsync();
        }

        // GET: api/InstituicaoEnsino/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstituicaoEnsino>> GetInstituicaoEnsino(long id)
        {
            var instituicaoEnsino = await _context.InstituicaoEnsino.FindAsync(id);

            if (instituicaoEnsino == null)
            {
                return NotFound();
            }

            return instituicaoEnsino;
        }

        // PUT: api/InstituicaoEnsino/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstituicaoEnsino(long id, InstituicaoEnsino instituicaoEnsino)
        {
            if (id != instituicaoEnsino.Id)
            {
                return BadRequest();
            }

            _context.Entry(instituicaoEnsino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstituicaoEnsinoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InstituicaoEnsino
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InstituicaoEnsino>> PostInstituicaoEnsino(InstituicaoEnsino instituicaoEnsino)
        {
            _context.InstituicaoEnsino.Add(instituicaoEnsino);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstituicaoEnsino", new { id = instituicaoEnsino.Id }, instituicaoEnsino);
        }

        // DELETE: api/InstituicaoEnsino/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InstituicaoEnsino>> DeleteInstituicaoEnsino(long id)
        {
            var instituicaoEnsino = await _context.InstituicaoEnsino.FindAsync(id);
            if (instituicaoEnsino == null)
            {
                return NotFound();
            }

            _context.InstituicaoEnsino.Remove(instituicaoEnsino);
            await _context.SaveChangesAsync();

            return instituicaoEnsino;
        }

        private bool InstituicaoEnsinoExists(long id)
        {
            return _context.InstituicaoEnsino.Any(e => e.Id == id);
        }
    }
}
