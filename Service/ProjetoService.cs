using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Service {
    public class ProjetoService {

        public List<Projeto> List() {
            ProjetoDao bProjeto = new ProjetoDao();
            return bProjeto.List();
        }

        public Projeto Get(int ProjetoID) {
            ProjetoDao bProjeto = new ProjetoDao();
            return bProjeto.Get(ProjetoID);
        }

        public int Adicionar(ProjetoModelCreate projetoModel) {
            ProjetoDao bProjeto = new ProjetoDao();
            return bProjeto.Adicionar(projetoModel);
        }

        public Projeto Update(ProjetoModelUpdate projetoModel) {
            ProjetoDao bProjeto = new ProjetoDao();
            return bProjeto.Update(projetoModel);
        }
    }
}
