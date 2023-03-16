using System.ComponentModel.DataAnnotations.Schema;

namespace LibararyProjectEntity.Model
{
    [Table("tblAuthor")]
    public class Author:BaseModel
    {
        //Id,AuthorName,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,IsDeleted
        public long Id { get; set; }
        public string AuthorName { get; set; }
    }
    public class AuthorAdd
    {
        public long Id { get; set; }
        public string AuthorName { get; set; }
        public long CreatedBy { get; set; }
    }
    public class AuthorGet
    {
        public long Id { get; set; }
        public string AuthorName { get; set; }
    }
}
