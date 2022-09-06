using System.Collections.Generic;
using System.Data.Entity;

namespace Lab03.DataAccess
{
    class AppDbContextInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext dbContext)
        {
            dbContext.Students.AddRange(new List<StudentEntity>
            {
                new StudentEntity { Name = "Oleg", Phone = "+375291170726" },
                new StudentEntity { Name = "Igor", Phone = "+375291170724" },
                new StudentEntity { Name = "Maxim", Phone = "+375291170727" },
            });

            dbContext.SaveChanges();
        }
    }
    
    public class AppDbContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; }
        
        public AppDbContext() : base("DictionaryDb")
        {
            Database.SetInitializer(new AppDbContextInitializer());
        }
    }

}