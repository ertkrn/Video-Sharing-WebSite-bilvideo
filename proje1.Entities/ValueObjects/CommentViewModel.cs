using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities.ValueObjects
{
    public class CommentViewModel
    {
        public long commentId { get; set; }

        public string comment { get; set; }

        public string videoNo { get; set; }

        public string memberId { get; set; }
    }
}
