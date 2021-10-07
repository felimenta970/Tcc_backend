using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Models;
using Tcc_backend.Service;

namespace Tcc_backend.Controllers {
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [EnableCors]
    [ApiController]
    public class MudancaController : ControllerBase {

        MudancaService sMudanca = new MudancaService();

        [HttpPost]
        public IActionResult Create([FromBody] MudancaModelCreate model) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrWhiteSpace(model.Description))
                return BadRequest(new { message = "O campo 'descrição' não pode estar vazio" });

            if (model.ChangeReason == null)
                return BadRequest(new { message = "O campo 'Razão de mudança' deve ser selecionado" });

            try {
                var MudancaID = sMudanca.Adicionar(model);
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }

            return Ok();
        }

    }

}
