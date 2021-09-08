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

        public List<UserStory> ListBySprint(int SprintID) {
            return _dao.ListBySprint(SprintID);
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

            var userStory = _dao.Get(model.data.UserStoryID);

            userStory.Description = model.data.Description;
            userStory.MembroID = model.data.MembroID;
            userStory.SprintID = model.data.SprintID;
            userStory.Status = model.data.Status;

            MudancaBusiness bMudanca = new MudancaBusiness();

            bMudanca.Adicionar(model.mudanca);

            return _dao.Update(userStory);

        }

        public void Delete(int UserStoryID) {

            UserStory userStory = new UserStory() {
                UserStoryID = UserStoryID,
            };

            _dao.Delete(userStory);
        }

        public UserStoryModel EntityToModel(UserStory userStory) {

            UserStoryModel model = new UserStoryModel() {
                UserStoryID = userStory.UserStoryID,
                Description = userStory.Description,
                MembroID = userStory.MembroID,
                ProjectManagerID = userStory.ProjectManagerID,
                SprintID = userStory.SprintID,
                CreatedAt = userStory.CreatedAt,
                Status = userStory.Status,
                ProjetoID = userStory.ProjetoID,
            };

            return model;
        }


    }
}
