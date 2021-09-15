﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.DataBaseConfig;
using Tcc_backend.Entities;

namespace Tcc_backend.Business {
    public class UsuarioDao : Controller {

        DatabaseContext _databaseContext = new DatabaseContext();

        public dynamic GetUsuario(string username) {

            var membro = _databaseContext.Membro.FirstOrDefault(u => u.Username == username);
            if (membro != null) {
                return membro;
            } else {
                var pm = _databaseContext.ProjectManager.FirstOrDefault(u => u.Username == username);
                if (pm != null) {
                    return pm;
                } else {
                    return null;
                }
            }
        }

        public int CreateUser(Usuario usuario, bool isProjectManager) {

            if (isProjectManager) {

                ProjectManager pm = new ProjectManager() {
                    Name = usuario.Name,
                    Username = usuario.Username,
                    Senha = usuario.Senha,
                };

                _databaseContext.ProjectManager.Add(pm);
                _databaseContext.SaveChanges();

                return pm.ProjectManagerID;

            }
            else {

                Membro membro = new Membro() {
                    Name = usuario.Name,
                    Username = usuario.Username,
                    Senha = usuario.Senha,
                };

                

                _databaseContext.Membro.Add(membro);
                _databaseContext.SaveChanges();

                return membro.MembroID;
            }
        }
    }
}
