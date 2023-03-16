using System.ComponentModel.DataAnnotations.Schema;

namespace LibararyProjectEntity.Model
{
    [Table("tblLanguage")]
    public class LanguageModel:BaseModel
    {
        //Id,Language,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,IsDeleted

        public long Id { get; set; }
        public string Language { get; set; }

    }
}
