using Microsoft.AspNetCore.Http;
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
    public class MembroController : ControllerBase {

        [HttpGet]
        [Route("userStories/{MembroID}")]
        public IActionResult  ListByMembro([FromRoute] int MembroID) {

            UserStoryService sUserStory = new UserStoryService();

            var userStoryList = sUserStory.ListByMembro(MembroID);

            List<UserStoryModel> modelList = new List<UserStoryModel>();

            foreach (var userStory in userStoryList) {

                var model = sUserStory.EntityToModel(userStory);

                modelList.Add(model);
            }

            if (modelList.Count == 0) {
                return NotFound();
            }

            return Ok(modelList);
        }

        [HttpGet]
        public IActionResult ListMembros() {

            MembroService sMembro = new MembroService();

            List<Membro> listEntity = sMembro.GetListMembros();
            List<MembroModel> listModel = new List<MembroModel>();

            if (listEntity.Count == 0) {
                return NoContent();
            }

            foreach (var entity in listEntity) {
                var modelItem = sMembro.EntityToModel(entity);
                listModel.Add(modelItem);
            }

            return Ok(listModel);

        }

        [HttpPost]
        public IActionResult CreateMember(MembroModelCreate model) {

            MembroService sMembro = new MembroService();

            var result = sMembro.CreateMember(model);

            return Ok(result);
        }
    }

}
