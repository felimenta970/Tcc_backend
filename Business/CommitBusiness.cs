using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.DataBaseConfig;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class CommitBusiness {

        DatabaseContext _databaseContext = new DatabaseContext();

        public Commit Get(int CommitID) {

            var commit = _databaseContext.Commit
                .Where(x => x.CommitID == CommitID).FirstOrDefault();

            return commit;
        }

        public List<Commit> ListByUserStoryID(int UserStoryID) {

            var commits = _databaseContext.Commit
                .Where(x => x.UserStoryID == UserStoryID).ToList();

            return commits;
        }

        public int Adicionar(CommitModelCreate model) {

            var commit = new Commit() {
                Author = model.Author,
                Message = model.Message,
                UserStoryID = model.UserStoryID,
            };

            var commitID = _databaseContext.Commit.Add(commit);

            _databaseContext.SaveChanges();

            return commit.CommitID;
        }

        public void Delete(int CommitID) {

            Commit commit = new Commit() {
                CommitID = CommitID,
            };

            _databaseContext.Commit.Attach(commit);
            _databaseContext.Commit.Remove(commit);
            _databaseContext.SaveChanges();
        }
    }
}
