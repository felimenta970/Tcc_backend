using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Dao;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class UserStoryBusiness {

        UserStoryDao _dao = new UserStoryDao();
        RelacaoUserStoriesDao _relacaoDao = new RelacaoUserStoriesDao();

        public UserStory Get(int UserStoryID) {
            return _dao.Get(UserStoryID);
        }

        public List<UserStory> ListByProjeto(int ProjetoID) {
            return _dao.ListByProjeto(ProjetoID);
        }

        public List<UserStory> ListBySprint(int SprintID) {
            return _dao.ListBySprint(SprintID);
        }

        public List<UserStory> ListByMembro(int MembroID) {
            return _dao.ListByMembro(MembroID);
        }

        public int Adicionar(UserStoryModelCreate model) {

            var userStory = new UserStory() {
                WhoDesc = model.WhoDesc,
                WhatDesc = model.WhatDesc,
                WhyDesc = model.WhyDesc,
                ProjetoID = model.ProjetoID,
                CreatedAt = DateTime.Now,
                Status = Enums.UserStoryStatus.ToDo,
                MembroID = model.MembroID,
                ProjectManagerID = model.ProjectManagerID,
            };

            var userStoryIDCriado = _dao.Adicionar(userStory);

            if (model.UserStoryPai != null)
                _relacaoDao.AddOrUpdateRelacao(userStoryIDCriado, model.UserStoryPai.Value);

            return userStoryIDCriado;
        }

        public UserStory Update(UserStoryModelUpdate model) {

            var userStory = _dao.Get(model.data.UserStoryID);

            userStory.WhoDesc = model.data.WhoDesc;
            userStory.WhatDesc = model.data.WhatDesc;
            userStory.WhyDesc = model.data.WhyDesc;
            userStory.MembroID = model.data.MembroID;
            userStory.Status = Enums.UserStoryStatus.ToDo;

            MudancaBusiness bMudanca = new MudancaBusiness();

            model.mudanca.UserStoryID = model.data.UserStoryID;
            bMudanca.Adicionar(model.mudanca);

            if (model.data.UserStoryPai != null)
                _relacaoDao.AddOrUpdateRelacao(userStory.UserStoryID, model.data.UserStoryPai.Value);

            return _dao.Update(userStory);

        }

        public void Delete(int UserStoryID) {

            var userStory = this.Get(UserStoryID);

            userStory.Status = Enums.UserStoryStatus.Deleted;

            _dao.Update(userStory);

            Mudanca mudanca = new Mudanca() {
                UserStoryID = UserStoryID,
                ProjectManagerID = 0,
                Description = "História de Usuário apagada",
                ChangeReason = Enums.ChangeReason.Deleted,
                DataModificacao = DateTime.Now,
            };

            MudancaDao _mudancaDao = new MudancaDao();
            _mudancaDao.Adicionar(mudanca);

        }

        public UserStory GetUserStoryPai(int UserStoryID) {

            var relacao = _relacaoDao.GetByUserStoryFilho(UserStoryID);
            if (relacao != null) {
                return this.Get(relacao.HistoriaUsuarioPaiID);
            }
            return null;
        }

        public UserStoryModel EntityToModel(UserStory userStory) {

            UserStoryModel model = new UserStoryModel() {
                UserStoryID = userStory.UserStoryID,
                WhoDesc = userStory.WhoDesc,
                WhatDesc = userStory.WhatDesc,
                WhyDesc = userStory.WhyDesc,
                MembroID = userStory.MembroID,
                ProjectManagerID = userStory.ProjectManagerID,
                SprintID = userStory.SprintID,
                CreatedAt = userStory.CreatedAt,
                Status = userStory.Status,
                ProjetoID = userStory.ProjetoID,
                Description = $"#{userStory.UserStoryID} - Como um {userStory.WhoDesc}, eu quero {userStory.WhatDesc} para que {userStory.WhyDesc}",
            };

            return model;
        }

        public int ChangeStatusUserStory(int UserStoryID, Enums.UserStoryStatus status) {

            var userStory = _dao.Get(UserStoryID);

            userStory.Status = status;

            return _dao.Update(userStory).UserStoryID;
        }

        public void DesassociaUserStorySprint(int UserStoryID) {

            var userStory = _dao.Get(UserStoryID);

            userStory.SprintID = null;

            _dao.Update(userStory);
        }

        public List<UserStory> ListByProjetoSemSprint(int ProjetoID) {

            return _dao.ListByProjetoSemSprint(ProjetoID);
        }

        public List<UserStory> ListDeletedByProjeto(int ProjetoID) {
            return _dao.ListDeletedByProjeto(ProjetoID);
        }

    }
}
