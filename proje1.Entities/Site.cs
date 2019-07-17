using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities
{
    [Table("Site")]
    public class Site
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long loginId { get; set; }

        public string IpNumber { get; set; }

        public DateTime LastestLoginDate { get; set; }

        public long LoginCount { get; set; }
    }
}
