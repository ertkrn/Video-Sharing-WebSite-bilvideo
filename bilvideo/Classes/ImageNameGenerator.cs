using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bilvideo
{
    public class ImageNameGenerator
    {
        public static string ProfilFotoIsmiUret(HttpPostedFileBase file)
        {
            string filename = null;
            if (file != null)
            {
                string format = file.ContentType;
                string gun = DateTime.Now.Day.ToString();
                string ay = DateTime.Now.Month.ToString();
                string yil = DateTime.Now.Year.ToString();
                string saat = DateTime.Now.Hour.ToString();
                string dakika = DateTime.Now.Minute.ToString();
                string saniye = DateTime.Now.Second.ToString();
                string milisaniye = DateTime.Now.Millisecond.ToString();
                if (DateTime.Now.Day < 10)
                {
                    gun = "0" + gun;
                }
                if (DateTime.Now.Month < 10)
                {
                    ay = "0" + ay;
                }
                if (DateTime.Now.Hour < 10)
                {
                    saat = "0" + saat;
                }
                if (DateTime.Now.Minute < 10)
                {
                    dakika = "0" + dakika;
                }
                if (DateTime.Now.Second < 10)
                {
                    saniye = "0" + saniye;
                }
                string tarih = yil + ay + gun + "-" + saat + dakika + saniye + milisaniye;
                filename = string.Format(@"USER-{0}", tarih);//Bilvideo Profil
                if (format == "image/png")
                {
                    filename = filename + ".png";
                }
                else if (format == "image/gif")
                {
                    filename = filename + ".gif";
                }
                else if (format == "image/jpg")
                {
                    filename = filename + ".jpg";
                }
                else if (format == "image/jpeg")
                {
                    filename = filename + ".jpeg";
                }
            }
            return filename;
        }

        public static string VideoIsmiUret(HttpPostedFileBase file)
        {
            string filename = null;
            if (file != null)
            {
                string gun = DateTime.Now.Day.ToString();
                string ay = DateTime.Now.Month.ToString();
                string yil = DateTime.Now.Year.ToString();
                string saat = DateTime.Now.Hour.ToString();
                string dakika = DateTime.Now.Minute.ToString();
                string saniye = DateTime.Now.Second.ToString();
                string milisaniye = DateTime.Now.Millisecond.ToString();
                if (DateTime.Now.Day < 10)
                {
                    gun = "0" + gun;
                }
                if (DateTime.Now.Month < 10)
                {
                    ay = "0" + ay;
                }
                if (DateTime.Now.Hour < 10)
                {
                    saat = "0" + saat;
                }
                if (DateTime.Now.Minute < 10)
                {
                    dakika = "0" + dakika;
                }
                if (DateTime.Now.Second < 10)
                {
                    saniye = "0" + saniye;
                }
                string tarih = yil + ay + gun + "-" + saat + dakika + saniye + milisaniye;
                string format = file.ContentType;
                filename = string.Format(@"Video-{0}", tarih);//Bilvideo İsim
                if (format == "video/mp4")
                {
                    filename = filename + ".mp4";
                }
            }
            return filename;
        }

        public static string FotoIsmiUret(HttpPostedFileBase file)
        {
            string filename = null;
            if (file != null)
            {
                string gun = DateTime.Now.Day.ToString();
                string ay = DateTime.Now.Month.ToString();
                string yil = DateTime.Now.Year.ToString();
                string saat = DateTime.Now.Hour.ToString();
                string dakika = DateTime.Now.Minute.ToString();
                string saniye = DateTime.Now.Second.ToString();
                string milisaniye = DateTime.Now.Millisecond.ToString();
                if (DateTime.Now.Day < 10)
                {
                    gun = "0" + gun;
                }
                if (DateTime.Now.Month < 10)
                {
                    ay = "0" + ay;
                }
                if (DateTime.Now.Hour < 10)
                {
                    saat = "0" + saat;
                }
                if (DateTime.Now.Minute < 10)
                {
                    dakika = "0" + dakika;
                }
                if (DateTime.Now.Second < 10)
                {
                    saniye = "0" + saniye;
                }
                string tarih = yil + ay + gun + "-" + saat + dakika + saniye + milisaniye;
                string format = file.ContentType;
                filename = string.Format(@"Img-{0}", tarih);//Bilvideo İsim
                if (format == "image/jpeg")
                {
                    filename = filename + ".jpeg";
                }
            }
            return filename;
        }
    }
}