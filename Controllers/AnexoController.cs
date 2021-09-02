﻿using Microsoft.AspNetCore.Http;
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

            var anexoId = sAnexo.Adicionar(anexo);

            return Ok(anexoId);
        }

        [HttpPut]
        public IActionResult Editar([FromBody] AnexoModel anexo) {

            return NotFound();
        }

        [HttpDelete("{AnexoID}")]
        public IActionResult Delete(int AnexoID) {

            sAnexo.Delete(AnexoID);

            return Ok();
        }

    }
}
