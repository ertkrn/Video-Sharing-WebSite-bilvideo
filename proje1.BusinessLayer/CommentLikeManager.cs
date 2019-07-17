using proje1.BusinessLayer.Abstract;
using proje1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.BusinessLayer
{
    public class CommentLikeManager : ManagerBase<CommentLike>
    {
        private CommentLike yb = new CommentLike();
        //public string BegenmisMi(long yorumId, long uyeId)
        //{
        //    string durum;
        //    yb = Find(x => x.yorumId == yorumId && x.UyeId == uyeId);
        //    if (yb == null)
        //    {
        //        durum = "not";
        //    }
        //    else
        //    {
        //        if (yb.begendim)
        //            durum = "like";
        //        else
        //            durum = "dislike";
        //    }
        //    return durum;
        //}
    }
}
