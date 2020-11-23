using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganisationX.Controllers
{
    public class ManController : Controller
    {

        private readonly RoleManager<IdentityRole> roleManager;
        public ManController(RoleManager<IdentityRole> roleManager) {
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult CreateRole() {
            return View();
        }
    }
}
