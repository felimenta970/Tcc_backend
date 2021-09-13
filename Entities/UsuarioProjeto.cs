using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Entities {
    public class UsuarioProjeto {

        public int UsuarioProjetoID { get; set; }

        public int UsuarioID { get; set; }

        public bool isProjectManager { get; set; }

        public int ProjetoID { get; set; }

        [ForeignKey("ProjetoID")]
        public Projeto Projeto { get; set; }
    }
}
