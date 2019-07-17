using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities
{
    [Table("UComment")]
    public class UComment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UCommentID { get; set; }
        
        public long commentId { get; set; }

        public long MemberId { get; set; }

        public string comment { get; set; }

        public long like { get; set; }

        public long dislike { get; set; }

        public DateTime sharingdate { get; set; }

        public bool approved { get; set; } //onaylı mı

        [ForeignKey("commentId")]
        public virtual Comment Comment { get; set; }
    }
}
