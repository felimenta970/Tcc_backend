using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Entities {
    public class UserStory {

        [Key]
        public int UserStoryID { get; set; }

        public string WhoDesc { get; set; }

        public string WhatDesc { get; set; }

        public string WhyDesc { get; set; }

        [ForeignKey("MembroID")]
        public Membro Membro { get; set; }

        public int MembroID { get; set; }

        public int ProjectManagerID { get; set; }

        [ForeignKey("ProjectManagerID")]
        public ProjectManager ProjectManager { get; set; }

        public int? SprintID { get; set; }

        public DateTime CreatedAt { get; set; }

        public Enums.UserStoryStatus Status { get; set; }

        [ForeignKey("ProjetoID")]
        public Projeto Projeto { get; set; }

        public int ProjetoID { get; set; }

        public List<Commit> Commits { get; set; }

        public List<Anexo> Anexos { get; set; }

    }
}
