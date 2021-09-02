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

namespace Tcc_backend.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase {

        ProjetoService sProjeto = new ProjetoService();

        UserStoryService sUserStory = new UserStoryService();

        [HttpGet]
        public List<ProjetoModel> List() {

            var projetoList = sProjeto.List();

            List<ProjetoModel> listModel = new List<ProjetoModel>();
           
            foreach (var proj in projetoList) {
                listModel.Add(sProjeto.EntityToModel(proj));
            }

            return listModel;
        }

        [HttpGet]
        [Route("{ProjetoID}")]
        public ProjetoModel Get([FromRoute] int ProjetoID) {

            var proj = sProjeto.Get(ProjetoID);

            return sProjeto.EntityToModel(proj);
            
        }

        [HttpGet]
        [Route("userStories/{ProjetoID}")]
        public IActionResult ListByProjeto([FromRoute] int ProjetoID) {

            var userStoryList = sUserStory.ListByProjeto(ProjetoID);

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
        public int Adicionar([FromBody] ProjetoModelCreate projeto) {

            return sProjeto.Adicionar(projeto);

        }

        [HttpPut]
        public ProjetoModel Put([FromBody] ProjetoModelUpdate projeto) {

            var updatedProjeto = sProjeto.Update(projeto);
            return sProjeto.EntityToModel(updatedProjeto);

        }

    }
}
