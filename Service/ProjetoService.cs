using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Service {
    public class ProjetoService {

        public List<Projeto> List(int UsuarioID) {
            ProjetoBusiness bProjeto = new ProjetoBusiness();
            return bProjeto.List(UsuarioID);
        }

        public Projeto Get(int ProjetoID) {
            ProjetoBusiness bProjeto = new ProjetoBusiness();
            return bProjeto.Get(ProjetoID);
        }

        public int Adicionar(ProjetoModelCreate projetoModel) {
            ProjetoBusiness bProjeto = new ProjetoBusiness();
            return bProjeto.Adicionar(projetoModel);
        }

        public Projeto Update(ProjetoModelUpdate projetoModel) {
            ProjetoBusiness bProjeto = new ProjetoBusiness();
            return bProjeto.Update(projetoModel);
        }

        public ProjetoModel EntityToModel(Projeto projeto) {
            ProjetoBusiness bProjeto = new ProjetoBusiness();
            return bProjeto.EntityToModel(projeto);
        }

        public void DesasociaMembroProjeto(int membroID, int projetoID) {
            ProjetoBusiness bProjeto = new ProjetoBusiness();
            bProjeto.DesasociaMembroProjeto(membroID, projetoID);
        }
    }
}
