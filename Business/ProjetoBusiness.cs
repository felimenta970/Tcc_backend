using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class ProjetoBusiness {

        ProjetoDao _dao = new ProjetoDao();
        UsuarioDao _usuarioDao = new UsuarioDao();

        public Projeto Get(int ProjetoID) {
            return _dao.Get(ProjetoID);
        }

        public List<Projeto> List() {
            return _dao.List();
        }

        public int Adicionar(ProjetoModelCreate projetoModel) {

            var projeto = new Projeto() {
                Title = projetoModel.Title,
                Description = projetoModel.Description,
                InitialDate = projetoModel.InitialDate,
                UrlGit = projetoModel.UrlGit,
            };

            var projetoID = _dao.Adicionar(projeto);

            List<int> membrosID = projetoModel.Membros.Select(x => x.MembroID).ToList();

            _usuarioDao.AssociaMembroProjeto(membrosID, projetoID);

            _usuarioDao.AssociaManagerProjeto(projetoModel.ProjectManagerID, projetoID);

            return projetoID;
        }

        public Projeto Update(ProjetoModelUpdate projetoModel) {

            var projeto = _dao.Get(projetoModel.ProjetoID);

            projeto.Description = projetoModel.Description;
            projeto.InitialDate = projetoModel.InitialDate;
            projeto.Title = projetoModel.Title;
            projeto.UrlGit = projetoModel.UrlGit;

            return _dao.Update(projeto);
        }

        public void Delete(int ProjetoID) {

            Projeto projeto = new Projeto() {
                ProjetoID = ProjetoID,
            };

            _dao.Delete(projeto);

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
