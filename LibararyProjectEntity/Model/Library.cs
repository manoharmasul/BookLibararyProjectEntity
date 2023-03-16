using System.ComponentModel.DataAnnotations.Schema;

namespace LibararyProjectEntity.Model
{
    [Table("tblLibrary")]
    public class Library:BaseModel
    {
        //Id BookName AuthorId CategoryId LanguageId CreatedBy CreatedDate ModifiedBy ModifiedDate IsDeleted
        public long Id { get; set; }
        public string BookName { get; set; }
        public long AuthorId { get; set; }
        public long CategoryId { get; set; }
        public long LanguageId { get; set; }

    }
    public class LibraryAdd
    {
        public long Id { get; set; }
        public string BookName { get; set; }
        public long AuthorId { get; set; }
        public long CategoryId { get; set; }
        public long LanguageId { get; set; }
        public long CreatedBy { get; set; }
    }
    public class LibraryGet
    {
        public long Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
    }
}
