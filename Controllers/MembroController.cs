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
    public class MembroController : ControllerBase {

        UsuarioService sUsuario = new UsuarioService();
        UserStoryService sUserStory = new UserStoryService();

        [HttpGet]
        [Route("userStories/{MembroID}")]
        public IActionResult  ListByMembro([FromRoute] int MembroID) {

            UserStoryService sUserStory = new UserStoryService();

            try {
                var userStoryList = sUserStory.ListByMembro(MembroID);

                if (userStoryList.Count == 0) {
                    return NotFound();
                }

                List<UserStoryModel> modelList = new List<UserStoryModel>();

                foreach (var userStory in userStoryList) {

                    var model = sUserStory.EntityToModel(userStory);

                    modelList.Add(model);
                }

                return Ok(modelList);

            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }
        }

        [HttpGet("{ProjetoID}")]
        public IActionResult ListMembros([FromRoute] int ProjetoID, [FromQuery] bool isUserStoryEdit) {

            MembroService sMembro = new MembroService();

            try {
                List<Membro> listEntity = sMembro.GetListMembros(ProjetoID, isUserStoryEdit);
                List<MembroModel> listModel = new List<MembroModel>();

                if (listEntity.Count == 0) {
                    return NoContent();
                }

                foreach (var entity in listEntity) {
                    var modelItem = sMembro.EntityToModel(entity);
                    listModel.Add(modelItem);
                }

                return Ok(listModel);
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }

        }

        [HttpGet]
        public IActionResult ListMembros() {

            MembroService sMembro = new MembroService();

            try {
                List<Membro> listEntity = sMembro.GetListMembros(null, false);
                List<MembroModel> listModel = new List<MembroModel>();

                if (listEntity.Count == 0) {
                    return NoContent();
                }

                foreach (var entity in listEntity) {
                    var modelItem = sMembro.EntityToModel(entity);
                    listModel.Add(modelItem);
                }

                return Ok(listModel);
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }

        }

        [HttpPost]
        public IActionResult CreateMember(MembroModelCreate model) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrWhiteSpace(model.Nome))
                return BadRequest(new { message = "O campo 'nome' não pode estar vazio" });

            if (string.IsNullOrWhiteSpace(model.UserName))
                return BadRequest(new { message = "O campo 'username' não pode estar vazio" });


            try {
                var uniqueUser = sUsuario.isUniqueUsername(model.UserName);

                if (!uniqueUser)
                    return BadRequest("Nome de Usuário já utilizado");

                MembroService sMembro = new MembroService();

                var result = sMembro.CreateMember(model);

                return Ok(result);
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }

        }

    }

}
