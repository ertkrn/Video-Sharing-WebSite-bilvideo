using proje1.Common.Helpers;
using proje1.DataAccessLayer.EntityFramework;
using proje1.Entities;
using proje1.Entities.Messages;
using proje1.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Web;
using proje1.BusinessLayer.Abstract;
using proje1.BusinessLayer.Results;

namespace proje1.BusinessLayer
{
    public class MemberManager : ManagerBase<Member>
    {
        //public BusinessLayerResult<Member> KullaniciGuncelle(MemberViewModel kvm, HttpPostedFileBase file)
        //{
        //    BusinessLayerResult<Member> res = new BusinessLayerResult<Member>();
        //    Member klnc = Find(x => x.uyeId==kvm.uyeId);
        //    if (klnc == null)
        //    {
        //        res.AddError(ErrorMessageCode.KullaniciBulunamadi, "Kullanıcı bulunamadı.");
        //    }
        //    else
        //    {
        //        string foto;
        //        if (file == null)
        //        {
        //            foto = "NULL";
        //        }
        //        else
        //        {
        //            foto = file.FileName;
        //        }
        //        klnc.Username = kvm.Username;
        //        klnc.Email = kvm.Email;
        //        klnc.isim = kvm.Firstname;
        //        klnc.soyisim = kvm.Lastname;
        //        Update(klnc);
        //    }
        //    return res;
        //}

        //public BusinessLayerResult<Member> HizliKullaniciKaydi(MemberViewModel data)
        //{
        //    Member klnc = Find(x => x.Username == data.Username || x.Email == data.Email);
        //    BusinessLayerResult<Member> res = new BusinessLayerResult<Member>();

        //    if (klnc != null)
        //    {
        //        if (klnc.Username == data.Username)
        //        {
        //            res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı adı kayıtlı.");
        //        }
        //        if (klnc.Email == data.Email)
        //        {
        //            res.AddError(ErrorMessageCode.EmailAlreadyExits, "Email adresi kayıtlı.");
        //        }
        //    }
        //    else if(data.Password != data.Repassword)
        //    {
        //        res.AddError(ErrorMessageCode.SifreAynıDegil, "Sifreler uyuşmuyor.");
        //    }
        //    else if (data.Password==null || data.Repassword==null)
        //    {
        //        res.AddError(ErrorMessageCode.SifreBos, "Sifre alanları boş geçilemez.");
        //    }
        //    else
        //    {
        //        if (data.Password.Length < 8)
        //        {
        //            res.AddError(ErrorMessageCode.SifreKarakterUzunlugu, "Şifreniz minimum 8 karakter olmalı!");
        //        }
        //        else
        //        {
        //            int sayi = 0, buyuk = 0, kucuk = 0, krktr = 0;
        //            var sfr = data.Password.ToCharArray();
        //            for (int i = 0; i < data.Password.Length; i++)
        //            {
        //                if (sfr[i] >= 48 && sfr[i] <= 57)
        //                    sayi++;
        //                else if (sfr[i] >= 97 && sfr[i] <= 122)
        //                    kucuk++;
        //                else if (sfr[i] >= 65 && sfr[i] <= 90)
        //                    buyuk++;
        //                else
        //                    krktr++;
        //            }
        //            if (sayi > 0 && kucuk > 0 && buyuk > 0 && krktr > 0)
        //            {
        //                int dbResult = Insert(new Member()
        //                {
        //                    Username = data.Username,
        //                    Password = data.Password,
        //                    Email = data.Email,
        //                    adminmi = false,
        //                    activateGuid = Guid.NewGuid()
        //                });
        //                if (dbResult > 0)
        //                {
        //                    res.Result = Find(x => x.Email == data.Email && x.Username == data.Username);
        //                    string siteUri = ConfigHelper.Get<string>("SiteRootUri");
        //                    string aktiveUri = $"{siteUri}/User/Activate/{res.Result.activateGuid}";
        //                    string body = $"Merhaba {res.Result.Username};<br><br>Hesabınızı aktifleştirmek için <a href='{aktiveUri}' target='_blank'>tıklayınız</a>.";

        //                    MailHelper.SendMail(body, res.Result.Email, "FORUM ERTKRN Hesap Aktifleştirme");
        //                }
        //            }
        //            else
        //            {
        //                res.AddError(ErrorMessageCode.SifreZorunluKarakterler, "Şifreniz 1 büyük harf, 1 küçük harf, 1 simge( - * _ vb.)'den oluşmalı ve en az 8 karakter olmalıdır!");
        //            }
        //        }
        //    }
        //    return res;
        //}

        public BusinessLayerResult<Member> GirisKullanici(LoginViewModel data)
        {
            BusinessLayerResult<Member> res = new BusinessLayerResult<Member>();
            res.Result = Find(x => (x.Username == data.UserOrEmail || x.Email == data.UserOrEmail) && x.Password == data.Password);

            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.UsernameOrPassWrong, "Kullanıcı adı ya da şifre uyuşmuyor.");
            }
            else if (res.Result != null)
            {
                if (res.Result.memberIsActive != true)
                {
                    res.AddError(ErrorMessageCode.UserIsNotActive, "Hesap aktifleştirilmemiş.");
                    res.AddError(ErrorMessageCode.CheckYourEmail, "E-postanızı kontrol ediniz.");
                }
            }
            return res;
        }

        //public BusinessLayerResult<Member> KullaniciAktiflestir(Guid activateId)
        //{
        //    BusinessLayerResult<Member> res = new BusinessLayerResult<Member>();
        //    res.Result = Find(x => x.activateGuid == activateId);

        //    if (res.Result != null)
        //    {
        //        if (res.Result.uyeAktifmi)
        //        {
        //            res.AddError(ErrorMessageCode.KullaniciZatenAktif, "Kullanıcı zaten aktif edilmiştir.");
        //            return res;
        //        }

        //        res.Result.uyeAktifmi = true;
        //        Update(res.Result);
        //    }
        //    else
        //    {
        //        res.AddError(ErrorMessageCode.AktiflestirilecekKullaniciYok, "Aktifleştirilecek kullanıcı bulunamadı.");
        //    }

        //    return res;
        //}

        //public Member SecilenUsernameIle(string klncadi)
        //{
        //    Member klnc = Find(x => x.Username == klncadi);
        //    return klnc;
        //}
        //public Member SecilenuyeIdIle(long i)
        //{
        //    if (i == 0)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        Member klnc = Find(x => x.uyeId == i);
        //        return klnc;
        //    }
        //}
    }
}
