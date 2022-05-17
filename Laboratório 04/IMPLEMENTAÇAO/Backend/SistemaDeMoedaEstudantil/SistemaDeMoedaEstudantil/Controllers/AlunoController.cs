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
    public class AlunoController : ControllerBase
    {
        private readonly SistemaMoedaEstudantilContext _context;

        public AlunoController(SistemaMoedaEstudantilContext context)
        {
            _context = context;
        }

        // GET: api/Alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAluno()
        {
            var alunos = await _context.Aluno.Include(p => p.Conta).Include(p => p.InstituicaoEnsino).ToListAsync();

            return alunos;

        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(long id)
        {
            var aluno = await _context.Aluno.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }


        // GET: api/Alunos/ie/5
        [HttpGet("ie/{ie}")]
        public List<Aluno> GetAlunoIe(long ie)
        {
            return _context.Aluno.Where(p => p.InstituicaoEnsinoId.Equals(ie)).ToList();            
        }

        // PUT: api/Alunos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(long id, Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
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

        // POST: api/Alunos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostAluno(Aluno aluno)
        {
            var conta = new Conta();
            conta.Saldo = 0;
            _context.Conta.Add(conta);
            _context.SaveChanges();

            aluno.UserType = UserType.ALUNO;
            aluno.ContaId = conta.Id;
            _context.Aluno.Add(aluno);
            _context.SaveChanges();            

            return Ok(aluno);
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> DeleteAluno(long id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();

            return aluno;
        }

        private bool AlunoExists(long id)
        {
            return _context.Aluno.Any(e => e.Id == id);
        }
    }
}
