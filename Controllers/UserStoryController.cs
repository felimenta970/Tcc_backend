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
        public IActionResult Get([FromRoute] int UserStoryID) {

            var userStory = sUserStory.Get(UserStoryID);

            if (userStory != null) {

                var model = sUserStory.EntityToModel(userStory);

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
