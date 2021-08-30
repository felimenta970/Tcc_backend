using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class SprintBusiness {

        SprintDao _dao = new SprintDao();

        public Sprint Get(int SprintID) {
            return _dao.Get(SprintID);
        }

        public List<Sprint> ListByProjeto(int ProjetoID) {
            return _dao.ListByProjeto(ProjetoID);
        }

        public int Adicionar(SprintModelCreate model) {

            var sprint = new Sprint() {
                Title = model.Title,
                ProjetoID = model.ProjetoID,
            };

            return _dao.Adicionar(sprint);

        }

        public Sprint Update(SprintModelUpdate model) {

            var sprint = _dao.Get(model.SprintID);

            sprint.Title = model.Title;

            return _dao.Update(sprint);

        }

        public void Delete(int SprintID) {

            Sprint sprint = new Sprint() {
                SprintID = SprintID,
            };

            _dao.Delete(sprint);

        }
    }
}
