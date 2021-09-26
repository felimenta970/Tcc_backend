using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Entities;

namespace Tcc_backend.Models {
    public class UserStoryModel {

        public int UserStoryID { get; set; }

        public string WhoDesc { get; set; }

        public string WhatDesc { get; set; }

        public string WhyDesc { get; set; }

        public int MembroID { get; set; }

        public int ProjectManagerID { get; set; }

        public int? SprintID { get; set; }

        public DateTime CreatedAt { get; set; }

        public Enums.UserStoryStatus Status { get; set; }

        public int ProjetoID { get; set; }

        public List<Commit> Commits { get; set; }

        public List<AnexoModel> Anexos { get; set; }

        public string MembroName { get; set; }

        public int UserStoryPaiID { get; set; }

        public string Description { get; set; }
    }

    public class UserStoryModelCreate {

        public string WhoDesc { get; set; }

        public string WhatDesc { get; set; }

        public string WhyDesc { get; set; }

        public int ProjetoID { get; set; }

        public int MembroID { get; set; }

        public int ProjectManagerID { get; set; }

        public int? UserStoryPai { get; set; }
    }

    public class UserStoryModelUpdate {

        public UserStoryModelUpdateData data { get; set; }

        public MudancaModelCreate mudanca { get; set; }
    }

    public class UserStoryModelUpdateData {

        public int UserStoryID { get; set; }

        public string WhoDesc { get; set; }

        public string WhatDesc { get; set; }

        public string WhyDesc { get; set; }

        public int MembroID { get; set; }

        public int? UserStoryPai { get; set; }

    }

    public class UserStoryModelUpdateStatus {

        public Enums.UserStoryStatus Status { get; set; }

        public int UserStoryID { get; set; }
    }
}

