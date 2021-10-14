using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Service;

namespace Tcc_backend.Controllers {
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [EnableCors]
    [ApiController]
    public class RelatorioController : ControllerBase {

        RelatorioService sRelatorio = new RelatorioService();

        [HttpGet("mudancasUserStory/{ProjetoID}")]
        public IActionResult GetPorProjeto([FromRoute] int ProjetoID) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                var relatorio = sRelatorio.RelatorioMudancasPorUserStory(ProjetoID);

                return Ok(relatorio);
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor: " + ex.Message);
            }
        }

        [HttpGet("mudancasPorRazao/{ProjetoID}")]
        public IActionResult GetPorProjetoTipo([FromRoute] int ProjetoID) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                var relatorio = sRelatorio.RelatorioMudancasPorTipo(ProjetoID);

                return Ok(relatorio);
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor: " + ex.Message);
            }
        }

        [HttpGet("mudancasPorStatus/{ProjetoID}")]
        public IActionResult GetPorProjetoStatus([FromRoute] int ProjetoID) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                var relatorio = sRelatorio.RelatorioUserStoriesPorStatus(ProjetoID);

                return Ok(relatorio);

            } catch(Exception ex) {
                return StatusCode(500, "Erro de servidor " + ex.Message);
            }
        }

    }
}
