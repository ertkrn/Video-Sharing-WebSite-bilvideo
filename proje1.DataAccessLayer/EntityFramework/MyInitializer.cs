using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using proje1.Entities;
using System.Data.Entity.Validation;

namespace proje1.DataAccessLayer.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<bilvideoContext>
    {
        protected override void Seed(bilvideoContext context)
        {
            try
            {
                Content[] contents = { new Content() { contentName = "Film ve Animasyon" }, new Content() { contentName = "Otomobiller ve Araçlar" }, new Content() { contentName = "Müzik" }, new Content() { contentName = "Ev Hayvanları ve Hayvanlar" }, new Content() { contentName = "Spor" }, new Content() { contentName = "Seyahat ve Etkinlikler" }, new Content() { contentName = "Oyun" }, new Content() { contentName = "Kişiler ve Bloglar" }, new Content() { contentName = "Komedi" }, new Content() { contentName = "Eğlence" }, new Content() { contentName = "Haberler ve Politika" }, new Content() { contentName = "Nasıl Yapılır ve Stil" }, new Content() { contentName = "Eğitim" }, new Content() { contentName = "Bilim ve Teknoloji" }, new Content() { contentName = "Kâr Amacı Gütmeyen Kuruluşlar ve Aktivizm" } };
                Member[] members = { new Member() { Username = "kullanici adi girin...", Password = "sifre girin...", Email = "mail adresi girin...", activateGuid = Guid.NewGuid(), memberIsActive = true, Name = "Ertuğrul", IsAdmin = true, Surname = "Kuran" } };

                for (int k = 0; k < 6; k++)
                {
                    context.Members.Add(members[k]);
                }
                for (int i = 0; i < 15; i++)
                {
                    context.Contents.Add(contents[i]);
                }
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
