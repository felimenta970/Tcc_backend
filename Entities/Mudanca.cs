using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Entities {
    public class Mudanca {

        [Key]
        public int MudancaID { get; set; }

        [ForeignKey("UserStoryID")]
        public UserStory UserStory { get; set; }

        public int UserStoryID { get; set; }

        public string Description { get; set; }

        public DateTime DataModificacao { get; set; }

        public int ProjectManagerID { get; set; }

        [ForeignKey("ProjectManagerID")]
        public ProjectManager ProjectManager { get; set; }

    }
}
