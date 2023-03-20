using System.ComponentModel.DataAnnotations.Schema;

namespace LibararyProjectEntity.Model
{
    [Table("tblBookIssueDetails")]
    public class BookIssueDetails :BaseModel
    {
        //Id,BookId,IssueTo,IssueDate,ReturnDate,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,IsDeleted
        public long Id { get; set; }
        public long BookId { get; set; }
        public long IssueTo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
    public class BookIssueDetailsAdd
    {
        //Id,BookId,IssueTo,IssueDate,ReturnDate,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,IsDeleted
        public long Id { get; set; }
        public long BookId { get; set; }
        public long IssueTo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public long CreatedBy { get; set; }
    }
    public class BookIssueDetailsGet
    {
        //Id,BookId,IssueTo,IssueDate,ReturnDate,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,IsDeleted
        public long Id { get; set; }
        public string BookName { get; set; }
        public string IssueTo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public long CreatedBy { get; set; }
    }
}
