﻿using System;
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

            UserStory userStory = new UserStory() {
                UserStoryID = UserStoryID,
            };

            _dao.Delete(userStory);
        }

        public UserStory GetUserStoryPai(int UserStoryID) {

            var relacao = _relacaoDao.GetByUserStoryFilho(UserStoryID);
            return this.Get(relacao.HistoriaUsuarioPaiID);
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
            };

            return model;
        }

        public int ChangeStatusUserStory(int UserStoryID, Enums.UserStoryStatus status) {

            var userStory = _dao.Get(UserStoryID);

            userStory.Status = status;

            return _dao.Update(userStory).UserStoryID;
        }


    }
}
