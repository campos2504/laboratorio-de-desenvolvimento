using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repositorys;
using SistemaDeMoedaEstudantil.ViewModel;

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

        // GET: api/Extrato/5
        [HttpGet("extratoConta/{id}")]
        public List<Extrato> GetExtratoConta(long id)
        {
            return _context.Extrato.Where(p => p.ContaId.Equals(id)).Include(p => p.Conta).ToList();

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
        public async Task<ActionResult<ExtratoViewModel>> PostExtrato(ExtratoViewModel extrato)
        {
            //Atualiza saldo professor
            var contas = await _context.Conta.ToListAsync();
            Conta contaProfessor = new Conta();
            Conta contaAluno = new Conta();


            foreach (var cont in contas)
            {
                if(cont.Id == extrato.ContaProfessorId)
                {
                    contaProfessor = cont;
                }
                if(cont.Id == extrato.ContaAlunoId)
                {
                    contaAluno = cont;
                }
            }            

            //Atualiza saldo professor
            double saldoAtualProfessor = contaProfessor.Saldo;

            if(saldoAtualProfessor < extrato.Valor)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = "Saldo insuficiente",
                });
            }

            saldoAtualProfessor = saldoAtualProfessor - extrato.Valor;
            contaProfessor.Saldo = saldoAtualProfessor;
            contaProfessor.Id = extrato.ContaProfessorId;
            atualizaConta(contaProfessor);

            //Atualiza saldo aluno
            double saldoAtualAluno = contaAluno.Saldo;
            saldoAtualAluno = saldoAtualAluno + extrato.Valor;
            contaAluno.Saldo = saldoAtualAluno;
            contaAluno.Id = extrato.ContaAlunoId;
            atualizaConta(contaAluno);


            //Novo extrato professor
            var extratoProfessor = new Extrato();
            extratoProfessor.ContaId = extrato.ContaProfessorId;
            extratoProfessor.Valor = extrato.Valor;
            extratoProfessor.TransacaoType = TransacaoType.ENVIADO;
            criaExtrato(extratoProfessor);

            //Novo extrato aluno
            var extratoAluno = new Extrato();
            extratoAluno.ContaId = extrato.ContaAlunoId;
            extratoAluno.Valor = extrato.Valor;
            extratoAluno.TransacaoType = TransacaoType.RECEBIDO;
            criaExtrato(extratoAluno);           
            

            return Ok("Sucess");
        }


        public void atualizaConta(Conta contaAtualizacao)
        {
            _context.Entry(contaAtualizacao).State = EntityState.Modified;
            _context.SaveChangesAsync();

        }

        public void criaExtrato(Extrato extrato)
        {
            _context.Extrato.Add(extrato);
            _context.SaveChangesAsync();
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
