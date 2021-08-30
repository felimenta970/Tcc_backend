using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Entities;

namespace Tcc_backend.Business {
    public class MudancaBusiness {

        MudancaDao _dao = new MudancaDao();

        public List<Mudanca> ListByUserStoryID(int UserStoryID) {
            return _dao.ListByUserStoryID(UserStoryID);
        }

        public int Adicionar(Mudanca mudanca) {
            return _dao.Adicionar(mudanca);
        }

        public void Delete(int mudancaID) {

            Mudanca mudanca = new Mudanca() {
                MudancaID = mudancaID,
            };

            _dao.Delete(mudanca);
        }
    }
}
