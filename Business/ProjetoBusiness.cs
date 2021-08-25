using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business.Base;
using Tcc_backend.DataBaseConfig;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class ProjetoBusiness : BusinessBase {

        DatabaseContext _databaseContext = new DatabaseContext();

        public List<Projeto> List() {

            var projetos = _databaseContext.Projeto.ToList();

            return projetos;
        }

        public Projeto Get(int ProjetoID) {

            var projeto = _databaseContext.Projeto
                .Where(x => x.ProjetoID == ProjetoID).FirstOrDefault();

            return projeto;
        }

        public int Adicionar(ProjetoModelCreate projetoModel) {

            var projeto = new Projeto() {
                Title = projetoModel.Title,
                Description = projetoModel.Description,
                InitialDate = projetoModel.InitialDate,
                UrlGit = projetoModel.UrlGit,
            };

            _databaseContext.Projeto.Add(projeto);

            _databaseContext.SaveChanges();

            var ID = 2;

            return ID;

        }

        public Projeto Update(ProjetoModel projetoModel) {

            var projeto = this.Get(projetoModel.ProjetoID);

            projeto.Description = projetoModel.Description;
            projeto.InitialDate = projetoModel.InitialDate;
            projeto.Title = projetoModel.Title;
            projeto.UrlGit = projetoModel.UrlGit;


            _databaseContext.Projeto.Update(projeto);

            return projeto;
        }

        public void Delete(int ProjetoID) {

            var projeto = this.Get(ProjetoID);

            _databaseContext.Projeto.Remove(projeto);

        }

    }
}
