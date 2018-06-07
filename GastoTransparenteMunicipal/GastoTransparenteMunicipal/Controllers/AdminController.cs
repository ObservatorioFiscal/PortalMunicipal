using GastoTransparenteMunicipal.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GastoTransparenteMunicipal.Controllers
{
    //[Authorize(Roles = "admin")]  
    public class AdminController : BaseController
    {
        #region login
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;        
        private ApplicationRoleManager _roleManager;

        public AdminController()
        {
        }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager,ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }


        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        #endregion

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Municipio()
        {
            //List<Core.Municipalidad> municipios = db.Municipalidad.Where(r => !r.Activa).ToList();
            List<Core.Municipalidad> municipios = db.Municipalidad.ToList();
            return View(municipios);
        }

        [HttpPost]
        public JsonResult ActivarMunicipio(string idMunicipio)
        {
            bool success = true;
            try
            {                
                var municipio = db.Municipalidad.Find(int.Parse(idMunicipio));
                municipio.Activa = !municipio.Activa;
                db.SaveChanges();

                return Json(success);
            }
            catch(Exception ex)
            {
                return Json(!success);
            }            
        }

        [HttpPost]
        public JsonResult ActivarCementerio(string idMunicipio)
        {
            bool success = true;
            try
            {
                var municipio = db.Municipalidad.Find(int.Parse(idMunicipio));
                municipio.Cementerio = !municipio.Cementerio;
                db.SaveChanges();

                return Json(success);
            }
            catch (Exception ex)
            {
                return Json(!success);
            }
        }


        public ActionResult CreateAccount()
        {
            List<SelectListItem> roles = new List<SelectListItem>();
            var municipalidades = db.Municipalidad.Where(r => r.Activa).ToList();
            foreach (var municipalidad in municipalidades)
                roles.Add(new SelectListItem() { Value = municipalidad.Nombre, Text = municipalidad.Nombre });

            ViewBag.Roles = roles;
            ViewBag.Message = "";
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> CreateAccount(RegisterSimpleViewModel model)
        {
            List<SelectListItem> roles = new List<SelectListItem>();
            var municipalidades = db.Municipalidad.Where(r => r.Activa).ToList();

            foreach (var municipalidad in municipalidades)
                roles.Add(new SelectListItem() { Value = municipalidad.Nombre, Text = municipalidad.Nombre });

            ViewBag.Roles = roles;

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, Guid.NewGuid().ToString() );
                if (result.Succeeded)
                {
                    result = await UserManager.AddToRolesAsync(user.Id, model.RoleName);
                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Cuenta", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "Creacion cuenta", "Para continuar con la creación de su cuenta, haga click en el siguiente enlace y siga las instrucciones <a href=\"" + callbackUrl + "\">aquí</a>");

                    ViewBag.Message = "Se ha enviado un correo con las instrucciones para la creacion de la cuenta al email ingresado";                        
                                     
                    return View();
                }
                //AddErrors(result);
                else
                {
                    ViewBag.Message = result.Errors;
                }
            }           
            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        [AllowAnonymous]
        public async Task<ActionResult> CreateAccountByEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "CreateAccountByEmail" : "Error");
        }
    }
}