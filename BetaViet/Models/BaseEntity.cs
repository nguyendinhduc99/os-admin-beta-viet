using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedOn { get; set; }
        [Display(Name = "Ngày sửa")]
        public DateTime? ModifiedOn { get; set; }
        [Display(Name = "Đã xóa")]
        public bool IsDeleted { get; set; }
    }

    public class BaseEntityWithSEoFields : BaseEntity
    {
        public string SEOTitle { get; set; }
        public string SEODescription { get; set; }
        public string SEOText { get; set; }
        public string SEOTags { get; set; }
        public string Slug { get; set; }
    }
}
