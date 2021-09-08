using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Models;
using Tcc_backend.Service;

namespace Tcc_backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CommitController : ControllerBase {

        CommitService sCommit = new CommitService();

        [HttpGet("{userStoryID}")]
        public IActionResult GetByUserStory([FromQuery] int UserStoryID) {

            var commits = sCommit.ListByUserStoryID(UserStoryID);

            List<CommitModel> models = new List<CommitModel>();
            foreach (var commit in commits) {
                var model = sCommit.EntityToModel(commit);
                models.Add(model);
            }

            if (models.Count == 0) {
                return NotFound();
            }

            return Ok(models);
            
        }
    }
}
