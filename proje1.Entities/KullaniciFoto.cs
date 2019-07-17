using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities
{
    [Table("KullaniciFoto")]
    public class KullaniciFoto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long fotoId { get; set; }

        public string fotograf { get; set; }

        public long kullaniciId { get; set; }

        [ForeignKey("kullaniciId")]
        public virtual Kullanici Kullanici1 { get; set; }
    }
}
