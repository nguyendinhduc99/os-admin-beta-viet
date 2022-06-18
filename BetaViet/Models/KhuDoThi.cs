using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BetaViet.Models
{
    public class KhuDoThi : BaseEntityWithSEoFields
    {
        [Display(Name = "Khu đô thị")]
        public string Name { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

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
    }
}
