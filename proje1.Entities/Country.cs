using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities
{
    [Table("Country")]
    public class Country
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CountryID { get; set; }

        [Required, StringLength(100)]
        public string CountryName { get; set; }

        public virtual List<Video> Videos { get; set; }

        public Country()
        {
            Videos = new List<Video>();
        }
    }
}
