using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.DataBaseConfig;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class CommitDao {

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

        public List<string> ListAllShasIDs() {

            return _databaseContext.Commit.Select(x => x.Sha).ToList();
        }

        public int Adicionar(Commit commit) {

            _databaseContext.Commit.Add(commit);
            _databaseContext.SaveChanges();

            return commit.CommitID;
        }

        public void Delete(Commit commit) {

            _databaseContext.Commit.Attach(commit);
            _databaseContext.Commit.Remove(commit);
            _databaseContext.SaveChanges();
        }

        public void UpdateCheckDate(DateTime date) {

            var commitChecker = _databaseContext.CommitChecker.FirstOrDefault();
            commitChecker.lastCheck = DateTime.Now;

            _databaseContext.CommitChecker.Update(commitChecker);
            _databaseContext.SaveChanges();
        }

        public DateTime GetLastCheckDate() {

            return _databaseContext.CommitChecker.FirstOrDefault().lastCheck;
        }
    }
}
