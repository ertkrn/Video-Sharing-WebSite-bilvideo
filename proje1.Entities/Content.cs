using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities
{
    [Table("Content")]
    public class Content
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long contentId { get; set; }

        [Required, StringLength(100)]
        public string contentName { get; set; }

        public virtual List<Video> Videos { get; set; }

        public Content()
        {
            Videos = new List<Video>();
        }
    }
}
