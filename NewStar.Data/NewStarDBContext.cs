using NewStar.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = NewStar.Model.Models.Task;

namespace NewStar.Data
{
    public class NewStarDBContext : DbContext
    {
        public NewStarDBContext() : base("NSConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<AdvertisingObject> AdvertisingObjects { set; get; }
        public DbSet<Class> Classes { set; get; }
        public DbSet<ClassOrganization> ClassOrganizations { set; get; }
        public DbSet<Contact> Contacts { set; get; }
        public DbSet<Course> Courses { set; get; }
        public DbSet<CourseCategory> CourseCategories { set; get; }
        public DbSet<CourseMarketing> CourseMarketings { set; get; }
        public DbSet<Discount> Discounts { set; get; }
        public DbSet<Error> Errors { set; get; }
        public DbSet<Invoice> Invoices { set; get; }
        public DbSet<Lecturer> Lecturers { set; get; }
        public DbSet<Mark> Marks { set; get; }
        public DbSet<MarketingCampaign> MarketingCampaigns { set; get; }
        public DbSet<NSContact> NSContacts { set; get; }
        public DbSet<NSUser> NSUsers { set; get; }
        public DbSet<PotentialStudent> PotentialStudents { set; get; }
        public DbSet<Price> Prices { set; get; }
        public DbSet<Role> Roles { set; get; }
        public DbSet<Student> Students { set; get; }
        public DbSet<SystemConfig> SystemConfigs { set; get; }
        public DbSet<Task> Tasks { set; get; }

        public static NewStarDBContext Create()
        {
            return new NewStarDBContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
        }
    }
}
