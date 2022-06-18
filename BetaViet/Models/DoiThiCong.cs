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
    public class DoiThiCong : BaseEntityWithSEoFields
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

        [Display(Name = "Đang thi công")]
        public virtual ICollection<DangThiCong> DangThiCong { get; set; }

    }

    public class DoiThiCongLight
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
