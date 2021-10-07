using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Controllers {

    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [EnableCors]
    [ApiController]
    public class UsuarioController : ControllerBase {


    }
}
