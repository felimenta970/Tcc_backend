using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Models;
using static Tcc_backend.Entities.Enums;

namespace Tcc_backend.Business {
    public class RelatorioBusiness {


        public RelatoriosModel RelatorioMudancasPorUserStory(int ProjetoID) {

            UserStoryDao _userStoryDao = new UserStoryDao();
            MudancaDao _mudancaDao = new MudancaDao();

            var listUserStories = _userStoryDao.ListByProjeto(ProjetoID);

            RelatoriosModel model = new RelatoriosModel();

            int count = 0;
           
            foreach(var userStory in listUserStories) {

                count = _mudancaDao.ListByUserStoryID(userStory.UserStoryID).Count;

                model.UserStoryID.Add(userStory.UserStoryID);
                model.qtddMudancas.Add(count);
                model.label.Add($"#{userStory.UserStoryID}");
            }

            return model;
        }

        public List<int> RelatorioMudancasPorTipo(int ProjetoID) {

            UserStoryDao _userStoryDao = new UserStoryDao();
            MudancaDao _mudancaDao = new MudancaDao();

            var listUserStories = _userStoryDao.ListByProjetoAll(ProjetoID);

            RelatoriosModel model = new RelatoriosModel();

            int countEsclarecimento = 0;
            int countMudancaResp = 0;
            int countCorrecaoInfo = 0;
            int countImpTecnica = 0;
            int countMudancaStatus = 0;
            int countOutros = 0;
            int countDeleted = 0;

            foreach (var userStory in listUserStories) {

                var mudancas = _mudancaDao.ListByUserStoryID(userStory.UserStoryID);

                foreach (var mudanca in mudancas) {

                    if (mudanca.ChangeReason == ChangeReason.Esclarecimento)
                        countEsclarecimento++;
                    if (mudanca.ChangeReason == ChangeReason.MudancaResponsavel)
                        countMudancaResp++;
                    if (mudanca.ChangeReason == ChangeReason.CorrecaoInfo)
                        countCorrecaoInfo++;
                    if (mudanca.ChangeReason == ChangeReason.ImpossibilidadeTecnica)
                        countImpTecnica++;
                    if (mudanca.ChangeReason == ChangeReason.Outro)
                        countOutros++;
                    if (mudanca.ChangeReason == ChangeReason.Deleted)
                        countDeleted++;
                    if (mudanca.ChangeReason == ChangeReason.StatusChange)
                        countMudancaStatus++;
                }

            }

            List<int> contagem = new List<int>();
            contagem.Add(countEsclarecimento);
            contagem.Add(countMudancaResp);
            contagem.Add(countCorrecaoInfo);
            contagem.Add(countImpTecnica);
            contagem.Add(countMudancaStatus);
            contagem.Add(countDeleted);
            contagem.Add(countOutros);

            return contagem;

        }

        public List<int> RelatorioUserStoriesPorStatus(int ProjetoID) {

            UserStoryDao _userStoryDao = new UserStoryDao();

            var listUserStories = _userStoryDao.ListByProjetoAll(ProjetoID);


            int countAFazer = 0;
            int countEmProgresso = 0;
            int countFinalizado = 0;
            int countApagados = 0;

            foreach(var userStory in listUserStories) {

                if (userStory.Status == UserStoryStatus.ToDo)
                    countAFazer++;
                if (userStory.Status == UserStoryStatus.InProgress)
                    countEmProgresso++;
                if (userStory.Status == UserStoryStatus.Done)
                    countFinalizado++;
                if (userStory.Status == UserStoryStatus.Deleted)
                    countApagados++;
            }

            List<int> contagem = new List<int>();
            contagem.Add(countAFazer);
            contagem.Add(countEmProgresso);
            contagem.Add(countFinalizado);
            contagem.Add(countApagados);

            return contagem;

        }

    }
}
