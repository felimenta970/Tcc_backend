using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Models {
    public class AuthData {
        public string Token { get; set; }
        public long TokenExpirationTime { get; set; }
        public string Id { get; set; }
        public bool isProjectManager { get; set; }

    }

    public class LoginModel {

        public string username { get; set; }

        public string password { get; set; }

    }

    public class RegisterPMModel {

        public string username { get; set; }

        public string name { get; set; }

        public string password { get; set; }

    }

    public class RegisterMemberModel {

        public string username { get; set; }

        public string name { get; set; }
    }
    
}
