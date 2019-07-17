namespace proje1.Entities.Messages
{
    public enum ErrorMessageCode
    {
        UsernameAlreadyExists = 101,
        EmailAlreadyExits = 102,
        UserIsNotActive = 151,
        UsernameOrPassWrong = 152,
        CheckYourEmail = 153,
        KullaniciZatenAktif = 180,
        KullaniciBulunamadi = 181,
        AktiflestirilecekKullaniciYok = 181,
        IlanIdKayitli = 200,
        UrunKayitli = 201,
        UrunBulunamadi = 202,
        UrunBaslikKayitli = 203,
        UrunAciklamaKayitli = 204,
        DosyaFormat = 404,
        DosyaBoyut = 405,
        VideoDurationLimit=501,
        SifreAynıDegil = 500,
        SifreBos = 244,
        SifreKarakterUzunlugu=245,
        SifreZorunluKarakterler=246,
        SehirAdiKayitli = 611,
        SehirPlakaKayitli = 612,
        RenkAdiKayitli = 505,
        RenkKoduKayitli=506,
        PostKayitli=700,
    }
}
