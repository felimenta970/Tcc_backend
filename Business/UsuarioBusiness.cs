using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class UsuarioBusiness {

        UsuarioDao _UserDao = new UsuarioDao();
        MembroDao _membroDao = new MembroDao();
        ProjectManagerDao _pmDao = new ProjectManagerDao();

        public dynamic GetUsuario(string username) {
            return _UserDao.GetUsuario(username);
        }

        public bool isUniqueUsername(string username) {
            var user = _UserDao.GetUsuario(username);

            return user == null;
        }

        public int CreateUser(Usuario usuario, bool isProjectManager) {

            if (isProjectManager) {

                ProjectManager pm = new ProjectManager() {
                    Name = usuario.Name,
                    Username = usuario.Username,
                    Senha = usuario.Senha,
                };

                return _pmDao.Add(pm);
            }
            else {

                Membro membro = new Membro() {
                    Name = usuario.Name,
                    Username = usuario.Username,
                    Senha = usuario.Senha,
                };

                return _membroDao.Add(membro);
            }
        }
    }
}
