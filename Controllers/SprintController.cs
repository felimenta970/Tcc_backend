using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
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
    [Authorize(AuthenticationSchemes = "Bearer")]
    [EnableCors]
    [ApiController]
    public class SprintController : ControllerBase {

        SprintService sSprint = new SprintService();

        MembroService sMembro = new MembroService();

        UserStoryService sUserStory = new UserStoryService();

        [HttpGet]
        public IActionResult List([FromQuery] int ProjetoID) {

            try {
                var sprintList = sSprint.ListByProjeto(ProjetoID);

                if (sprintList.Count == 0 || sprintList == null) {
                    return NotFound();
                }

                List<SprintModel> listModel = new List<SprintModel>();

                foreach (var sprint in sprintList) {
                    listModel.Add(sSprint.EntityToModel(sprint));
                }

                return Ok(listModel);
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }
        }

        [HttpGet]
        [Route("{SprintID}")]
        public IActionResult Get([FromRoute] int SprintID) {

            var sprint = sSprint.Get(SprintID);

            if (sprint != null) {
                return Ok(sSprint.EntityToModel(sprint));
            } else {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("userStories/{SprintID}")]
        public IActionResult ListUserStories([FromRoute] int SprintID) {

            UserStoryService sUserStory = new UserStoryService();

            try { 
                var userStoryList = sUserStory.ListBySprint(SprintID);

                if (userStoryList.Count == 0 || userStoryList == null) {
                    return NotFound();
                }

                List<UserStoryModel> modelList = new List<UserStoryModel>();

                foreach (var userStory in userStoryList) {

                    var membro = sMembro.Get(userStory.MembroID);

                    var model = sUserStory.EntityToModel(userStory);
                    model.MembroName = membro.Name;

                    modelList.Add(model);
                }

                return Ok(modelList);
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] SprintModelCreate model) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrWhiteSpace(model.Title))
                return BadRequest(new { message = "O campo 'título' não pode estar vazio" });

            ProjetoService sProjeto = new ProjetoService();

            var projID = sProjeto.Get(model.ProjetoID);

            if (projID == null || projID == default)
                return BadRequest(new { message = "Este projeto não existe" });

            try {
                var idSprint = sSprint.Adicionar(model);

                if (idSprint != null) {
                    return Ok(idSprint);
                } else {
                    return StatusCode(500, "Erro de servidor");
                }
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }
        }

        [HttpPut("{SprintID}")]
        public IActionResult Put([FromBody] SprintModelUpdate model, [FromRoute] int SprintID) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrWhiteSpace(model.Title))
                return BadRequest(new { message = "O campo 'título' não pode estar vazio" });

            try {
                model.SprintID = SprintID;

                var updatedSprint = sSprint.Update(model);
                return Ok(sSprint.EntityToModel(updatedSprint));
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }
        }

        [HttpDelete("{SprintID}")]
        public IActionResult Delete([FromRoute] int SprintID) {

            try {
                sSprint.Delete(SprintID);
                return Ok();
            }
            catch {
                return StatusCode(500);
            }
        }

        [HttpPost("removeAssociacaoSprintUserStory")]
        public IActionResult RemoveAssociacaoSprintUserStory([FromBody] SprintUserStoryModel model) {

            var userStory = sUserStory.Get(model.UserStoryID);

            if (userStory.Status != Enums.UserStoryStatus.ToDo) {
                return BadRequest("História de usuário em progresso ou finalizada, não é possível dessasociá-la desta Sprint");
            }

            sUserStory.DesassociaUserStorySprint(model.UserStoryID);

            MudancaModelCreate mudanca = new MudancaModelCreate() {
                UserStoryID = model.UserStoryID,
                ProjectManagerID = 0,
                Description = "Desassoociacação de história de usuário da sprint",
                ChangeReason = Enums.ChangeReason.Outro,
            };

            MudancaService sMudanca = new MudancaService();
            sMudanca.Adicionar(mudanca);

            return Ok();
        }

    }
}
