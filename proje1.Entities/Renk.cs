using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities
{
    [Table("Renk")]
    public class Renk
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long renkId { get; set; }

        [Required, StringLength(20)]
        public string renkAdi { get; set; }

        [Required, StringLength(20)]
        public string renkKodu { get; set; }

        public virtual List<Urun> Urunler { get; set; }

        public Renk()
        {
            Urunler = new List<Urun>();
        }
    }
}
