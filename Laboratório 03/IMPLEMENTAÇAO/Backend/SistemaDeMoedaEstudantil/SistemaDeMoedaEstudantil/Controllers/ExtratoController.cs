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
            var contaProf = await _context.Conta.FindAsync(extrato.ContaProfessorId);
            Conta contaProfessor = new Conta();
            contaProfessor = contaProf;

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
            var contaAlun = await _context.Conta.FindAsync(extrato.ContaAlunoId);
            Conta contaAluno = new Conta();
            contaAluno = contaAlun;

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
            _context.Extrato.Add(extratoProfessor);
            await _context.SaveChangesAsync();


            //Novo extrato aluno
            var extratoAluno = new Extrato();
            extratoAluno.ContaId = extrato.ContaAlunoId;
            extratoAluno.Valor = extrato.Valor;
            extratoAluno.TransacaoType = TransacaoType.RECEBIDO;
            _context.Extrato.Add(extratoAluno);
            await _context.SaveChangesAsync();


            

            return CreatedAtAction("GetExtrato", new { id = extrato.Id }, extrato);
        }


        public void atualizaConta(Conta contaAtualizacao)
        {
            _context.Entry(contaAtualizacao).State = EntityState.Modified;
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
