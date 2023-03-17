using LibararyProjectEntity.Context;
using LibararyProjectEntity.Model;
using LibararyProjectEntity.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibararyProjectEntity.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly MyContext context;
        public UserRepository(MyContext context)
        {
            this.context = context;
        }

        public async Task<string> AddUser(AddUser addUser)
        {
            var checkmobile = from us in context.User
                        where us.IsDeleted == false && us.MobileNo == addUser.MobileNo
                        select us;
            var dmobile = await checkmobile.FirstOrDefaultAsync();

             if(dmobile != null)
             {
                return "Mobile No Is Already Present"; 
             }

            var checkemail = from us in context.User
                        where us.IsDeleted == false && us.EmailId == addUser.EmailId
                        select us;
            var dmail = await checkemail.FirstOrDefaultAsync();

            if (dmail != null)
            {
                return "Email Id Is Already Present";
            }

            string ss;

            User user = new User();
            User user1 = new User();
            //    user.UserName=addUser.FirstName+addUser.LastName;
            
            var check=from us in context.User where us.IsDeleted==false && us.UserName== addUser.FirstName + addUser.LastName
                      select us;
              user = await check.FirstOrDefaultAsync();

            if(user== null)
            {
                string sss= addUser.FirstName + addUser.LastName;
                user1.UserName = sss;
            }
             if(user != null)
             {
                for (int i = 0; i < 10; i++)
                {
                    Random rnd = new Random();
                    int xx = rnd.Next(999);

                     ss = user.UserName + xx;
                    var checkagain = from us in context.User
                                     where us.IsDeleted == false && us.UserName == ss
                                     select us;
                    user = await checkagain.FirstOrDefaultAsync();


                    if(user == null)
                    {
                        user1.UserName = ss;
                        break;
                    }
                }
                
             }
            user1.FirstName=addUser.FirstName;
            user1.LastName = addUser.LastName;
            user1.EmailId = addUser.EmailId;
            user1.MobileNo=addUser.MobileNo;
            user1.Password = addUser.Password;
            user1.CreatedBy = addUser.CreatedBy;
            user1.CreatedDate = DateTime.Now;
            user1.ModifiedBy = 0;
            user1.IsDeleted = false;

            var query = context.AddAsync(user1);
            var result = await context.SaveChangesAsync();
            if (result > 0)
            {
                return "User Successfully Registered";
            }
            else
            {
                return "Something Is Wrong";
            }
        }

        public Task<long> DeleteUser(BaseModel.DeleteObj deleteobj)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateUser(AddUser addUser)
        {
       

            var userfnd = await context.User.FindAsync(addUser.Id);
            if(addUser.CreatedBy==0)
            {
                userfnd.ModifiedBy = addUser.Id;
            }
            else
            {
                userfnd.ModifiedBy = addUser.CreatedBy;
            }
            userfnd.FirstName=addUser.FirstName;
            userfnd.LastName = addUser.LastName;
            userfnd.EmailId=addUser.EmailId;
            userfnd.Password=addUser.Password;
            userfnd.MobileNo=addUser.MobileNo;
            userfnd.ModifiedDate = DateTime.Now;

            var query=context.Update(userfnd);
            var result = await context.SaveChangesAsync();  
            if(result>0)
            {
                return "Information Updated Successfully";
            }
            else
            {
                return "Something Is Wrong";
            }
        }
    }
}
