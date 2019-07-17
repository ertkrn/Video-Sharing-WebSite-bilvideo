using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities
{
    [Table("VideoView")]
    public class VideoView
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long vvNo { get; set; }

        public Video videoNo { get; set; }

        public string IpNumber { get; set; }

        public DateTime LatestViewDate { get; set; }

        public long viewCount { get; set; }

        public Member memberId { get; set; }
    }
}
