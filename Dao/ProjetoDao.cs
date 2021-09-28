using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business.Base;
using Tcc_backend.DataBaseConfig;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Dao {
    public class ProjetoDao {

        DatabaseContext _databaseContext = new DatabaseContext();

        public List<Projeto> List(List<int> ProjetosID) {

            var projetos = _databaseContext.Projeto.Where(x => ProjetosID.Contains(x.ProjetoID)).ToList();
            return projetos;
        }

        public List<Projeto> ListAll() {

            return _databaseContext.Projeto.ToList();
        }

        public ProjetoModelUpdate GetWithMembros(int ProjetoID) {

            var projeto = _databaseContext.Projeto
                .Where(x => x.ProjetoID == ProjetoID).FirstOrDefault();

            var membros = _databaseContext.UsuarioProjeto
                .Where(x => x.ProjetoID == ProjetoID && x.isProjectManager == false).Select(x => x.UsuarioID).ToList();

            ProjetoModelUpdate model = new ProjetoModelUpdate() {
                Title = projeto.Title,
                Description = projeto.Description,
                UrlGit = projeto.UrlGit,
                InitialDate = projeto.InitialDate,
                Membros = membros,
            };

            return model;
        }

        public Projeto Get(int ProjetoID) {

            return _databaseContext.Projeto
                .Where(x => x.ProjetoID == ProjetoID).FirstOrDefault();
        }

        public int Adicionar(Projeto projeto) {

            _databaseContext.Projeto.Add(projeto);
            _databaseContext.SaveChanges();

            return projeto.ProjetoID;

        }

        public Projeto Update(Projeto projeto) {

            _databaseContext.Projeto.Update(projeto);

            _databaseContext.SaveChanges();

            return projeto;
        }

        public void Delete(Projeto projeto) {

            _databaseContext.Projeto.Attach(projeto);
            _databaseContext.Projeto.Remove(projeto);
            _databaseContext.SaveChanges();

        }

    }
}
