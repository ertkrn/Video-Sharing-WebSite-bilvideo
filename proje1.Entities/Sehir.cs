using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities
{
    [Table("Sehir")]
    public class Sehir
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ilPlaka { get; set; }

        [Required, StringLength(20)]
        public string ilAdi { get; set; }

        public virtual List<Kullanici> Kullanicilar1 { get; set; }

        public Sehir()
        {
            Kullanicilar1 = new List<Kullanici>();
        }
    }
}
