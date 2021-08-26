using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Models {
    public class CommitModel {

        public int CommitID { get; set; }

        public string Author { get; set; }

        public string Message { get; set; }

        public int UserStoryID { get; set; }
    }

    public class CommitModelCreate {

        public string Author { get; set; }

        public string Message { get; set; }

        public int UserStoryID { get; set; }

    }
}
