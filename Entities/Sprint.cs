using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Entities {
    public class Sprint {

        [Key]
        public int SprintID { get; set; }

        public string Title { get; set; }

        public int ProjetoID { get; set; }

        [ForeignKey("ProjetoID")]
        public Projeto Projeto { get; set; }

        public List<UserStory> UserStories { get; set; }
    }
}
