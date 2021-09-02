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
            UserStoryBusiness bUserStory = new UserStoryBusiness();
            return bUserStory.Get(UserStoryID);
        }

        public List<UserStory> ListByProjeto(int ProjetoID) {
            UserStoryBusiness bUserStory = new UserStoryBusiness();
            return bUserStory.ListByProjeto(ProjetoID);
        }

        public List<UserStory> ListByMembro(int MembroID) {
            UserStoryBusiness bUserStory = new UserStoryBusiness();
            return bUserStory.ListByMembro(MembroID);
        }

        public List<UserStory> ListBySprint(int SprintID) {
            UserStoryBusiness bUserStory = new UserStoryBusiness();
            return bUserStory.ListBySprint(SprintID);
        }

        public int Adicionar(UserStoryModelCreate model) {
            UserStoryBusiness bUserStory = new UserStoryBusiness();
            return bUserStory.Adicionar(model);
        }

        public UserStory Update(UserStoryModelUpdate model) {
            UserStoryBusiness bUserStory = new UserStoryBusiness();
            return bUserStory.Update(model);
        }

        public void Delete(int UserStoryID) {
            UserStoryBusiness bUserStory = new UserStoryBusiness();
            bUserStory.Delete(UserStoryID);
        }

        public UserStoryModel EntityToModel(UserStory userStory) {
            UserStoryBusiness bUserStory = new UserStoryBusiness();
            return bUserStory.EntityToModel(userStory);
        }
    }

    
}
