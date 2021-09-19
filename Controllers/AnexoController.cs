using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Tcc_backend.Entities;
using Tcc_backend.Models;
using Tcc_backend.Service;

namespace Tcc_backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AnexoController : ControllerBase {

        AnexoService sAnexo = new AnexoService();

        [HttpGet]
        [Route("{AnexoID}")]
        public IActionResult Get([FromRoute] int AnexoID) {
            var anexo = sAnexo.Get(AnexoID);

            var anexoModel = sAnexo.EntityToModel(anexo);

            return Ok(anexoModel);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] AnexoModelCreate anexo) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try {
                var anexoId = sAnexo.Adicionar(anexo);
                return Ok(anexoId);
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }
            
        }

        [HttpPut("{AnexoID}")]
        public IActionResult Editar([FromBody] AnexoModelEdit anexo, [FromRoute] int AnexoID) {

            anexo.AnexoID = AnexoID;

            try {
                var anexoAtualizado = sAnexo.Update(anexo);
                var anexoModel = sAnexo.EntityToModel(anexoAtualizado);
                return Ok(anexoModel);
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }

        }

        [HttpDelete("{AnexoID}")]
        public IActionResult Delete(int AnexoID) {

            try {
                sAnexo.Delete(AnexoID);

                return NoContent();
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }

        }

    }
}
