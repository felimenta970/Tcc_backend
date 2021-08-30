using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Service {
    public class UserStoryService {

        public UserStory Get(int UserStoryID) {
            UserStoryDao bUserStory = new UserStoryDao();
            return bUserStory.Get(UserStoryID);
        }

        public List<UserStory> ListByProjeto(int ProjetoID) {
            UserStoryDao bUserStory = new UserStoryDao();
            return bUserStory.ListByProjeto(ProjetoID);
        }

        public List<UserStory> ListByMembro(int MembroID) {
            UserStoryDao bUserStory = new UserStoryDao();
            return bUserStory.ListByMembro(MembroID);
        }

        public int Adicionar(UserStoryModelCreate model) {
            UserStoryDao bUserStory = new UserStoryDao();
            return bUserStory.Adicionar(model);
        }

        public UserStory Update(UserStoryModelUpdate model) {
            UserStoryDao bUserStory = new UserStoryDao();
            return bUserStory.Update(model);
        }

        public void Delete(int UserStoryID) {
            UserStoryDao bUserStory = new UserStoryDao();
            bUserStory.Delete(UserStoryID);
        }
    }
}
