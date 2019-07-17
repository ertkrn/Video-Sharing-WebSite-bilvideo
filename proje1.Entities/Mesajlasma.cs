using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities
{
    [Table("Mesajlasma")]
    public class Mesajlasma
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long mesajId { get; set; }

        public long kullaniciGonderenId { get; set; }
        public long kullaniciAliciId { get; set; }

        [Required]
        public DateTime mesajtarihsaat { get; set; }

        [Required, StringLength(100)]
        public string mesajmetni { get; set; }

        [ForeignKey("kullaniciGonderenId")]
        public virtual Kullanici Kullanici2 { get; set; }
    }
}
