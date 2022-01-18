using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Linq;
using BaseCore.Entities.Concrete;
using EntityLayer.Entities.Concrete;

namespace DataAccessLayer.Contexts.EF
{
    public partial class GetEduContext : DbContext
    {
        //TODO:ef6
        public GetEduContext() : base()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaimPairing> UserOperationClaimPairings { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentSectionPairing> ContentSectionPairings { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseImagePairing> CourseImagePairings { get; set; }
        public DbSet<CourseStudentPairing> CourseStudentPairings { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionLecturePairing> SectionLecturePairings { get; set; }
        public DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<UserImagePairing> UserImagePairings { get; set; }
        public DbSet<UserSocialMediaAccountPairing> UserSocialMediaAccountPairings { get; set; } 







    }
}
