using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities.ValueObjects
{
    public class MemberViewModel
    {
        public long memberId { get; set; }

        [DisplayName("Kullanıcı Adı"),
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            StringLength(16, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string Username { get; set; }

        [DisplayName("İsim"),
            StringLength(50, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string Firstname { get; set; }

        [DisplayName("Soyisim"),
            StringLength(50, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string Lastname { get; set; }
        
        [DisplayName("Email"),
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            StringLength(50, ErrorMessage = "{0} max. {1} karakter olmalı."),
            EmailAddress(ErrorMessage = "{0} alanı için geçerli bir e-mail adresi giriniz.")]
        public string Email { get; set; }
        
        [DisplayName("Şifre"),
            DataType(DataType.Password),
            StringLength(16, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string Password { get; set; }

        [DisplayName("Şifre Tekrar"),
            DataType(DataType.Password),
            StringLength(16, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string Repassword { get; set; }
        
        public bool contract { get; set; }
    }
}
