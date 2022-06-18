using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Models
{
    public class SEOText
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cho trang")]
        //public TrangBoLoc Page { get; set; }
        public string Page { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name = "Giá trị")]
        public string Text { get; set; }
       
    }

    public class AnhTrangChu : BaseEntity
    {
        [Required]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        
    }

    public class FormDangKy : BaseEntity
    {
        [Required]
        [Display(Name = "Họ tên")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

    }
}
