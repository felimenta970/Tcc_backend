using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class SprintBusiness {

        SprintDao _dao = new SprintDao();
        UserStoryDao _userStoryDao = new UserStoryDao();

        public Sprint Get(int SprintID) {
            return _dao.Get(SprintID);
        }

        public List<Sprint> ListByProjeto(int ProjetoID) {
            return _dao.ListByProjeto(ProjetoID);
        }


        public int Adicionar(SprintModelCreate model) {

            var sprint = new Sprint() {
                Title = model.Title,
                ProjetoID = model.ProjetoID,
            };

            var SprintID = _dao.Adicionar(sprint);

            foreach (var userStoryID in model.UserStories) {
                var userStory = _userStoryDao.Get(userStoryID);
                userStory.SprintID = SprintID;
                _userStoryDao.Update(userStory);
            }

            return SprintID;

        }

        public Sprint Update(SprintModelUpdate model) {

            var sprint = _dao.Get(model.SprintID);

            sprint.Title = model.Title;

            UserStoryBusiness bUserStory = new UserStoryBusiness();
            UserStoryDao userStoryDao = new UserStoryDao();

            foreach (var userStoryID in model.UserStories) {
                var userStory = bUserStory.Get(userStoryID);
                userStory.SprintID = model.SprintID;
                userStoryDao.Update(userStory);

            }

            return _dao.Update(sprint);

        }

        public void Delete(int SprintID) {

            Sprint sprint = new Sprint() {
                SprintID = SprintID,
            };

            _dao.Delete(sprint);

        }

        public SprintModel EntityToModel(Sprint sprint) {

            SprintModel model = new SprintModel() {
                SprintID = sprint.SprintID,
                Title = sprint.Title,
                ProjetoID = sprint.ProjetoID
            };

            return model;
        }
    }
}
