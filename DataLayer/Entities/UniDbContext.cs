using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer.Entities
{
    public class UniDbContext : DbContext
    {
        public UniDbContext(DbContextOptions<UniDbContext> options)
            :base(options)
        {
        }
      
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Chair> Chairs { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().UseTpcMappingStrategy();

            //var employee1 = new Employee
            //{
            //    Id= 1,
            //    FirstName="Tom",
            //    LastName="White",
            //    Email="whitetpm@gmail.com",
            //    Phone="380508854711"
            //};

            //modelBuilder.Entity<Employee>().HasData(employee1);
        }
    }
}
