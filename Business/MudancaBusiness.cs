using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class MudancaBusiness {

        MudancaDao _dao = new MudancaDao();

        public List<Mudanca> ListByUserStoryID(int UserStoryID) {
            return _dao.ListByUserStoryID(UserStoryID);
        }

        public int Adicionar(MudancaModelCreate mudancaModel) {

            var mudanca = new Mudanca() {
                UserStoryID = mudancaModel.UserStoryID,
                Description = mudancaModel.Description,
                DataModificacao = DateTime.Now,
                ProjectManagerID = mudancaModel.ProjectManagerID,
                ChangeReason = mudancaModel.ChangeReason
            };

            return _dao.Adicionar(mudanca);
        }

        public void Delete(int mudancaID) {

            Mudanca mudanca = new Mudanca() {
                MudancaID = mudancaID,
            };

            _dao.Delete(mudanca);
        }

        public MudancaModel EntityToModel(Mudanca mudanca) {

            MudancaModel model = new MudancaModel() {
                MudancaID = mudanca.MudancaID,
                UserStoryID = mudanca.UserStoryID,
                Description = mudanca.Description,
                DataModificacao = mudanca.DataModificacao,
                ProjectManagerID = mudanca.ProjectManagerID,
                ChangeReasonString = this.ChangeReasonToString(mudanca.ChangeReason)
            };

            return model;
        }

        public string ChangeReasonToString(Enums.ChangeReason reason) {

            if (reason == Enums.ChangeReason.MudancaResponsavel)
                return "Mudança de responsável";
            if (reason == Enums.ChangeReason.CorrecaoInfo)
                return "Correção de informação";
            if (reason == Enums.ChangeReason.Esclarecimento)
                return "Esclarecimento";
            if (reason == Enums.ChangeReason.Outro)
                return "Outros";
            if (reason == Enums.ChangeReason.Deleted)
                return "Remoção";
            if (reason == Enums.ChangeReason.StatusChange)
                return "Mudança de status";

            return null;
        }
    }
}
