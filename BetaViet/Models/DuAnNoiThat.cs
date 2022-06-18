using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BetaViet.Models
{
    public class DuAnNoiThat : DuAnCommon
    {

    }

    public class DangThiCong : DuAnCommon
    {
        //[Display(Name = "Loại dự án")]
        //public LoaiDuAn LoaiDuAn { get; set; }
        //[Display(Name = "Tiến độ thi công")]
        //public string TienDoThiCong { get; set; }

        //[Display(Name = "Loại dự án 2")]
        //public LoaiDuAn? LoaiDuAn2 { get; set; }
        //[Display(Name = "Tiến độ thi công 2")]
        //public string TienDoThiCong2 { get; set; }

        [Display(Name = "Đội thi công")]
        [Column("DoiThiCong")]
        public string DoiThiCongJSON { get; set; }
        [Display(Name = "Đội thi công")]
        [NotMapped]
        public DoiThiCongLight[] DoiThiCong
        {
            get
            {
                if (!string.IsNullOrEmpty(DoiThiCongJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(DoiThiCongJSON));

                    return ser.Deserialize<DoiThiCongLight[]>(jr);
                }

                return new DoiThiCongLight[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                DoiThiCongJSON = sw.ToString();
            }
        }
        [NotMapped]
        public IEnumerable<DoiThiCong> DoiThiCongDTO { get; set; }

        [Display(Name = "Thiết kế")]
        [Column("ThietKe")]
        public string ThietKeJSON { get; set; }
        [Display(Name = "Thiết kế")]
        [NotMapped]
        public DoiThiCong_ThietKe[] ThietKe
        {
            get
            {
                if (!string.IsNullOrEmpty(ThietKeJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(ThietKeJSON));

                    return ser.Deserialize<DoiThiCong_ThietKe[]>(jr);
                }

                return new DoiThiCong_ThietKe[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                ThietKeJSON = sw.ToString();
            }
        }
        [NotMapped]
        public List<DoiThiCong_ThietKe> ThietKeDTO { get; set; }


        //[Display(Name = "Đội thi công")]
        //public DoiThiCong DoiThiCong { get; set; }
        //public Guid? DoiThiCongId { get; set; }

        //[Display(Name = "Đơn vị thành viên")]
        //public DonViThanhVien DonViThanhVien { get; set; }
        //public Guid? DonViThanhVienId { get; set; }

        //[Display(Name = "Đơn vị thiết kế")]
        //public DonViThanhVien DonViThietKe { get; set; }
        //public Guid? DonViThietKeId { get; set; }
    }
    //public enum LoaiDuAn
    //{
    //    NoiThat, KienTruc
    //}
    public class DoiThiCong_ThietKe
    {
        public Guid DonViThietKeId { get; set; }
        public string DonViThietKeName { get; set; }

        [NotMapped]
        public DonViThietKe DonViThietKe { get; set; }

        public Guid NhaThietKeId { get; set; }
        public string NhaThietKeName { get; set; }

        [NotMapped]
        public NhaThietKe NhaThietKe { get; set; }
    }

    public class DuAnCommon : BaseEntityWithSEoFields
    {

        //[Display(Name = "Trạng thái dự án")]
        //public TrangThaiDuAn TrangThaiDuAn { get; set; }

        [Display(Name = "Nhà thiết kế")]
        public virtual NhaThietKe NhaThietKe { get; set; }
        public Guid? NhaThietKeId { get; set; }

        [Display(Name = "Khu đô thị")]
        public string KhuDoThi { get; set; }

        [Required]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        
        [Display(Name = "Thông tin dự án")]
        public string ProjectInfo { get; set; }
        
        [Display(Name = "Ý tưởng thiết kế")]
        public string IdeaDescription { get; set; }

        [Display(Name = "Ảnh đại diện")]
        [Column("Avatars")]
        public string AvatarsJSON { get; set; }
        [Display(Name = "Ảnh đại diện")]
        [NotMapped]
        public string[] Avatars
        {
            get
            {
                if (!string.IsNullOrEmpty(AvatarsJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(AvatarsJSON));

                    return ser.Deserialize<string[]>(jr);
                }

                return new string[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                AvatarsJSON = sw.ToString();
            }
        }

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

        [Display(Name = "Ảnh nội dung")]
        [Column("ImageSections")]
        public string ImageSectionsJSON { get; set; }
        [Display(Name = "Ảnh nội dung")]
        [NotMapped]
        public DuAnNoiThat_ImageSection[] ImageSections
        {
            get
            {
                if (!string.IsNullOrEmpty(ImageSectionsJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(ImageSectionsJSON));

                    return ser.Deserialize<DuAnNoiThat_ImageSection[]>(jr);
                }

                return new DuAnNoiThat_ImageSection[0];
            }
            set
            {
                //var ser = new Newtonsoft.Json.JsonSerializer();
                //var sw = new StringWriter();
                //ser.Serialize(sw, value);
                //ImageSectionsJSON = sw.ToString();
                ImageSectionsJSON = JsonConvert.SerializeObject(value, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    },
                    Formatting = Formatting.Indented
                });
            }
        }

        [Display(Name = "Số lượt truy cập")]
        public string SoLuotTruyCap { get; set; }
    }

    public class DuAnNoiThat_Property
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class DuAnNoiThat_Filter
    {
        public string Name { get; set; }
        public string[] Value { get; set; }
    }

    public class DuAnNoiThat_ImageSection
    {
        public string Name { get; set; }
        public DuAnNoiThat_Property[] Filters { get; set; }
        public DuAnNoiThat_ImageSection_Image[] Images { get; set; }
    }

    public class DuAnNoiThat_ImageSection_Image
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DuAnNoiThat_Property[] Filters { get; set; }
    }

    // public enum TienDoThiCongNoiThat
    // {
    //     KhoiCong = 1, ThiCongDienNuoc = 2, ThiCongOpLatTranTuong = 3, ThiCongSonBa = 4, HoanThanh = 5
    // }
}
