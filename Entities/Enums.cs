using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Entities {
    public class Enums {

        public enum UserStoryStatus {
            ToDo = 1,
            InProgress = 2,
            Done = 3,
            Deleted = 4,
        }

        public enum TypeAnexo {
            Imagem = 1,
            Video = 2,
            Audio = 3,
            Texto = 4,
            Outros = 5
        }

        public enum ChangeReason {
            Esclarecimento = 1,
            MudancaResponsavel = 2,
            CorrecaoInfo = 3,
            ImpossibilidadeTecnica = 4,
            Outro = 5,
            Deleted = 6,
            StatusChange = 7
        }
    }


}
