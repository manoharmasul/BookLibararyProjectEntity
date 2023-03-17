using System.ComponentModel.DataAnnotations.Schema;

namespace LibararyProjectEntity.Model
{
        [Table("tblUser")]
        public class User:BaseModel
        {
            //Id,UserName,FirstName,LastName,EmailId,Password

            public long Id { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EmailId { get; set; }
            public string MobileNo { get; set; }
            public string Password { get; set; }
        }
        public class AddUser
        {
            public long Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EmailId { get; set; }
            public string MobileNo { get; set; }
            public string Password { get; set; }
            public long CreatedBy { get; set; }
        }
}
