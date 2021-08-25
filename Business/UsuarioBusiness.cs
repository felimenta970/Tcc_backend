using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Business {
    public class UsuarioBusiness : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
