using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Entities {
    public class Projeto {

        [Key]
        public int ProjetoID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime InitialDate { get; set; }

        public string UrlGit { get; set; }

        public List<Sprint> Sprints { get; set; }

        public List<UserStory> UserStories { get; set; }
    }
}
