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
                listModel.Add(this.EntityToModel(sprint));
            }

            return listModel;
        }

        [HttpGet]
        [Route("{SprintID}")]
        public SprintModel Get([FromRoute] int SprintID) {

            var sprint = sSprint.Get(SprintID);

            return this.EntityToModel(sprint);
        }

        [HttpPost]
        public int Adicionar([FromBody] SprintModelCreate model) {

            return sSprint.Adicionar(model);
        }

        [HttpPut]
        public SprintModel Put([FromBody] SprintModelUpdate model) {

            var updatedSprint = sSprint.Update(model);
            return EntityToModel(updatedSprint);
        }

        [HttpDelete("{SprintID}")]
        public void Delete([FromRoute] int SprintID) {

            sSprint.Delete(SprintID);
        }

        public SprintModel EntityToModel(Sprint sprint) {

            SprintModel model = new SprintModel() {
                SprintID = sprint.SprintID,
                Title = sprint.Title,
                ProjetoID = sprint.ProjetoID
            };

            return model;
        }
    }
}
