using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Entities {
    public class Membro : Usuario {

        [Key]
        public int MembroID { get; set; }
    }
}
