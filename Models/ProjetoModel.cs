using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Models {
    public class ProjetoModel {

        public int ProjetoID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime InitialDate { get; set; }

        public string UrlGit { get; set; }
    }

    public class ProjetoModelCreate {

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime InitialDate { get; set; }

        public string UrlGit { get; set; }

    }
}
