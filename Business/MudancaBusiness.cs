using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.DataBaseConfig;
using Tcc_backend.Entities;

namespace Tcc_backend.Business {
    public class MudancaBusiness {

        DatabaseContext _databaseContext = new DatabaseContext();

        public List<Mudanca> ListByUserStoryID(int UserStoryID) {

            var mudancas = _databaseContext.Mudanca
                .Where(x => x.UserStoryID == UserStoryID).ToList();

            return mudancas;
        }

        public int Adicionar(Mudanca mudanca) {

            _databaseContext.Mudanca.Add(mudanca);

            _databaseContext.SaveChanges();

            return mudanca.MudancaID;
        }
    }
}
