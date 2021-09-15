using CryptoHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business;
using Tcc_backend.Models;

namespace Tcc_backend.Service {
    public class AuthService {

        string jwtSecret;
        int jwtLifespan;
        public AuthService(string jwtSecret, int jwtLifespan) {
            this.jwtSecret = jwtSecret;
            this.jwtLifespan = jwtLifespan;
        }

        public AuthService() {

        }

        public AuthData GetAuthData(string jwtSecret, int jwtLifespan, string id) {
            AuthBusiness bAuth = new AuthBusiness(jwtSecret, jwtLifespan);
            return bAuth.GetAuthData(id);
        }

        public string HashPassword(string password) {
            AuthBusiness bAuth = new AuthBusiness();
            return bAuth.HashPassword(password);
        }

        public bool VerifyPassword(string actualPassword, string hashedPassword) {
            AuthBusiness bAuth = new AuthBusiness();
            return bAuth.VerifyPassword(actualPassword, hashedPassword);
        }

    }
}
