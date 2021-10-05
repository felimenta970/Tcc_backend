using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Dao;
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
                    IsFirstLogin = true,
                };

                return _membroDao.Add(membro);
            }
        }

        public void UpdatePassword(string username, string newPassword, bool isProjectManager) {

            if (isProjectManager) {

                var pm = _pmDao.GetByUsername(username);
                pm.Senha = newPassword;

                _pmDao.Atualiza(pm);

            } else {

                var membro = _membroDao.GetByUsername(username);
                membro.Senha = newPassword;
                membro.IsFirstLogin = false;

                _membroDao.Atualiza(membro);
            }

        }
    }
}
