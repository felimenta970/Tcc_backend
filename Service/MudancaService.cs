using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business;
using Tcc_backend.Entities;

namespace Tcc_backend.Service {
    public class MudancaService {

        public List<Mudanca> ListByUserStoryID(int UserStoryID) {
            MudancaDao bMudanca = new MudancaDao();
            return bMudanca.ListByUserStoryID(UserStoryID);
        }

        public int Adicionar(Mudanca mudanca) {
            MudancaDao bMudanca = new MudancaDao();
            return bMudanca.Adicionar(mudanca);
        }

        public void Delete(int MudancaID) {
            MudancaDao bMudanca = new MudancaDao();
            bMudanca.Delete(MudancaID);
        }
    }
}
