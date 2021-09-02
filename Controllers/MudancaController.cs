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
    [ApiController]
    public class MudancaController : ControllerBase {

        MudancaService sMudanca = new MudancaService();

        [HttpPost]
        public IActionResult Create([FromBody] MudancaModelCreate model) {

            var MudancaID = sMudanca.Adicionar(model);

            return Ok();
        }

    }

}
