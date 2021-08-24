using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business;
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
                listModel.Add(new ProjetoModel() {
                    ProjetoID = proj.ProjetoID,
                    Title = proj.Title,
                    Description = proj.Description,
                    InitialDate = proj.InitialDate,
                    UrlGit = proj.UrlGit,
                });
            }

            return listModel;
        }

        [HttpGet]
        [Route("{ProjetoID}")]
        public ProjetoModel Get([FromRoute] int ProjetoID) {

            var proj = sProjeto.Get(ProjetoID);

            ProjetoModel projetoModel = new ProjetoModel() {
                ProjetoID = proj.ProjetoID,
                Title = proj.Title,
                Description = proj.Description,
                InitialDate = proj.InitialDate,
                UrlGit = proj.UrlGit,
            };

            return projetoModel;
        }

        [HttpPost]
        public int Adicionar([FromBody] ProjetoModelCreate projeto) {

            var id = sProjeto.Adicionar(projeto);

            return id;
        }

        [HttpPut]
        public ProjetoModel Put([FromBody] ProjetoModel projeto) {


            return new ProjetoModel();
        }

    }
}
