using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Models
{
    public class DichVuThiCong : BaseEntityWithSEoFields
    {
        [Required]
        [Display(Name = "Trang")]
        public string Page { get; set; }

        [Required]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        [Display(Name = "Nhà thiết kế")]
        public virtual NhaThietKe NhaThietKe { get; set; }
        public Guid? NhaThietKeId { get; set; }
    }
}
