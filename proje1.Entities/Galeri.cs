using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities
{
    [Table("Galeri")]
    public class Galeri
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long gorselId { get; set; }
        [Required]
        public byte[] deger { get; set; }
        [Required]
        public string dosyaadi { get; set; }
        [Required, StringLength(250)]
        public string baslik { get; set; }
        [Required, StringLength(1000)]
        public string aciklama { get; set; }
        [Required]
        public string dosyatipi { get; set; }
        [Required, StringLength(1000)]
        public string dosyaboyutu { get; set; }
        [Required, StringLength(50)]
        public string boyutkisaltma { get; set; }
        [Required, StringLength(50)]
        public string ikon { get; set; }
        [Required, StringLength(50)]
        public string renk { get; set; }
        [Required]
        public string resim { get; set; }
        [Required]
        public DateTime kayitTarihi { get; set; }

        public long urunId { get; set; }

        [ForeignKey("urunId")]
        public virtual Urun Urun { get; set; }
    }
}
