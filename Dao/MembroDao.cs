using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.DataBaseConfig;
using Tcc_backend.Entities;

namespace Tcc_backend.Dao {
    public class MembroDao {

        DatabaseContext _databaseContext = new DatabaseContext();

        public List<Membro> GetListMembros(int? ProjetoID) {

            if (ProjetoID != null) {
                var usuarioProjeto = _databaseContext.UsuarioProjeto.Where(x => x.ProjetoID == ProjetoID).Select(x => x.UsuarioID).ToList();

                return _databaseContext.Membro.Where(x => !usuarioProjeto.Contains(x.MembroID)).ToList();

            } else {
                return _databaseContext.Membro.ToList();
            }
            


        }

        public int Add(Membro membro) {

            _databaseContext.Membro.Add(membro);
            _databaseContext.SaveChanges();
            return membro.MembroID;
        }
    }
}
