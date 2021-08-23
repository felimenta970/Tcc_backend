using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business;
using Tcc_backend.Models;

namespace Tcc_backend.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase {

        ProjetoBusiness bProjeto = new ProjetoBusiness();

        [HttpGet]
        public List<ProjetoModel> List() {

            var projetoList = bProjeto.List();

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

            var proj = bProjeto.Get(ProjetoID);

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

            var id = bProjeto.Adicionar(projeto);

            return id;
        }

    }
}
