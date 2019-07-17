using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities
{
    [Table("CommentLike")]
    public class CommentLike
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long commentLikeId { get; set; }

        public bool liked { get; set; }

        public DateTime likeDate { get; set; }

        public Member memberId { get; set; }
        public Comment commentId { get; set; }
    }
}
