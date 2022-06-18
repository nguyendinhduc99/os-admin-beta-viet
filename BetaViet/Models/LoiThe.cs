using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BetaViet.Models
{
    public class LoiThe_Main
    {
        [JsonIgnore]
        public static string FileName = "LoiThe_Main.json";

        [Display(Name = "Khối Nội dung")]
        [NotMapped]
        public string ContentJSON { get; set; }
        [Display(Name = "Khối Nội dung")]
        public LoiThe_Main_Common<LoiThe_Main_Common_NoiDung>[] Content
        {
            get
            {
                if (!string.IsNullOrEmpty(ContentJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(ContentJSON));

                    return ser.Deserialize<LoiThe_Main_Common<LoiThe_Main_Common_NoiDung>[]>(jr);
                }

                return new LoiThe_Main_Common<LoiThe_Main_Common_NoiDung>[0];
            }
            set
            {
                ContentJSON = JsonConvert.SerializeObject(value, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    },
                    Formatting = Formatting.Indented
                });
            }
        
        }
    }

    public class LoiThe_QuyMoCongTy : LoiThe_Main
    {
        [JsonIgnore]
        public static string FileName = "LoiThe_QuyMoCongTy.json";

        [Display(Name = "Banners")]
        [NotMapped]
        public string BannersJSON { get; set; }
        [Display(Name = "Banners")]
        public Banner[] Banners
        {
            get
            {
                if (!string.IsNullOrEmpty(BannersJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(BannersJSON));

                    return ser.Deserialize<Banner[]>(jr);
                }

                return new Banner[0];
            }
            set
            {
                BannersJSON = JsonConvert.SerializeObject(value, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    },
                    Formatting = Formatting.Indented
                });
            }
        }
    }
    public class LoiThe_NangLucThietKe : LoiThe_QuyMoCongTy
    {
        [JsonIgnore]
        public static string FileName = "LoiThe_NangLucThietKe.json";
    }
    public class LoiThe_NangLucThiCong : LoiThe_QuyMoCongTy
    {
        [JsonIgnore]
        public static string FileName = "LoiThe_NangLucThiCong.json";
    }
    public class LoiThe_ShowroomNoiThat : LoiThe_QuyMoCongTy
    {
        [JsonIgnore]
        public static string FileName = "LoiThe_ShowroomNoiThat.json";
    }
    public class LoiThe_NhaMaySanXuat : LoiThe_QuyMoCongTy
    {
        [JsonIgnore]
        public static string FileName = "LoiThe_NhaMaySanXuat.json";
    }
    public class LoiThe_ChamSocKhachHang : LoiThe_QuyMoCongTy
    {
        [JsonIgnore]
        public static string FileName = "LoiThe_ChamSocKhachHang.json";
    }
    public class LoiThe_GiamSatNghiemNhat : LoiThe_QuyMoCongTy
    {
        [JsonIgnore]
        public static string FileName = "LoiThe_GiamSatNghiemNhat.json";
    }
    public class LoiThe_BaoHangUyTin : LoiThe_QuyMoCongTy
    {
        [JsonIgnore]
        public static string FileName = "LoiThe_BaoHangUyTin.json";
    }

    public class LoiThe_Main_Common<T>
    {
        [Display(Name = "Tiêu đề chính")]
        public string Title { get; set; }
        [Display(Name = "Tiêu đề phụ")]
        public string Subtitle { get; set; }
        [Display(Name = "Ảnh")]
        public string Image { get; set; }

        [Display(Name = "Nội dung")]
        [NotMapped]
        public string ContentJSON { get; set; }
        [Display(Name = "Nội dung")]
        public T[] Content
        {
            get
            {
                if (!string.IsNullOrEmpty(ContentJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(ContentJSON));

                    return ser.Deserialize<T[]>(jr);
                }

                return new T[0];
            }
            set
            {
                //var ser = new Newtonsoft.Json.JsonSerializer();
                //var sw = new StringWriter();
                //ser.Serialize(sw, value);
                //ContentJSON = sw.ToString();

                ContentJSON = JsonConvert.SerializeObject(value, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    },
                    Formatting = Formatting.Indented
                });
            }
        }
    }
    public class LoiThe_Main_Common_NoiDung
    {
        [Display(Name = "Tiêu đề chính")]
        public string Title { get; set; }
        [Display(Name = "Tiêu đề phụ")]
        public string Subtitle { get; set; }
        [Display(Name = "Ảnh")]
        public string Image { get; set; }
        [Display(Name = "Link")]
        public string Link { get; set; }
    }


    public class Banner
    {
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Ảnh")]
        public string Image { get; set; }
    }

    public class LoiThe_Banner
    {
        [Display(Name = "Banners")]
        [NotMapped]
        public string BannersJSON { get; set; }
        [Display(Name = "Banners")]
        public Banner[] Banners
        {
            get
            {
                if (!string.IsNullOrEmpty(BannersJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(BannersJSON));

                    return ser.Deserialize<Banner[]>(jr);
                }

                return new Banner[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                BannersJSON = sw.ToString();
            }
        }
    }

    public class LoiThe_QuyMoCongTy_Banner : LoiThe_Banner
    {
        [JsonIgnore]
        public static string FileName = "LoiThe_QuyMoCongTy_Banner.json";
    }

    public class LoiThe_ShowRoom_BoSuuTap : DuAnCommon
    {

    }
}
