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

        [HttpGet]
        [Route("{UserStoryID}")]
        public UserStoryModel Get([FromRoute] int UserStoryID) {

            var userStory = sUserStory.Get(UserStoryID);

            var model = sUserStory.EntityToModel(userStory);

            return model;
        }

        [HttpGet]
        [Route("anexos/{UserStoryId}")]
        public IActionResult ListAnexos([FromRoute] int UserStoryID) {

            AnexoService sAnexo = new AnexoService();
            var anexos = sAnexo.ListByUserStoryID(UserStoryID);

            List<AnexoModel> listAnexos = new List<AnexoModel>();

            foreach(var anexo in anexos) {

                AnexoModel anexoModel = sAnexo.EntityToModel(anexo);
                listAnexos.Add(anexoModel);
            }

            if (listAnexos.Count == 0)
                return NotFound();

            return Ok(listAnexos);
        }

        [HttpGet]
        [Route("mudancas/{UserStoryID}")]
        public IActionResult ListMudancas([FromRoute] int UserStoryID) {

            MudancaService sMudanca = new MudancaService();
            var mudancas = sMudanca.ListByUserStoryID(UserStoryID);

            List<MudancaModel> listMudancaModel = new List<MudancaModel>();

            foreach (var mudanca in mudancas) {

                var mudancaModel = sMudanca.EntitiyToModel(mudanca);
                listMudancaModel.Add(mudancaModel);
            }

            if (listMudancaModel.Count == 0)
                return NoContent();

            return Ok(listMudancaModel);
        }

        [HttpPost]
        public int Create([FromBody] UserStoryModelCreate model) {

            int UserStoryID = sUserStory.Adicionar(model);

            return UserStoryID;
        }

        [HttpPut]
        public UserStoryModel Update([FromBody] UserStoryModelUpdate model) {

            var userStory = sUserStory.Update(model);

            var modelResult = sUserStory.EntityToModel(userStory);

            return modelResult;

        }

        [HttpDelete]
        [Route("{UserStoryID}")]
        public void Delete([FromRoute] int UserStoryID) {

            sUserStory.Delete(UserStoryID);

        }

    }
}
