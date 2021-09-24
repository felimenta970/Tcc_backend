using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Entities {
    public class RelacaoUserStory {

        public int RelacaoUserStoryID { get; set; }

        public int HistoriaUsuarioPaiID { get; set; }

        public int HistoriaUsuarioFilhoID { get; set; }
    }
}
