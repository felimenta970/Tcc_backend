using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.DataBaseConfig;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class UserStoryDao {

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

        public List<UserStory> ListBySprint(int SprintID) {

            var userStories = _databaseContext.UserStory
                .Where(x => x.SprintID == SprintID).ToList();

            return userStories;

        }

        public List<UserStory> ListByMembro(int MembroID) {

            var userStories = _databaseContext.UserStory
                .Where(x => x.MembroID == MembroID).ToList();

            return userStories;

        }

        public int Adicionar(UserStory userStory) {

            _databaseContext.UserStory.Add(userStory);
            _databaseContext.SaveChanges();

            return userStory.UserStoryID;
        }

        public UserStory Update(UserStory userStory) {

            _databaseContext.UserStory.Update(userStory);
            _databaseContext.SaveChanges();

            return userStory;
        }

        public void Delete(UserStory userStory) {

            _databaseContext.UserStory.Attach(userStory);
            _databaseContext.UserStory.Remove(userStory);
            _databaseContext.SaveChanges();
        }

        public List<UserStory> ListByProjetoSemSprint(int ProjetoID) {

            return _databaseContext.UserStory.Where(x => x.ProjetoID == ProjetoID && x.SprintID == null).ToList();
        }
    }
}
