﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Entities;

namespace Tcc_backend.Models {
    public class UserStoryModel {

        public int UserStoryID { get; set; }

        public string Description { get; set; }

        public int MembroID { get; set; }

        public int ProjectManagerID { get; set; }

        public int SprintID { get; set; }

        public DateTime CreatedAt { get; set; }

        public Enums.UserStoryStatus Status { get; set; }

        public int ProjetoID { get; set; }

    }

    public class UserStoryModelCreate {

        public string Description { get; set; }

        public int ProjetoID { get; set; }
    }

    public class UserStoryModelUpdate {

        public UserStoryModelUpdateData data { get; set; }

        public MudancaModelCreate mudanca { get; set; }
    }

    public class UserStoryModelUpdateData {
        public int UserStoryID { get; set; }

        public string Description { get; set; }

        public int MembroID { get; set; }

        public int SprintID { get; set; }

        public Enums.UserStoryStatus Status { get; set; }

    }
}

