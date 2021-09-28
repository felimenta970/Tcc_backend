using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Models {
    public class CommitsObject {

        public CommitItem commit { get; set; }

        public string html_url { get; set; }

        public string sha { get; set; }

    }

    public class CommitItem {

        public string message { get; set; }

        public Author author { get; set; }

    }

    public class Author {

        public string name { get; set; }
    }
}
