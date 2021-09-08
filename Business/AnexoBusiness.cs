using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class AnexoBusiness {

        AnexoDao _dao = new AnexoDao();

        public Anexo Get(int AnexoID) {
            return _dao.Get(AnexoID);
        }

        public List<Anexo> ListByUserStoryId(int UserStoryID) {
            return _dao.ListByUserStoryId(UserStoryID);
        }

        public int Adicionar(AnexoModelCreate model) {
            var anexo = new Anexo() {
                Url = model.Url,
                Name = model.Name,
                TipoAnexo = model.TipoAnexo,
                UserStoryID = model.UserStoryID,
            };

            return _dao.Adicionar(anexo);
        }

        public Anexo Update(AnexoModelEdit model) {

            var anexo = _dao.Get(model.AnexoID);

            anexo.Name = model.Name;
            anexo.TipoAnexo = model.TipoAnexo;
            anexo.Url = model.Url;

            return _dao.Update(anexo);
        }

        public void Delete(int UserStoryID) {

            Anexo anexo = new Anexo() {
                UserStoryID = UserStoryID,
            };

            _dao.Delete(anexo);
        }

        public AnexoModel EntityToModel(Anexo anexo) {

            AnexoModel anexoModel = new AnexoModel() {
                AnexoID = anexo.AnexoID,
                Url = anexo.Url,
                Name = anexo.Name,
                TipoAnexo = anexo.TipoAnexo,
                UserStoryID = anexo.UserStoryID
            };

            return anexoModel;
        }

    }
}
