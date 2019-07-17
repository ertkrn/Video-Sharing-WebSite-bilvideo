using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using bilvideo.Classes;
using Microsoft.WindowsAPICodePack.Shell;
using proje1.BusinessLayer;
using proje1.BusinessLayer.Results;
using proje1.Entities;
using proje1.Entities.Messages;
using proje1.Entities.ValueObjects;

namespace bilvideo.Controllers
{
    public class VideoController : Controller
    {
        Video video = new Video();
        VideoTag vTag = new VideoTag();
        VideoManager vManager = new VideoManager();
        VideoTagManager vtManager = new VideoTagManager();
        BusinessLayerResult<Video> res = new BusinessLayerResult<Video>();
        
        public double Convert100NanosecondsToMilliseconds(double nanoseconds)
        {
            return nanoseconds * 0.0001;
        }

        public ActionResult Upload()
        {
            if (Session["member"] == null)
            {
                TempData["redirect"] = "upload";
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Upload(VideoViewModel model, HttpPostedFileBase file)
        {
            if (model != null && file != null)
            {
                var filename = ImageNameGenerator.VideoIsmiUret(file);
                var imgname = ImageNameGenerator.FotoIsmiUret(file);
                StringBuilder sBuilder = new StringBuilder();
                sBuilder.Append(imgname);
                sBuilder.Append(".jpeg");
                imgname = sBuilder.ToString();
                model.videoName = filename;
                model.frameName = imgname;
                var path = "null";
                if (file != null)
                {
                    path = Path.Combine(Server.MapPath("~/Content/Videos/"), filename);
                    file.SaveAs(path);
                    imgname = Path.Combine(Server.MapPath("~/Content/Images/"), imgname);
                    var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                    ffMpeg.GetVideoThumbnail(path, imgname, 5);
                    ShellFile so = ShellFile.FromFilePath(path);
                    double nanoseconds;
                    double.TryParse(so.Properties.System.Media.Duration.Value.ToString(),
                    out nanoseconds);

                    if (nanoseconds > 0)
                    {
                        double seconds = Convert100NanosecondsToMilliseconds(nanoseconds) / 1000;
                        int ttl_seconds = Convert.ToInt32(seconds);
                        model.duration = TimeSpan.FromSeconds(ttl_seconds);
                    }
                }
                res = vManager.VideoYukle(model);
                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    foreach(ErrorMessageObj obj in res.Errors)
                    {
                        if(obj.Code == ErrorMessageCode.VideoDurationLimit)
                        {
                            System.IO.File.Delete(path);
                            System.IO.File.Delete(imgname);
                        }
                    }
                    return View();
                }
                else
                {
                    vtManager.SplitTagsAndSave(model.videoTag, res.Result.videoNo);
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Watch(long id)
        {
            if (Session["member"] == null)
            {
                TempData["redirect"] = "watch";
                TempData["videoid"] = id.ToString();
            }
            video = vManager.Find(x => x.videoNo == id);
            return View(video);
        }
    }
}