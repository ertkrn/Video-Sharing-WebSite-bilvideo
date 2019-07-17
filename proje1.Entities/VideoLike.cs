using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities
{
    [Table("VideoLike")]
    public class VideoLike
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long begeniId { get; set; }

        public bool begendim { get; set; }

        public DateTime begeniZamani { get; set; }
        
        public Member memberId { get; set; }
        public Video videoNo { get; set; }
    }
}
