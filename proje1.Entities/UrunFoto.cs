using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities
{
    [Table("UrunFoto")]
    public class UrunFoto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long fotoId { get; set; }

        public string fotograf { get; set; }

        public long urunId { get; set; }

        [ForeignKey("urunId")]
        public virtual Urun Urun { get; set; }
    }
}
