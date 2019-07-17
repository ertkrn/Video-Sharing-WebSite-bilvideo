using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities.ValueObjects
{
    public class MesajViewModel
    {
        public Kullanici klnc { get; set; }
        public Mesajlasma msj { get; set; }
        public IEnumerable<Mesajlasma> msjlar { get; set; }

        public string GonderenKullaniciId { get; set; }
        public string AliciKullaniciId { get; set; }
        [DisplayName("Mesaj Metni Alanı : "),
            StringLength(100, ErrorMessage = "{0} max. {1} karakter olmalı."),
                Required(ErrorMessage = "Boş mesaj gönderemezsiniz")]
        public string MesajMetni { get; set; }
    }
}
