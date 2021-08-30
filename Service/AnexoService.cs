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
            AnexoDao bAnexo = new AnexoDao();
            return bAnexo.Get(AnexoID);
        }

        public List<Anexo> ListByUserStoryID(int UserStoryID) {
            AnexoDao bAnexo = new AnexoDao();
            return bAnexo.ListByUserStoryId(UserStoryID);
        }

        public int Adicionar(AnexoModelCreate model) {
            AnexoDao bAnexo = new AnexoDao();
            return bAnexo.Adicionar(model);
        }

        public void Delete(int UserStoryID) {
            AnexoDao bAnexo = new AnexoDao();
            bAnexo.Delete(UserStoryID);
        }

    }
}
