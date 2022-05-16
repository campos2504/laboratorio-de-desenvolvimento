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
    public class ExtratoController : ControllerBase
    {
        private readonly SistemaMoedaEstudantilContext _context;

        public ExtratoController(SistemaMoedaEstudantilContext context)
        {
            _context = context;
        }

        // GET: api/Extrato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Extrato>>> GetExtrato()
        {
            return await _context.Extrato.ToListAsync();
        }

        // GET: api/Extrato/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Extrato>> GetExtrato(long id)
        {
            var extrato = await _context.Extrato.FindAsync(id);

            if (extrato == null)
            {
                return NotFound();
            }

            return extrato;
        }

        // PUT: api/Extrato/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtrato(long id, Extrato extrato)
        {
            if (id != extrato.Id)
            {
                return BadRequest();
            }

            _context.Entry(extrato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtratoExists(id))
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

        // POST: api/Extrato
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Extrato>> PostExtrato(Extrato extrato)
        {
            _context.Extrato.Add(extrato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExtrato", new { id = extrato.Id }, extrato);
        }

        // DELETE: api/Extrato/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Extrato>> DeleteExtrato(long id)
        {
            var extrato = await _context.Extrato.FindAsync(id);
            if (extrato == null)
            {
                return NotFound();
            }

            _context.Extrato.Remove(extrato);
            await _context.SaveChangesAsync();

            return extrato;
        }

        private bool ExtratoExists(long id)
        {
            return _context.Extrato.Any(e => e.Id == id);
        }
    }
}
