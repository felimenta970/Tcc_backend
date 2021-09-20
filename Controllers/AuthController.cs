using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Models;
using Tcc_backend.Service;
using Microsoft.Net.Http.Headers;
using Tcc_backend.Entities;

namespace Tcc_backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {

        AuthService sAuth = new AuthService();
        UsuarioService sUsuario = new UsuarioService();

        [HttpPost("login")]
        public ActionResult<AuthData> Post([FromBody] LoginModel model) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                var user = sUsuario.GetUsuario(model.username);

                if (user == null) {
                    return BadRequest(new { message = "Este username não existe" });
                }

                var passwordValid = sAuth.VerifyPassword(model.password, user.Senha);
                if (!passwordValid) {
                    return BadRequest(new { message = "Senha inválida" });
                }

                var bearerToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");

                if (user.ProjectManagerID != null) {
                    var authData = sAuth.GetAuthData("iKC0yCHfjW4fiemBo44eK1OBpYplZ9e6", 2592000, user.ProjectManagerID.ToString());
                    authData.isProjectManager = true;
                    return authData;
                }
                else {
                    var authData = sAuth.GetAuthData("iKC0yCHfjW4fiemBo44eK1OBpYplZ9e6", 2592000, user.MembroID.ToString());
                    authData.isProjectManager = false;
                    return authData;
                }
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro de servidor");
            }

        }

        [HttpPost("register")]
        public ActionResult<AuthData> Post([FromBody] RegisterPMModel model) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var uniqueUser = sUsuario.isUniqueUsername(model.username);

            if (!uniqueUser)
                return BadRequest(new { message = "Um usuário com este username já existe" });
            

            var user = new Usuario {
                Username = model.username,
                Senha = sAuth.HashPassword(model.password),
                Name = model.name,
                
            };

            var userId = sUsuario.CreateUser(user, true);

            return sAuth.GetAuthData("iKC0yCHfjW4fiemBo44eK1OBpYplZ9e6", 2592000, userId.ToString());
        }
    }
}
