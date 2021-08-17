using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Entities {
    public class ProjectManager : Usuario {

        [Key]
        public int ProjectManagerID { get; set; }
    }
}
