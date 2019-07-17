using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities.ValueObjects
{
    public class VideoViewModel
    {
        public long videoNo { get; set; }

        [DisplayName("Başlık"),
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            StringLength(100, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string videoTitle { get; set; }

        [DisplayName("Açıklama"),
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            StringLength(1000, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string videoText { get; set; }

        public string videoTag { get; set; }

        public TimeSpan duration { get; set; }

        public string content { get; set; }

        public bool approved { get; set; }

        public string videoName { get; set; } //video kaydedilme adı

        public string frameName { get; set; } //küçük foto adı

        public string videoPath { get; set; }
    }
}
