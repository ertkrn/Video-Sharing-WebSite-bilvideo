using proje1.BusinessLayer.Abstract;
using proje1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace proje1.BusinessLayer
{
    public class VideoTagManager : ManagerBase<VideoTag>
    {
        //public void SplitTagsAndSave(string videoTag, long videoNo)
        //{
        //    string[] splits = Regex.Split(videoTag, @"[,]");
        //    if (splits != null)
        //    {
        //        if (splits.Count() < 2)
        //        {
        //            splits = Regex.Split(videoTag, @"[\s]");
        //        }
        //        foreach(string split in splits)
        //        {
        //            vTag.Tag = split;
        //            vTag.videoNo = videoNo;
        //            vtManager.Insert(vTag);
        //            vTag = new VideoTag();
        //        }
        //    }
        //}

        public void SplitTagsAndSave(string videoTag, long videoNo)
        {
            string[] splits = Regex.Split(videoTag, @"[,]");
            if (splits != null)
            {
                if (splits.Count() < 2)
                {
                    splits = Regex.Split(videoTag, @"[\s]");
                }
                foreach (string split in splits)
                {
                    Insert(new VideoTag()
                    {
                        Tag = split,
                        videoNo = videoNo,
                    });
                }
            }
        }
    }
}
