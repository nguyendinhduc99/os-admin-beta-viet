using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Models
{
    public class NhaThietKe : BaseEntityWithSEoFields
    {

        [Required]
        [Display(Name = "Tên")]
        public string Name { get; set; }
        [Display(Name = "Chức vụ")]
        public string Position { get; set; }

        [Display(Name = "Thông tin cá nhân")]
        public string Description { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }

        [Display(Name = "Thuộc tính")]
        [Column("Properties")]
        public string PropertiesJSON { get; set; }
        [Display(Name = "Thuộc tính")]
        [NotMapped]
        public DuAnNoiThat_Property[] Properties
        {
            get
            {
                if (!string.IsNullOrEmpty(PropertiesJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(PropertiesJSON));

                    return ser.Deserialize<DuAnNoiThat_Property[]>(jr);
                }

                return new DuAnNoiThat_Property[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                PropertiesJSON = sw.ToString();
            }
        }

        [Display(Name = "Bộ lọc")]
        [Column("Filters")]
        public string FiltersJSON { get; set; }
        [Display(Name = "Bộ lọc")]
        [NotMapped]
        public DuAnNoiThat_Filter[] Filters
        {
            get
            {
                if (!string.IsNullOrEmpty(FiltersJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(FiltersJSON));

                    return ser.Deserialize<DuAnNoiThat_Filter[]>(jr);
                }

                return new DuAnNoiThat_Filter[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                FiltersJSON = sw.ToString();
            }
        }

        [Display(Name = "Đơn vị thành viên")]
        public DonViThanhVien DonViThanhVien { get; set; }
        public Guid? DonViThanhVienId { get; set; }

        [Display(Name = "Đơn vị thiết kế")]
        public DonViThietKe DonViThietKe { get; set; }
        public Guid? DonViThietKeId { get; set; }
    }

    public class DonViThietKe : BaseEntityWithSEoFields
    {

        [Required]
        [Display(Name = "Tên")]
        public string Name { get; set; }
        [Required]
        
        [Display(Name = "Số liên hệ")]
        public string Phone { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Thông tin mô tả")]
        public string Description { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }

        [Display(Name = "Thuộc tính")]
        [Column("Properties")]
        public string PropertiesJSON { get; set; }
        [Display(Name = "Thuộc tính")]
        [NotMapped]
        public DuAnNoiThat_Property[] Properties
        {
            get
            {
                if (!string.IsNullOrEmpty(PropertiesJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(PropertiesJSON));

                    return ser.Deserialize<DuAnNoiThat_Property[]>(jr);
                }

                return new DuAnNoiThat_Property[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                PropertiesJSON = sw.ToString();
            }
        }

        [Display(Name = "Bộ lọc")]
        [Column("Filters")]
        public string FiltersJSON { get; set; }
        [Display(Name = "Bộ lọc")]
        [NotMapped]
        public DuAnNoiThat_Filter[] Filters
        {
            get
            {
                if (!string.IsNullOrEmpty(FiltersJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(FiltersJSON));

                    return ser.Deserialize<DuAnNoiThat_Filter[]>(jr);
                }

                return new DuAnNoiThat_Filter[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                FiltersJSON = sw.ToString();
            }
        }

        [Display(Name = "Danh sách nhà thiết kế")]
        public virtual ICollection<NhaThietKe> NhaThietKes { get; set; }
    }

}
