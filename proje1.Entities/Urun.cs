using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities
{
    [Table("Urun")]
    public class Urun
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long urunId { get; set; }

        [Required]
        public long ilanId { get; set; }

        [Required, StringLength(50)]
        public string urunBaslik { get; set; }

        [Required]
        public int urunFiyati { get; set; }

        public string urunFotosu { get; set; }

        [Required]
        public DateTime satistarihsaat { get; set; }

        [StringLength(50)]
        public string urunKonum { get; set; }
        
        public bool durumu { get; set; }
        public bool halasatilikmi { get; set; }
        public bool takasyapilirmi { get; set; }
        public string urunAciklama { get; set; }

        public long renkId { get; set; }
        public int ilPlaka { get; set; }
        public long kullaniciId { get; set; }
        public long kategoriId { get; set; }

        [ForeignKey("renkId")]
        public virtual Renk Renk { get; set; }
        [ForeignKey("kullaniciId")]
        public virtual Kullanici Kullanici1 { get; set; }
        [ForeignKey("kategoriId")]
        public virtual Kategori Kategori1 { get; set; }

        public virtual List<Galeri> Galeriler { get; set; }
        public virtual List<UrunFoto> UrunFotolar { get; set; }
        public Urun()
        {
            Galeriler = new List<Galeri>();
            UrunFotolar = new List<UrunFoto>();
        }
    }
}
