using proje1.BusinessLayer.Abstract;
using proje1.BusinessLayer.Results;
using proje1.Common;
using proje1.Entities;
using proje1.Entities.Messages;
using proje1.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace proje1.BusinessLayer
{
    public class VideoManager : ManagerBase<Video>
    {
        Video video = new Video();
        Content content = new Content();
        Country country = new Country();
        ContentManager cManager = new ContentManager();
        CountryManager ctryManager = new CountryManager();
        BusinessLayerResult<Video> res = new BusinessLayerResult<Video>();

        public BusinessLayerResult<Video> VideoYukle(VideoViewModel model)
        {
            string CountryName = RegionInfo.CurrentRegion.DisplayName;
            video = Find(x => x.videoTitle == model.videoTitle && x.videoText == model.videoText);
            TimeSpan duration = new TimeSpan(0, 0, 0, 5, 0);
            if (model.duration < duration)
            {
                res.AddError(ErrorMessageCode.VideoDurationLimit, "Yükleyeceğiniz video en az 5 saniye olmalıdır.");
            }
            if (video != null)
            {
                res.AddError(ErrorMessageCode.PostKayitli, "Oluşturacağınız gönderinin başka gönderiyle aynı olmaması lazım.");
            }
            else
            {
                content = cManager.Find(x => x.contentName == model.content);
                country = ctryManager.Find(x => x.CountryName == CountryName);
                if (country == null && CountryName != null)
                {
                    country = new Country();
                    country.CountryName = CountryName;
                    ctryManager.Insert(country);
                    country = ctryManager.Find(x => x.CountryName == CountryName);
                }
                int dbResult = Insert(new Video()
                {
                    videoTitle = model.videoTitle,
                    videoText = model.videoText,
                    duration = model.duration,
                    video = model.videoName, //Kaydedilen Videonun Adı (Örn. belgesel.mp4)
                    frame = model.frameName, //Kaydedilen Frame Adı (Örn. belgesel.jpeg)
                    approved = false, //Onaylı mı?
                    sharingDate = DateTime.Now.AddHours(10), //Paylaşılma Tarihi
                    contentId = content.contentId, //KategoriId
                    goruntulenme = 0, //Görüntülenme Sayısı
                    like = 0, //Beğeni Sayısı
                    dislike = 0, //Beğenilmeme Sayısı
                    memberId = App.Common.GetCurrentUsernameId(), //Videoyu paylaşan UyeId
                    CountryID = country.CountryID //Paylaşıldığı bölge, UlkeId
                });
                if (dbResult > 0)
                {
                    res.Result = Find(x => x.videoTitle == model.videoTitle && x.videoText == model.videoText && x.duration == model.duration);
                }
            }
            return res;
        }
    }
}
