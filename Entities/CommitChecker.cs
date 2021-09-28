using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Entities {
    public class CommitChecker {

        [Key]
        public int CommitCheckedID { get; set; }

        public DateTime lastCheck { get; set; }
    }
}
