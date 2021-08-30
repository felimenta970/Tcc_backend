using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Models {
    public class SprintModel {

        public int SprintID { get; set; }

        public string Title { get; set; }

        public int ProjetoID { get; set; }
    }

    public class SprintModelCreate {

        public string Title { get; set; }

        public int ProjetoID { get; set; }

    }

    public class SprintModelUpdate {

        public int SprintID { get; set; }

        public string Title { get; set; }

    }
}
