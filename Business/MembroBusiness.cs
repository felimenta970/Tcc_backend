using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class MembroBusiness {

        MembroDao _dao = new MembroDao();

        public List<Membro> GetListMembros() {
            var membros = _dao.GetListMembros();
            return membros;
        }

        public MembroModel EntityToModel(Membro membro) {

            MembroModel model = new MembroModel() {
                Nome = membro.Name,
                MembroID = membro.MembroID
            };

            return model;
        }

    }
}
