using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc_backend.Service {
    public class AnexoService : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
