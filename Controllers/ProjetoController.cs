using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business;
using Tcc_backend.Entities;
using Tcc_backend.Models;
using Tcc_backend.Service;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace Tcc_backend.Controllers {

    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [EnableCors]
    [ApiController]
    public class ProjetoController : ControllerBase {

        ProjetoService sProjeto = new ProjetoService();

        UserStoryService sUserStory = new UserStoryService();

        [HttpGet]
        public IActionResult List() {

            try {
                var projetoList = sProjeto.List();

                List<ProjetoModel> listModel = new List<ProjetoModel>();

                foreach (var proj in projetoList) {
                    listModel.Add(sProjeto.EntityToModel(proj));
                }

                return Ok(listModel);
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }
        }

        [HttpGet]
        [Route("{ProjetoID}")]
        public IActionResult Get([FromRoute] int ProjetoID) {

            var proj = sProjeto.Get(ProjetoID);

            if (proj != null) { 
                return Ok(proj);
            } else {
                return NotFound();
            }

        }

        [HttpGet]
        [Route("userStories/{ProjetoID}")]
        public IActionResult ListByProjeto([FromRoute] int ProjetoID) {

            try {
                var userStoryList = sUserStory.ListByProjeto(ProjetoID);

                if (userStoryList.Count == 0 && userStoryList == null) {
                    return NotFound("Não foi possível encontrar nenhuma User Story para esse projeto");
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

        [HttpPost]
        public IActionResult Adicionar([FromBody] ProjetoModelCreate projeto) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrWhiteSpace(projeto.Description))
                return BadRequest(new { description = "O campo 'descrição' não pode estar vazio" });

            if (string.IsNullOrWhiteSpace(projeto.Title))
                return BadRequest(new { title = "O campo 'título' não pode estar vazio" });

            try {
                return Ok(sProjeto.Adicionar(projeto));
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }

        }

        [HttpPut("{ProjetoID}")]
        public IActionResult Put([FromBody] ProjetoModelUpdate projeto, [FromRoute] int ProjetoID) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrWhiteSpace(projeto.Description))
                return BadRequest(new { description = "O campo 'descrição' não pode estar vazio" });

            if (string.IsNullOrWhiteSpace(projeto.Title))
                return BadRequest(new { title = "O campo 'título' não pode estar vazio" });

            try {
                projeto.ProjetoID = ProjetoID;

                var updatedProjeto = sProjeto.Update(projeto);
                return Ok(sProjeto.EntityToModel(updatedProjeto));
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }

        }

    }
}
