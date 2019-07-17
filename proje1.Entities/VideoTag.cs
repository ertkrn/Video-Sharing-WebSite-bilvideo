using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities
{
    [Table("VideoTag")]
    public class VideoTag
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long VideoTagId { get; set; }

        [Required, StringLength(100)]
        public string Tag { get; set; }

        public long videoNo { get; set; }

        //[ForeignKey("videoNo")]
        //public virtual Video Video { get; set; }
    }
}
