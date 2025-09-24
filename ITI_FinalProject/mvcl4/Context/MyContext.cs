using Microsoft.EntityFrameworkCore;
using mvcl4.Models;

namespace mvcl4.Context
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-F2TPTLE;database=MVCD4;trusted_connection=true;trustServerCertificate=true");
        }

        public virtual DbSet <Student> Students { get; set; }
        public virtual DbSet<Department > Departments { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var depts = new List<Department>
            {
                new Department { DeptId = 1, DeptName = "SWE" },
                new Department { DeptId= 2, DeptName = "CS" },
                new Department { DeptId = 3, DeptName = "IS" },
                new Department { DeptId = 4, DeptName = "IT" },
                new Department { DeptId = 5, DeptName = "AI" },
                new Department { DeptId = 6, DeptName = "BIO" }
            };
            var studs = new List<Student>
            {
               new Student { Id = 1, Name = "Ahmed Ali", Age = 25, Address = "Menoufia", Email = "ahmed.ali@example.com", Password = "pass1234", DeptId = 1 },
                    new Student { Id = 2, Name = "Mona Said", Age = 30,  Address = "Giza", Email = "mona.said@example.com", Password = "mona456", DeptId  = 2 },
                    new Student { Id = 3, Name = "Youssef Gamal", Age = 2, Address = "Alexandria", Email = "youssef.g@example.com", Password = "you12345", DeptId  = 3 },
                    new Student { Id = 4, Name = "Sara Fathy", Age = 22,Address = "Mansoura", Email = "sara.fathy@example.com", Password = "sara987", DeptId  = 1 },
                    new Student { Id = 5, Name = "Khaled Nour", Age = 35, Address = "Tanta", Email = "khaled.n@example.com", Password = "khaledpw", DeptId  = 2 },
                    new Student { Id = 6, Name = "Nour Hassan", Age = 27,Address = "Zagazig", Email = "nour.hassan@example.com", Password = "nourpass", DeptId = 3 },
                    new Student { Id = 7, Name = "Omar Adel", Age = 29, Address = "Ismailia", Email = "omar.adel@example.com", Password = "omar123", DeptId = 1 },
                    new Student { Id = 8, Name = "Laila Samir", Age = 32,Address = "Aswan", Email = "laila.samir@example.com", Password = "laila321", DeptId = 2 },
                    new Student { Id = 9, Name = "Hassan Omar", Age = 26,Address = "Menoufia", Email = "hassan.omar@example.com", Password = "hassanpw", DeptId  = 3 },
                    new Student { Id = 10, Name = "Dina Nabil", Age = 24,Address = "Luxor", Email = "dina.nabil@example.com", Password = "dina444", DeptId  = 4 }

            };

            var us = new List<User> {

                new User {UserId=1 ,FirstName="mohamed",LastName="abdelhameed",Email="mohamed301@gmail.com",Password="mn301"},
                new User {UserId=2 ,FirstName="nour",LastName="abdallah",Email="nour117@gmail.com",Password="mn301"}

            };


            modelBuilder.Entity<Department>().HasData(depts);
            modelBuilder.Entity<Student>().HasData(studs);
            modelBuilder.Entity<User>().HasData(us);
            base.OnModelCreating(modelBuilder);
        }




    }
}
