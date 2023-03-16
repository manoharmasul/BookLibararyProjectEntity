using LibararyProjectEntity.Context;
using LibararyProjectEntity.Model;
using LibararyProjectEntity.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibararyProjectEntity.Repository
{
    public class AuthorAsyncRepository:IAuthorAsyncRepository
    {
        private readonly MyContext context;
        public AuthorAsyncRepository(MyContext context)
        {
            this.context = context;
        }

        public async Task<long> AddNewAurhor(AuthorAdd aut)
        {
            Author author=new Author();
            author.AuthorName = aut.AuthorName;
            author.CreatedBy=aut.CreatedBy;
            author.CreatedDate = DateTime.Now;
            author.ModifiedBy = 0;     
            author.IsDeleted=false;

            var query = context.AddAsync(author);
            var result = await context.SaveChangesAsync();        

            return result;
        }

        public async Task<List<AuthorGet>> GetAllAuthor()
        {
            var query=from auth in context.Authorcc where auth.IsDeleted == false 
            select new AuthorGet 
            {
                Id=auth.Id,
                AuthorName=auth.AuthorName                  
            };

            var authrlist = await query.ToListAsync();
            return authrlist;
        }

        public async Task<long> UpdateAuthor(AuthorAdd aut)
        {
            var auth = await context.Authorcc.FindAsync(aut.Id);
            auth.ModifiedBy = aut.CreatedBy;
            auth.AuthorName = aut.AuthorName;   
            auth.ModifiedDate=DateTime.Now;

           var query= context.Authorcc.Update(auth);
           var result= await context.SaveChangesAsync();

            return result;
        }
    }
}
