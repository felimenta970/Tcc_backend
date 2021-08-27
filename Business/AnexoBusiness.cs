using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.DataBaseConfig;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class AnexoBusiness {

        DatabaseContext _databaseContext = new DatabaseContext();

        public Anexo Get(int AnexoID) {

            var anexo = _databaseContext.Anexo
                .Where(x => x.AnexoID == AnexoID).FirstOrDefault();

            return anexo;
        }

        public List<Anexo> ListByUserStoryId(int UserStoryID) {

            var anexos = _databaseContext.Anexo
                .Where(x => x.UserStoryID == UserStoryID).ToList();

            return anexos;
        }

        public int Adicionar(AnexoModelCreate model) {

            var anexo = new Anexo() {
                Url = model.Url,
                Name = model.Name,
                TipoAnexo = model.TipoAnexo,
                UserStoryID = model.UserStoryID,
            };

            _databaseContext.Anexo.Add(anexo);

            _databaseContext.SaveChanges();

            return anexo.AnexoID;
        }

        public void Delete(int UserStoryID) {

            Anexo anexo = new Anexo() {
                UserStoryID = UserStoryID,
            };

            _databaseContext.Anexo.Attach(anexo);
            _databaseContext.Anexo.Remove(anexo);
            _databaseContext.SaveChanges();
        }
    }
}
