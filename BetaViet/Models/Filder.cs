using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BetaViet.Models
{
    public class BoLoc : BaseEntity
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Display(Name = "Thứ tự")]
        public int Order { get; set; }

        //[Required]
        [Display(Name = "Danh sách giá trị chuẩn")]
        [Column("Values")]
        public string ValuesJSON { get; set; }
        [Display(Name = "Danh sách giá trị chuẩn")]
        [NotMapped]
        public string[] Values
        {
            get
            {
                if (!string.IsNullOrEmpty(ValuesJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(ValuesJSON));

                    return ser.Deserialize<string[]>(jr);
                }

                return new string[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                ValuesJSON = sw.ToString();
            }
        }

        [Display(Name = "Có thêm giá trị")]
        public bool Dropdown { get; set; }
        [Display(Name = "Danh sách giá trị thêm")]
        public string DropdownValuesJSON { get; set; }
        [Display(Name = "Danh sách giá trị thêm")]
        [NotMapped]
        public string[] DropdownValues
        {
            get
            {
                if (!string.IsNullOrEmpty(DropdownValuesJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(DropdownValuesJSON));

                    return ser.Deserialize<string[]>(jr);
                }

                return new string[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                DropdownValuesJSON = sw.ToString();
            }
        }

        [Required]
        [Display(Name = "Cho trang")]
        public TrangBoLoc Page { get; set; }
    }

    public enum TrangBoLoc
    {
        DuAnNoiThat = 0, 
        DuAnKienTruc = 1, 
        NhaThietKe = 2, 
        DangThiCong = 3, 
        DuAnNoiThat_XemTheoPhong = 4, 
        DuAnKienTruc_XemTheoPhong = 5,
        DuAnNoiThat_ToanCanh360 = 6,
        DuAnKienTruc_ThietKeSanVuon = 7,
        DuAnKienTruc_ToanCanh360 = 8,
        DoiThiCong = 9,
        DonViThietKe = 10,
        LoiThe_ShowRoom_BoSuuTap = 11,
        KhuDoThi = 12
    }
}
