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
    public class EmpresaParceiraController : ControllerBase
    {
        private readonly SistemaMoedaEstudantilContext _context;

        public EmpresaParceiraController(SistemaMoedaEstudantilContext context)
        {
            _context = context;
        }

        // GET: api/EmpresaParceiras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaParceira>>> GetEmpresaPerceira()
        {
            return await _context.EmpresaPerceira.ToListAsync();
        }

        // GET: api/EmpresaParceiras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaParceira>> GetEmpresaParceira(long id)
        {
            var empresaParceira = await _context.EmpresaPerceira.FindAsync(id);

            if (empresaParceira == null)
            {
                return NotFound();
            }

            return empresaParceira;
        }

        // PUT: api/EmpresaParceiras/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresaParceira(long id, EmpresaParceira empresaParceira)
        {
            if (id != empresaParceira.Id)
            {
                return BadRequest();
            }

            _context.Entry(empresaParceira).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaParceiraExists(id))
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

        // POST: api/EmpresaParceiras
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmpresaParceira>> PostEmpresaParceira(EmpresaParceira empresaParceira)
        {
            empresaParceira.UserType = UserType.EMPRESAPARCEIRA;
            _context.EmpresaPerceira.Add(empresaParceira);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpresaParceira", new { id = empresaParceira.Id }, empresaParceira);
        }

        // DELETE: api/EmpresaParceiras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpresaParceira>> DeleteEmpresaParceira(long id)
        {
            var empresaParceira = await _context.EmpresaPerceira.FindAsync(id);
            if (empresaParceira == null)
            {
                return NotFound();
            }

            _context.EmpresaPerceira.Remove(empresaParceira);
            await _context.SaveChangesAsync();

            return empresaParceira;
        }

        private bool EmpresaParceiraExists(long id)
        {
            return _context.EmpresaPerceira.Any(e => e.Id == id);
        }
    }
}
