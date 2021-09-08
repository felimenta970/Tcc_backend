using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class CommitBusiness {

        CommitDao _dao = new CommitDao();

        public Commit Get(int CommitID) {
            return _dao.Get(CommitID);
        }

        public List<Commit> ListByUserStoryID(int UserStoryID) {
            return _dao.ListByUserStoryID(UserStoryID);
        }

        public int Adicionar(CommitModelCreate model) {

            var commit = new Commit() {
                Author = model.Author,
                Message = model.Message,
                UserStoryID = model.UserStoryID,
            };

            return _dao.Adicionar(commit);
        }

        public void Delete(int CommitID) {

            Commit commit = new Commit() {
                CommitID = CommitID,
            };

            _dao.Delete(commit);
        }

        public CommitModel EntityToModel(Commit commit) {

            CommitModel model = new CommitModel() {
                CommitID = commit.CommitID,
                Author = commit.Author,
                Message = commit.Message,
                UserStoryID = commit.UserStoryID,
            };

            return model;
        }
    }
}
