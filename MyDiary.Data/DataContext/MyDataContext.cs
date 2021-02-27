using Microsoft.EntityFrameworkCore;
using MyDiary.Data.Entity;

namespace MyDiary.Data.DataContext
{
    public class MyDataContext : DbContext
    {
        //public MyDataContext(DbContextOptions<MyDataContext> options)
        //: base(options)
        //{
        //}
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=MyDiaryContext;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
