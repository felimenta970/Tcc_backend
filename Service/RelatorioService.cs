using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business;
using Tcc_backend.Models;

namespace Tcc_backend.Service {
    public class RelatorioService {

        public RelatoriosModel RelatorioMudancasPorUserStory(int ProjetoID) {
            RelatorioBusiness bRelatorio = new RelatorioBusiness();
            return bRelatorio.RelatorioMudancasPorUserStory(ProjetoID);
        }

        public List<int> RelatorioMudancasPorTipo(int ProjetoID) {
            RelatorioBusiness bRelatorio = new RelatorioBusiness();
            return bRelatorio.RelatorioMudancasPorTipo(ProjetoID);        }
    }
}
