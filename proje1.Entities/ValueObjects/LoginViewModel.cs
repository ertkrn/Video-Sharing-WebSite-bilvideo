using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proje1.Entities.ValueObjects
{
    public class LoginViewModel
    {
        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage ="{0} alanı boş geçilemez.")]
        public string UserOrEmail { get; set; }

        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez."),DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Beni Hatırla")]
        public bool BeniHatirla { get; set; } = true;
    }
}