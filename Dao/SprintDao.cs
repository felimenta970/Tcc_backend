using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business.Base;
using Tcc_backend.DataBaseConfig;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class SprintDao : BusinessBase {

        DatabaseContext _databaseContext = new DatabaseContext();

        public List<Sprint> ListByProjeto(int ProjetoID) {

            var sprints = _databaseContext.Sprint
                .Where(x => x.ProjetoID == ProjetoID).ToList();

            return sprints;
        }

        public Sprint Get(int SprintID) {

            var sprint = _databaseContext.Sprint
                .Where(x => x.SprintID == SprintID).FirstOrDefault();

            return sprint;
        }

        public int Adicionar(Sprint sprint) {

            _databaseContext.Sprint.Add(sprint);
            _databaseContext.SaveChanges();

            return sprint.SprintID;
        }

        public Sprint Update(Sprint sprint) {

            _databaseContext.Sprint.Update(sprint);
            _databaseContext.SaveChanges();

            return sprint;
        }

        public void Delete(Sprint sprint) {

            _databaseContext.Sprint.Attach(sprint);
            _databaseContext.Sprint.Remove(sprint);
            _databaseContext.SaveChanges();
        }

    }
}
