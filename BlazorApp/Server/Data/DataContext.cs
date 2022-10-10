using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        //creating mock data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                Id = 1,
                Name = "Damian",
                Surname = "Ofman",
                Mail = "ofman.damian@gmail.com",
                Telepfone = "504 288 656"
            },

            new Contact
            {
                Id = 2,
                Name = "Anna",
                Mail = "Anna@test.pl",
                Telepfone = "+48 123 321 987"
            }
            );

            modelBuilder.Entity<Category>().HasData(

            new Category
            {
                Id = 0,
                Cat = "Select Category"
            },

            new Category
            {
                Id = 1,
                Cat = "Other"
            },

            new Category
            {
                Id = 2,
                Cat = "Private"
            },

            new Category
            {
                Id = 3,
                Cat = "Work"
            }
            );

            modelBuilder.Entity<SubCategory>().HasData(

            new SubCategory
            {
                Id = 0,
                SubCat = "none"
            },

             new SubCategory
             {
                 Id = 1,
                 SubCat = "Manager"
             },

            new SubCategory
            {
                Id = 2,
                SubCat = "Hr"
            },

            new SubCategory
            {
                Id = 3,
                SubCat = "IT"
            }
            );

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }


    }
   

}

