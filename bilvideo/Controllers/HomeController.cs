using proje1.BusinessLayer;
using proje1.BusinessLayer.Results;
using proje1.Common;
using proje1.Entities;
using proje1.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace bilvideo.Controllers
{
    public class HomeController : Controller
    {
        private MemberManager mm = new MemberManager();
        private BusinessLayerResult<Member> res = new BusinessLayerResult<Member>();
        private Member mmbr = new Member();

        // GET: Home
        public ActionResult Index()
        {
            if (Session["member"] == null)
            {
                TempData["redirect"] = "index";
                TempData["videoid"] = "";
            }
            return View();
        }

        public ActionResult Login()
        {
            if (TempData["redirect"] != null)
            {
                string redirect = TempData["redirect"] as string;
                if (redirect == "upload")
                {
                    TempData["redirect"] = redirect;
                }
                else if (redirect == "watch")
                {
                    TempData["redirect"] = redirect;
                    long videoid = Convert.ToInt64(TempData["videoid"] as string);
                    TempData["videoid"] = videoid.ToString();
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            res = mm.GirisKullanici(model);
            if (res.Errors.Count > 0)
            {
                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                model.UserOrEmail = null;
                model.Password = null;
                model.BeniHatirla = false;
                return View(model);
            }
            if (res.Errors.Count == 0 && model.BeniHatirla)
            {
                HttpCookie grs = new HttpCookie("giris");
                grs.Value = model.UserOrEmail;
                grs.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(grs);
            }
            Session["member"] = res.Result;
            //watch2.Stop();
            //var elapsedMs2 = watch2.Elapsed;
            if (TempData["redirect"] != null)
            {
                string redirect = TempData["redirect"] as string;
                if (redirect == "upload")
                {
                    return RedirectToAction("Upload", "Video");
                }
                else if(redirect == "watch")
                {
                    long videoid = Convert.ToInt64(TempData["videoid"] as string);
                    return RedirectToAction("Watch", "Video", new { id = videoid});
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(MemberViewModel mvm)
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            HttpCookie myCookie = Request.Cookies["ASP.NET_SessionId"];
            HttpCookie myCookie2 = Request.Cookies["giris"];
            myCookie.Expires = DateTime.Now.AddDays(-7);
            Session.Remove("member");
            if (myCookie2 != null)
            {
                myCookie2.Expires = DateTime.Now.AddDays(-7);
                Response.Cookies.Add(myCookie2);
            }
            Response.Cookies.Add(myCookie);
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public JsonResult GetMemberId()
        {
            long memberId = App.Common.GetCurrentUsernameId();
            return Json(memberId, JsonRequestBehavior.AllowGet);
        }
    }
}