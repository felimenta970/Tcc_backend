using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Entities {
    public class Anexo {

        [Key]
        public int AnexoID { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public Enums.TypeAnexo TipoAnexo { get; set; }

        [ForeignKey("UserStoryID")]
        public UserStory UserStory { get; set; }

        public int UserStoryID { get; set; }
    }
}
