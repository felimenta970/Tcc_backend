using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business.Base;
using Tcc_backend.DataBaseConfig;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class ProjetoDao : BusinessBase {

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
