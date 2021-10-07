using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Models {
    public class RelatoriosModel {

        public List<int> qtddMudancas { get; set; } = new List<int>();

        public List<string> label { get; set; } = new List<string>();

        public List<int> UserStoryID { get; set; } = new List<int>();
    }
}
