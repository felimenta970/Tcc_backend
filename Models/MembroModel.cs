using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Models {
    public class MembroModel {

        public int MembroID { get; set; }

        public string Nome { get; set; }
    }

    public class MembroModelCreate {

        public string Nome { get; set; }

        public string UserName { get; set; }

    }

    public class MembroModelCreateReturn {

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
