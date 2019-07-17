using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities.ValueObjects
{
    public class UrunViewModel
    {
        [DisplayName("Ürün No : ")]
        public long UrunId { get; set; }

        [DisplayName("İlan No : ")]
        public long IlanId { get; set; }

        [DisplayName("Ürün Başlığı : "),
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            StringLength(50, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string UrunBaslik { get; set; }

        [DisplayName("Ürün Fiyatı : ")]
        public int UrunFiyat { get; set; }

        [DisplayName("Ürün Konumu : "),
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            StringLength(50, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string UrunKonum { get; set; }

        [DisplayName("Ürün Açıklaması : ")]
        public string UrunAciklama { get; set; }

        [DisplayName("Takas : ")]
        public bool Takas { get; set; }

        [DisplayName("Durumu : ")]
        public bool durumu { get; set; }

        public string takasdegeri { get; set; }
        public string durumdegeri { get; set; }

        public string Fotograf { get; set; }

        [DisplayName("Şehir : ")]
        public string SehirAlani { get; set; }
        [DisplayName("Kategori Adı : ")]
        public string KategoriAdi { get; set; }
        [DisplayName("Renk : ")]
        public string UrunRenkAdi { get; set; }
    }
}
