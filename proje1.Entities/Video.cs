using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities
{
    [Table("Video")]
    public class Video
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long videoNo { get; set; }

        [Required, StringLength(100)]
        public string videoTitle { get; set; }

        [Required, StringLength(1000)]
        public string videoText { get; set; }

        public TimeSpan duration { get; set; }

        public string video { get; set; }

        public string frame { get; set; }

        public long like { get; set; }

        public long dislike { get; set; }

        public float rate { get; set; }

        public DateTime sharingDate { get; set; }

        public bool approved { get; set; } //onaylı mı

        public long memberId { get; set; }
        public long contentId { get; set; }

        public long? goruntulenme { get; set; }

        public long? CountryID { get; set; }

        [ForeignKey("contentId")]
        public virtual Content Content { get; set; }
        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }

        //public virtual List<VideoTag> VideoTags { get; set; }
        //public Video()
        //{
        //    VideoTags = new List<VideoTag>();
        //}
    }
}
