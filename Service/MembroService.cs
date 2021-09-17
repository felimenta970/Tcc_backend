using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Service {
    public class MembroService {

        public List<Membro> GetListMembros() {
            MembroBusiness bMembro = new MembroBusiness();
            return bMembro.GetListMembros();
        }

        public MembroModel EntityToModel(Membro membro) {
            MembroBusiness bMembro = new MembroBusiness();
            return bMembro.EntityToModel(membro);
        }

        public MembroModelCreateReturn CreateMember(MembroModelCreate model) {
            MembroBusiness bMembro = new MembroBusiness();
            return bMembro.CreateMembro(model);
        }
    }
}
