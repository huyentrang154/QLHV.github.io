using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Girls.Models.ModelsView;
using Web_Girls.Models.Reponsivity;

namespace Web_Girls.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            var Ac = new AccountResposi();
            var models = Ac.ViewAc();
            return View(models);
        }
        public ActionResult ViewAccount(string id)
        {
            var Ac = new AccountResposi();
            var models = Ac.ViewAcI(id);
            return View(models);
        }
        [HttpPost]
        public ActionResult ViewAccount(AccountViewItem model)
        {
            var Ac = new AccountResposi();
            if (Ac.isKeyAc(model)) return RedirectToAction("Index");
            else return View(model);
        }
        public ActionResult Account_Add()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}