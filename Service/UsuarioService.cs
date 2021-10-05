using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Business;
using Tcc_backend.Entities;

namespace Tcc_backend.Service {
    public class UsuarioService {

        public dynamic GetUsuario(string username) {
            UsuarioBusiness bUsuario = new UsuarioBusiness();
            return bUsuario.GetUsuario(username);
        }

        public bool isUniqueUsername(string username) {
            UsuarioBusiness bUsuario = new UsuarioBusiness();
            return bUsuario.isUniqueUsername(username);
        }

        public int CreateUser(Usuario usuario, bool isProjectManager) {
            UsuarioBusiness bUsuario = new UsuarioBusiness();
            return bUsuario.CreateUser(usuario, isProjectManager);
        }

        public void UpdatePassword(string username, string newPassword, bool isProjectManager) {
            UsuarioBusiness bUsuario = new UsuarioBusiness();
            bUsuario.UpdatePassword(username, newPassword, isProjectManager);
        }
    }
}
