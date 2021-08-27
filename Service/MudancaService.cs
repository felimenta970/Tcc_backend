using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business;
using Tcc_backend.Entities;

namespace Tcc_backend.Service {
    public class MudancaService {

        public List<Mudanca> ListByUserStoryID(int UserStoryID) {
            MudancaBusiness bMudanca = new MudancaBusiness();
            return bMudanca.ListByUserStoryID(UserStoryID);
        }

        public int Adicionar(Mudanca mudanca) {
            MudancaBusiness bMudanca = new MudancaBusiness();
            return bMudanca.Adicionar(mudanca);
        }

        public void Delete(int MudancaID) {
            MudancaBusiness bMudanca = new MudancaBusiness();
            bMudanca.Delete(MudancaID);
        }
    }
}
