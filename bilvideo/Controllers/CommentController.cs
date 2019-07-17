using proje1.BusinessLayer;
using proje1.Common;
using proje1.Entities;
using proje1.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace bilvideo.Controllers
{
    public class CommentController : ApiController
    {
        List<Comment> comments = new List<Comment>();
        Comment comment = new Comment();
        CommentManager cManager = new CommentManager();
        VideoManager vManager = new VideoManager();
        MemberManager mManager = new MemberManager();

        [HttpGet]
        public List<Comment> GetComment()
        {
            comments = cManager.List();
            return comments;
        }

        [HttpGet]
        public Comment GetCommentById(long id)
        {
            comment = cManager.Find(x=>x.commentId==id);
            return comment;
        }

        [HttpPost]
        public void AddComment(CommentViewModel model)
        {
            long no = Convert.ToInt64(model.videoNo);
            long memId = Convert.ToInt64(model.memberId);
            comment.comment = model.comment;
            comment.approved = false;
            comment.vdislike = 0;
            comment.vlike = 0;
            comment.videoNo = no;
            comment.sharingdate = DateTime.Now;
            comment.memberId = memId;
            cManager.Insert(comment);
            //return info[id];
        }
    }
}
