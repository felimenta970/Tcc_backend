using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Service {
    public class SprintService {

        public List<Sprint> ListByProjeto(int ProjetoID) {
            SprintBusiness bSprint = new SprintBusiness();
            return bSprint.ListByProjeto(ProjetoID);
        }

        public Sprint Get(int SprintID) {
            SprintBusiness bSprint = new SprintBusiness();
            return bSprint.Get(SprintID);
        }

        public int Adicionar(SprintModelCreate model) {
            SprintBusiness bSprint = new SprintBusiness();
            return bSprint.Adicionar(model);
        }

        public Sprint Update(SprintModelUpdate model) {
            SprintBusiness bSprint = new SprintBusiness();
            return bSprint.Update(model);
        }

        public void Delete(int SprintID) {
            SprintBusiness bSprint = new SprintBusiness();
            bSprint.Delete(SprintID);
        }
    }
}
