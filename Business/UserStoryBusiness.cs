using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class UserStoryBusiness {

        UserStoryDao _dao = new UserStoryDao();

        public UserStory Get(int UserStoryID) {
            return _dao.Get(UserStoryID);
        }

        public List<UserStory> ListByProjeto(int ProjetoID) {
            return _dao.ListByProjeto(ProjetoID);
        }

        public List<UserStory> ListByMembro(int MembroID) {
            return _dao.ListByMembro(MembroID);
        }

        public int Adicionar(UserStoryModelCreate model) {

            var userStory = new UserStory() {
                Description = model.Description,
                ProjetoID = model.ProjetoID,
                CreatedAt = DateTime.Now,
                Status = Enums.UserStoryStatus.ToDo,
            };

            return _dao.Adicionar(userStory);
        }

        public UserStory Update(UserStoryModelUpdate model) {

            var userStory = _dao.Get(model.UserStoryID);

            userStory.Description = model.Description;
            userStory.MembroID = model.MembroID;
            userStory.SprintID = model.SprintID;
            userStory.Status = model.Status;

            return _dao.Update(userStory);
        }

        public void Delete(int UserStoryID) {

            UserStory userStory = new UserStory() {
                UserStoryID = UserStoryID,
            };

            _dao.Delete(userStory);
        }
    }
}
