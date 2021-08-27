using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Service {
    public class CommitService {

        public Commit Get(int CommitID) {
            CommitBusiness bCommit = new CommitBusiness();
            return bCommit.Get(CommitID);
        }

        public List<Commit> ListByUserStoryID(int UserStoryID) {
            CommitBusiness bCommit = new CommitBusiness();
            return bCommit.ListByUserStoryID(UserStoryID);
        }

        public int Adicionar(CommitModelCreate model) {
            CommitBusiness bCommit = new CommitBusiness();
            return bCommit.Adicionar(model);
        }

        public void Delete(int CommitID) {
            CommitBusiness bCommit = new CommitBusiness();
            bCommit.Delete(CommitID);
        }
    }
}
