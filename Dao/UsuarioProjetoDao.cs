using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.DataBaseConfig;

namespace Tcc_backend.Dao {
    public class UsuarioProjetoDao {

        DatabaseContext _databaseContext = new DatabaseContext();

        public List<int> ListProjetosByUsuario(int UsuarioID) {

            return _databaseContext.UsuarioProjeto.Where(x => x.UsuarioID == UsuarioID).Select(x => x.ProjetoID).ToList();
        }
    }
}
