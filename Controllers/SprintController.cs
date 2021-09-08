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
    [ApiController]
    public class SprintController : ControllerBase {

        SprintService sSprint = new SprintService();

        [HttpGet]
        public List<SprintModel> List([FromQuery] int ProjetoID) {

            var sprintList = sSprint.ListByProjeto(ProjetoID);

            List<SprintModel> listModel = new List<SprintModel>();

            foreach (var sprint in sprintList) {
                listModel.Add(sSprint.EntityToModel(sprint));
            }

            return listModel;
        }

        [HttpGet]
        [Route("{SprintID}")]
        public SprintModel Get([FromRoute] int SprintID) {

            var sprint = sSprint.Get(SprintID);

            return sSprint.EntityToModel(sprint);
        }

        [HttpGet]
        [Route("userStories/{SprintID}")]
        public IActionResult ListUserStories([FromRoute] int SprintID) {

            UserStoryService sUserStory = new UserStoryService();
            var userStoryList = sUserStory.ListBySprint(SprintID);

            List<UserStoryModel> modelList = new List<UserStoryModel>();

            foreach (var userStory in userStoryList) {

                var model = sUserStory.EntityToModel(userStory);

                modelList.Add(model);
            }

            if (modelList.Count == 0) {
                return NotFound("Não foi possível encontrar nenhuma User Story para esse projeto");
            }

            return Ok(modelList);
        }

        [HttpPost]
        public int Adicionar([FromBody] SprintModelCreate model) {

            return sSprint.Adicionar(model);
        }

        [HttpPut("{SprintID}")]
        public SprintModel Put([FromBody] SprintModelUpdate model, [FromRoute] int SprintID) {

            model.SprintID = SprintID;

            var updatedSprint = sSprint.Update(model);
            return sSprint.EntityToModel(updatedSprint);
        }

        [HttpDelete("{SprintID}")]
        public void Delete([FromRoute] int SprintID) {

            sSprint.Delete(SprintID);
        }

    }
}
