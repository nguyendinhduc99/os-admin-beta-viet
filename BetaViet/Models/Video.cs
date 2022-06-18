using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Models
{
    public class Video : BaseEntityWithSEoFields
    {
        [Display(Name = "Danh mục")]
        public virtual DanhMucVideo DanhMucVideo { get; set; }
        [Display(Name = "Danh mục")]
        public Guid? DanhMucVideoId { get; set; }

        [Required]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }

        //[Display(Name = "Mô tả")]
        //public string Description { get; set; }

        [Display(Name = "Youtube URL")]
        public string YoutubeURL { get; set; }
        [Display(Name = "Video URL")]
        public string VideoURL { get; set; }
    }

    public class DanhMucVideo : BaseEntityWithSEoFields
    {
        [Display(Name = "Thứ tự")]
        public int Order { get; set; }

        [Required]
        [Display(Name = "Tên")]
        public string Name { get; set; }
    }
}
