using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.DataBaseConfig;
using Tcc_backend.Entities;

namespace Tcc_backend.Business {
    public class MembroDao {

        DatabaseContext _databaseContext = new DatabaseContext();

        public List<Membro> GetListMembros() {

            var membros = _databaseContext.Membro.ToList();
            return membros;

        }

        public int Add(Membro membro) {

            _databaseContext.Membro.Add(membro);
            _databaseContext.SaveChanges();
            return membro.MembroID;
        }
    }
}
