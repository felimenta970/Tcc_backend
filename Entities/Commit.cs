using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Entities {
    public class Commit {

        [Key]
        public int CommitID { get; set; }

        public string Author { get; set; }

        public string Message { get; set; }

        public int UserStoryID { get; set; }

        [ForeignKey("UserStoryID")]
        public UserStory UserStory { get; set; }
    }
}
