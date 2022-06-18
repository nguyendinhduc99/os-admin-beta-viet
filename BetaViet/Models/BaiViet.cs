using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Models
{
    public class BaiViet : BaseEntityWithSEoFields
    {
        [Display(Name = "Danh mục")]
        public virtual DanhMucBaiViet DanhMucBaiViet { get; set; }
        [Display(Name = "Danh mục")]
        public Guid? DanhMucBaiVietId { get; set; }

        [Required]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Nội dung")]
        public string Content { get; set; }
    }
    public class DanhMucBaiViet : BaseEntityWithSEoFields
    {
        [Required]
        [Display(Name = "Tên")]
        public string Name { get; set; }
        [Display(Name = "Thứ tự")]
        public int Order { get; set; }
    }

    public class LanToaCongDong : BaseEntityWithSEoFields
    {
        [Required]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Nội dung")]
        public string Content { get; set; }
    }

    public class Khuyenmai : BaseEntityWithSEoFields
    {
        [Required]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Liên kết")]
        public string Link { get; set; }
    }
    public class KhuyenmaiNoiThat : Khuyenmai
    {
    }
    public class KhuyenmaiKienTruc : Khuyenmai
    {
    }

    public class ToanCanh360 : BaseEntityWithSEoFields
    {
        [Required]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Ảnh 360")]
        public string Anh360 { get; set; }
    }
    public class ToanCanh360NoiThat : ToanCanh360
    {
    }
    public class ToanCanh360KienTruc : ToanCanh360
    {
    }


}
