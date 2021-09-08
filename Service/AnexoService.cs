using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Service {
    public class AnexoService {

        public Anexo Get(int AnexoID) {
            AnexoBusiness bAnexo = new AnexoBusiness();
            return bAnexo.Get(AnexoID);
        }

        public List<Anexo> ListByUserStoryID(int UserStoryID) {
            AnexoBusiness bAnexo = new AnexoBusiness();
            return bAnexo.ListByUserStoryId(UserStoryID);
        }

        public int Adicionar(AnexoModelCreate model) {
            AnexoBusiness bAnexo = new AnexoBusiness();
            return bAnexo.Adicionar(model);
        }

        public void Delete(int UserStoryID) {
            AnexoBusiness bAnexo = new AnexoBusiness();
            bAnexo.Delete(UserStoryID);
        }

        public Anexo Update(AnexoModelEdit model) {
            AnexoBusiness bAnexo = new AnexoBusiness();
            return bAnexo.Update(model);
        }

        public AnexoModel EntityToModel(Anexo anexo) {
            AnexoBusiness bAnexo = new AnexoBusiness();
            return bAnexo.EntityToModel(anexo);
        }

    }
}
