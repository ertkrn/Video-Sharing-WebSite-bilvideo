using proje1.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.DataAccessLayer.EntityFramework
{
    public class bilvideoContext : DbContext
    {
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<VideoLike> VideoLikes { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<VideoView> VideoViews { get; set; }
        public DbSet<UComment> UComments { get; set; }
        public DbSet<VideoTag> VideoTags { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        //    modelBuilder.Entity<PostBegeni>()
        //        .HasRequired(s => s.Uye)
        //        .WithMany()
        //        .WillCascadeOnDelete(false);

        //    base.OnModelCreating(modelBuilder);
        //}
        public bilvideoContext()
        {
            Database.SetInitializer(new MyInitializer());
        }
    }
}
