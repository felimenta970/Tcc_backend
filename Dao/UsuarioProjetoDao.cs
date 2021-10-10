using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.DataBaseConfig;
using Tcc_backend.Entities;

namespace Tcc_backend.Dao {
    public class UsuarioProjetoDao {

        DatabaseContext _databaseContext = new DatabaseContext();

        public List<int> ListProjetosByUsuario(int UsuarioID) {

            return _databaseContext.UsuarioProjeto.Where(x => x.UsuarioID == UsuarioID).Select(x => x.ProjetoID).ToList();
        }

        public UsuarioProjeto GetByMembroProjeto(int membroID, int ProjetoID) {

            return _databaseContext.UsuarioProjeto.FirstOrDefault(x => x.UsuarioID == membroID && x.ProjetoID == ProjetoID && x.isProjectManager == false);
        }

        public void Delete(UsuarioProjeto usuarioProjeto) {

            _databaseContext.UsuarioProjeto.Remove(usuarioProjeto);
            _databaseContext.SaveChanges();
        }
    }
}
