using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Entities;
using Tcc_backend.Models;
using Tcc_backend.Service;

namespace Tcc_backend.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class UserStoryController : ControllerBase {

        UserStoryService sUserStory = new UserStoryService();

        [HttpGet]
        [Route("{UserStoryID}")]
        public UserStoryModel Get([FromRoute] int UserStoryID) {

            var userStory = sUserStory.Get(UserStoryID);

            var model = EntityToModel(userStory);

            return model;
        }

        [HttpGet]
        [Route("/listByProjeto/{ProjetoID}")]
        public List<UserStoryModel> ListByProjeto([FromRoute] int ProjetoID) {

            var userStoryList = sUserStory.ListByProjeto(ProjetoID);

            List<UserStoryModel> modelList = new List<UserStoryModel>();

            foreach(var userStory in userStoryList) {

                var model = EntityToModel(userStory);

                modelList.Add(model);
            }

            return modelList;
            
        }

        [HttpGet]
        [Route("/listByMembro/{MembroID}")]
        public List<UserStoryModel> ListByMembro([FromRoute] int MembroID) {

            var userStoryList = sUserStory.ListByMembro(MembroID);

            List<UserStoryModel> modelList = new List<UserStoryModel>();

            foreach (var userStory in userStoryList) {

                var model = EntityToModel(userStory);

                modelList.Add(model);
            }

            return modelList;
        }

        [HttpPost]
        public int Create([FromBody] UserStoryModelCreate model) {

            int UserStoryID = sUserStory.Adicionar(model);

            return UserStoryID;
        }

        [HttpPut]
        public UserStoryModel Update([FromBody] UserStoryModelUpdate model) {

            var userStory = sUserStory.Update(model);

            var modelResult = this.EntityToModel(userStory);

            return modelResult;

        }

        [HttpDelete]
        [Route("{UserStoryID}")]
        public void Delete([FromRoute] int UserStoryID) {

            sUserStory.Delete(UserStoryID);

        }

        public UserStory ModelToEntity(UserStoryModel model) {

            return new UserStory();
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
