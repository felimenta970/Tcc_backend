using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.DataBaseConfig;
using Tcc_backend.Entities;

namespace Tcc_backend.Business {
    public class MudancaDao {

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

        public void Delete(Mudanca mudanca) {


            _databaseContext.Mudanca.Attach(mudanca);
            _databaseContext.Mudanca.Remove(mudanca);
            _databaseContext.SaveChanges();

        }

    }
}
