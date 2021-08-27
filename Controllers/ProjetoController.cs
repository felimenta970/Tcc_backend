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

        [HttpGet]
        public List<ProjetoModel> List() {

            var projetoList = sProjeto.List();

            List<ProjetoModel> listModel = new List<ProjetoModel>();
           
            foreach (var proj in projetoList) {
                listModel.Add(this.EntityToModel(proj));
            }

            return listModel;
        }

        [HttpGet]
        [Route("{ProjetoID}")]
        public ProjetoModel Get([FromRoute] int ProjetoID) {

            var proj = sProjeto.Get(ProjetoID);

            return this.EntityToModel(proj);
            
        }

        [HttpPost]
        public int Adicionar([FromBody] ProjetoModelCreate projeto) {

            return sProjeto.Adicionar(projeto);

        }

        [HttpPut]
        public ProjetoModel Put([FromBody] ProjetoModelUpdate projeto) {

            var updatedProjeto = sProjeto.Update(projeto);
            return EntityToModel(updatedProjeto);

        }

        public ProjetoModel EntityToModel(Projeto projeto) {

            ProjetoModel model = new ProjetoModel() {
                ProjetoID = projeto.ProjetoID,
                Title = projeto.Title,
                Description = projeto.Description,
                InitialDate = projeto.InitialDate,
                UrlGit = projeto.UrlGit,
            };

            return model;
        }

    }
}
