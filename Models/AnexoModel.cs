using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Entities;

namespace Tcc_backend.Models {
    public class AnexoModel {

        public int AnexoID { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public Enums.TypeAnexo TipoAnexo { get; set; }

        public int UserStoryID { get; set; }
    }

    public class AnexoModelCreate {

        public string Url { get; set; }

        public string Name { get; set; }

        public Enums.TypeAnexo TipoAnexo { get; set; }

        public int UserStoryID { get; set; }
    }
}
