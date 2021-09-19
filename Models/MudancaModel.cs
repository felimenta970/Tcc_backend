using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Entities;

namespace Tcc_backend.Models {
    public class MudancaModel {

        public int MudancaID { get; set; }

        public int UserStoryID { get; set; }

        public string Description { get; set; }

        public DateTime DataModificacao { get; set; }

        public int ProjectManagerID { get; set; }
    }

    public class MudancaModelCreate {

        public int UserStoryID { get; set; }

        public string Description { get; set; }

        public Enums.ChangeReason ChangeReason { get; set; }

        public int ProjectManagerID { get; set; }
    }
}
