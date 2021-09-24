using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Entities;
using Tcc_backend.Models;
using Tcc_backend.Service;

namespace Tcc_backend.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class UserStoryController : ControllerBase {

        UserStoryService sUserStory = new UserStoryService();
        CommitService sCommit = new CommitService();
        AnexoService sAnexo = new AnexoService();
        MembroService sMembro = new MembroService();

        [HttpGet]
        [Route("{UserStoryID}")]
        public IActionResult Get([FromRoute] int UserStoryID) {

            var userStory = sUserStory.Get(UserStoryID);

            var commits = sCommit.ListByUserStoryID(UserStoryID);

            var anexos = sAnexo.ListByUserStoryID(UserStoryID);

            var membro = sMembro.Get(userStory.MembroID);

            if (userStory != null) {

                var model = sUserStory.EntityToModel(userStory);
                model.Anexos = anexos;
                model.Commits = commits;
                model.MembroName = membro.Name;

                return Ok(model);
            } else {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("anexos/{UserStoryId}")]
        public IActionResult ListAnexos([FromRoute] int UserStoryID) {

            AnexoService sAnexo = new AnexoService();

            try {
                var anexos = sAnexo.ListByUserStoryID(UserStoryID);

                if (anexos.Count == 0 || anexos == null) {
                    return NotFound();
                }

                List<AnexoModel> listAnexos = new List<AnexoModel>();

                foreach (var anexo in anexos) {

                    AnexoModel anexoModel = sAnexo.EntityToModel(anexo);
                    listAnexos.Add(anexoModel);
                }

                return Ok(listAnexos);
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }
        }

        [HttpGet]
        [Route("mudancas/{UserStoryID}")]
        public IActionResult ListMudancas([FromRoute] int UserStoryID) {

            MudancaService sMudanca = new MudancaService();

            try {
                var mudancas = sMudanca.ListByUserStoryID(UserStoryID);

                if (mudancas.Count == 0 || mudancas == null) {
                    return NotFound();
                }

                List<MudancaModel> listMudancaModel = new List<MudancaModel>();

                foreach (var mudanca in mudancas) {

                    var mudancaModel = sMudanca.EntitiyToModel(mudanca);
                    listMudancaModel.Add(mudancaModel);
                }

                return Ok(listMudancaModel);
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserStoryModelCreate model) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrWhiteSpace(model.WhoDesc))
                return BadRequest(new { message = "O campo 'Quem' não pode estar vazio" });

            if (string.IsNullOrWhiteSpace(model.WhatDesc))
                return BadRequest(new { message = "O campo 'O que' não pode estar vazio" });

            if (string.IsNullOrWhiteSpace(model.WhyDesc))
                return BadRequest(new { message = "O campo 'Para que' não pode estar vazio" });

            ProjetoService sProjeto = new ProjetoService();

            var projID = sProjeto.Get(model.ProjetoID);

            if (projID == null || projID == default)
                return BadRequest(new { message = "Este projeto não existe" });

            try {

                int UserStoryID = sUserStory.Adicionar(model);

                return Ok(UserStoryID);
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }
        }

        [HttpPut("{UserStoryID}")]
        public IActionResult Update([FromBody] UserStoryModelUpdate model, [FromRoute] int UserStoryID) {

            if (!ModelState.IsValid)
                return BadRequest();

            if (string.IsNullOrWhiteSpace(model.data.WhoDesc))
                return BadRequest(new { message = "O campo 'Quem' não pode estar vazio" });

            if (string.IsNullOrWhiteSpace(model.data.WhatDesc))
                return BadRequest(new { message = "O campo 'O que' não pode estar vazio" });

            if (string.IsNullOrWhiteSpace(model.data.WhyDesc))
                return BadRequest(new { message = "O campo 'Para que' não pode estar vazio" });

            if (string.IsNullOrWhiteSpace(model.mudanca.Description))
                return BadRequest(new { message = "O campo 'descrição' não pode estar vazio" });

            if (model.mudanca.ChangeReason == null)
                return BadRequest(new { message = "O campo 'Razão de mudança' deve ser selecionado" });

            try {
                model.data.UserStoryID = UserStoryID;

                var userStory = sUserStory.Update(model);

                var modelResult = sUserStory.EntityToModel(userStory);

                return Ok(modelResult);
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }

        }

        [HttpDelete]
        [Route("{UserStoryID}")]
        public IActionResult Delete([FromRoute] int UserStoryID) {

            try {
                sUserStory.Delete(UserStoryID);
                return NoContent();
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }

        }

    }
}
