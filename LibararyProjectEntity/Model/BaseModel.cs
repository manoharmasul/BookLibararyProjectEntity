using System.ComponentModel.DataAnnotations;

namespace LibararyProjectEntity.Model
{
    public class BaseModel
    {
        // public abstract string Key { get; }
        [Required(ErrorMessage = "Created by is required")]
        public long CreatedBy { get; set; }
        [Required(ErrorMessage = "Modified by is required")]
        public long? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedDateFormatdate
        {
            get
            {
                DateTime tmp;
                DateTime.TryParse(CreatedDate.ToString(), out tmp);
                return tmp.ToString("yyyy-MM-dd hh:mm:ss tt");
            }
        }

        public string ModifiedDateFormatdate
        {
            get
            {
                DateTime tmp;
                DateTime.TryParse(ModifiedDate.ToString(), out tmp);
                return tmp.ToString("yyyy-MM-dd hh:mm:ss tt");
            }
        }
        public class DeleteObj
        {
            public long Id { get; set; }
            public long ModifiedBy { get; set; }
            public DateTime ModifiedDate { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
