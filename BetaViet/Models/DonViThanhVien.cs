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
    public class DonViThanhVien : BaseEntityWithSEoFields
    {
        [Required]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Logo")]
        public string Logo { get; set; }

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

        //[Display(Name = "Danh sách nhà thiết kế")]
        //public ICollection<NhaThietKe> NhaThietKes { get; set; }
    }
}
