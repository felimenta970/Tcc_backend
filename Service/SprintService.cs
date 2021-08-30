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
            SprintDao bSprint = new SprintDao();
            return bSprint.ListByProjeto(ProjetoID);
        }

        public Sprint Get(int SprintID) {
            SprintDao bSprint = new SprintDao();
            return bSprint.Get(SprintID);
        }

        public int Adicionar(SprintModelCreate model) {
            SprintDao bSprint = new SprintDao();
            return bSprint.Adicionar(model);
        }

        public Sprint Update(SprintModelUpdate model) {
            SprintDao bSprint = new SprintDao();
            return bSprint.Update(model);
        }

        public void Delete(int SprintID) {
            SprintDao bSprint = new SprintDao();
            bSprint.Delete(SprintID);
        }
    }
}
