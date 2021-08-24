﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.DataBaseConfig;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class UserStoryBusiness {

        DatabaseContext _databaseContext = new DatabaseContext();

        public UserStory Get(int UserStoryID) {

            var userStory = _databaseContext.UserStory
                .Where(x => x.UserStoryID == UserStoryID).FirstOrDefault();

            return userStory;
        }

        public List<UserStory> ListByProjeto(int ProjetoID) {

            var userStories = _databaseContext.UserStory
                .Where(x => x.ProjetoID == ProjetoID).ToList();

            return userStories;

        }

        public List<UserStory> ListByMembro(int MembroID) {

            var userStories = _databaseContext.UserStory
                .Where(x => x.MembroID == MembroID).ToList();

            return userStories;

        }

        public int Adicionar(UserStoryModelCreate model) {

            var userStory = new UserStory() {
                Description = model.Description,
                ProjetoID = model.ProjetoID,
                CreatedAt = DateTime.Now,
            };

            _databaseContext.UserStory.Add(userStory);

            return userStory.UserStoryID;
        }

        public UserStory Update(UserStoryModelUpdate model) {

            var userStory = this.Get(model.UserStoryID);

            userStory.Description = model.Description;
            userStory.MembroID = model.MembroID;
            userStory.SprintID = model.SprintID;

            _databaseContext.UserStory.Update(userStory);

            return userStory;
        }

        public void Delete(int UserStoryID) {

            var userStory = this.Get(UserStoryID);

            _databaseContext.UserStory.Remove(userStory);
        }

    }
}