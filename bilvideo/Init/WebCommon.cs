using proje1.Common;
using proje1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bilvideo.Init
{
    public class WebCommon : ICommon
    {
        public long GetCurrentUsernameId()
        {
            if (HttpContext.Current.Session["member"] != null)
            {
                Member member = HttpContext.Current.Session["member"] as Member;
                return member.MemberId;
            }
            return 0;
        }
        public byte[] GetCurrentValue()
        {
            if (HttpContext.Current.Session["value"] != null)
            {
                return ((byte[])HttpContext.Current.Session["value"]);
            }
            return null;
        }
        public string GetCurrentSizeValue()
        {
            if (HttpContext.Current.Session["value"] != null)
            {
                return ((byte[])HttpContext.Current.Session["value"]).Length.ToString();
            }
            return null;
        }
        public long GetUrunId()
        {
            if (HttpContext.Current.Session["video"] != null)
            {
                Video video = HttpContext.Current.Session["video"] as Video;
                return video.videoNo;
            }
            return 0;
        }
    }
}