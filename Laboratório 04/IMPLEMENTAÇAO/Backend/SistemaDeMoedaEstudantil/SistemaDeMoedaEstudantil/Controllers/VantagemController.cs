using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeMoedaEstudantil.Business;
using SistemaDeMoedaEstudantil.Helpers;
using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repositorys;
using SistemaDeMoedaEstudantil.ViewModel;

namespace SistemaDeMoedaEstudantil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VantagemController : ControllerBase
    {
        private IVantagemBusiness _vantagemBusiness;

        public VantagemController(IVantagemBusiness vantagemBusiness)
        {
            _vantagemBusiness = vantagemBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Vantagem> vantagem = _vantagemBusiness.FindAll();
            var resultado = vantagem.Select(x => new Vantagem
            {
                Id = x.Id,
                Descricao = x.Descricao,
                Valor = x.Valor,
                Imagem = x.Imagem,
                ImagemSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.Imagem)
            });

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var vantagem = _vantagemBusiness.FindByID(id);

            if (vantagem == null)
            {
                return NotFound();
            }

            return Ok(vantagem);
        }


        [HttpPost]
        public IActionResult Post([FromBody] VantagemViewModel vantagem)
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

            if (!string.IsNullOrEmpty(vantagem.Imagem))
            {
                var imagemNomeModulo = Guid.NewGuid() + "_" + vantagem.Imagem;
                vantagem.Imagem = imagemNomeModulo;

                if (!UploadArquivo(vantagem.ImagemUpload, imagemNomeModulo))
                {
                    return BadRequest(new
                    {
                        success = false,
                        errors = "Não foi possivel fazer upload da imagem",
                    });
                }
            }

            /*if (vantagem == null) return BadRequest();*/

            return Ok(_vantagemBusiness.Create(vantagem));
        }

        [HttpPut]
        public IActionResult Put([FromBody] VantagemViewModel vantagem)
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

            var imagemNomeModulo = Guid.NewGuid() + "_" + vantagem.Imagem;
            vantagem.Imagem = imagemNomeModulo;

            if (!UploadArquivo(vantagem.ImagemUpload, imagemNomeModulo))
            {
                return BadRequest(new
                {
                    success = false,
                    errors = "Não foi possivel fazer upload da imagem",
                });
            }

            return Ok(_vantagemBusiness.Update(vantagem));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _vantagemBusiness.Delete(id);

            return NoContent();
        }

        private bool UploadArquivo(string arquivoModulo, string imgNomeModulo)
        {
            Regex extensionsAllowed = new Regex(@"^.*\.(jpg|JPG|jpeg|JPEG|png|PNG)");
            var matchesModulo = extensionsAllowed.Matches(imgNomeModulo);

            if (string.IsNullOrEmpty(arquivoModulo) || matchesModulo.Count == 0)
            {
                return false;
            }

            var imageDataByteArrayModulo = Convert.FromBase64String(arquivoModulo);

            CurrentDirectoryHelpers.SetCurrentDirectory(); // call it here

            var filePathModulo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", imgNomeModulo);

            if (System.IO.File.Exists(filePathModulo))
            {
                return false;
            }
            System.IO.File.WriteAllBytes(filePathModulo, imageDataByteArrayModulo);

            return true;
        }

    }
}
