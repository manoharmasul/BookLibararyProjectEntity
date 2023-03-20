using LibararyProjectEntity.Model;
using Microsoft.EntityFrameworkCore;

namespace LibararyProjectEntity.Context
{
    public class MyContext: DbContext
    {

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<Author> Authorcc { get; set; }
        public DbSet<Library> Library { get; set; }
        public DbSet<LanguageModel> LanguageModels { get; set; }
        public DbSet<tblCategory> tblCategory { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<BookIssueDetails> BookIssueDetails { get; set; }
    }
}
