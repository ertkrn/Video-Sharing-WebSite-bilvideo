using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities
{
    [Table("Comment")]
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long commentId { get; set; }

        public long videoNo { get; set; }

        public long memberId { get; set; }

        public string comment { get; set; }

        public long vlike { get; set; }

        public long vdislike { get; set; }

        public bool sentiment { get; set; }

        public DateTime sharingdate { get; set; }

        public bool approved { get; set; } //onaylı mı

        [ForeignKey("memberId")]
        public virtual Member Member { get; set; }
        [ForeignKey("videoNo")]
        public virtual Video Video { get; set; }

        public virtual List<UComment> UComments { get; set; }

        public Comment()
        {
            UComments = new List<UComment>();
        }
    }
}
