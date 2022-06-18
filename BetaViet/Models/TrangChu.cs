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
    public class TrangChuThongTin
    {
        [JsonIgnore]
        public static string FileName = "TrangChuThongTin.json";

        [Display(Name = "Nội dung")]
        [NotMapped]
        public string ContentJSON { get; set; }
        [Display(Name = "Nội dung")]
        public TrangChuThongTin_Content[] Content
        {
            get
            {
                if (!string.IsNullOrEmpty(ContentJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(ContentJSON));

                    return ser.Deserialize<TrangChuThongTin_Content[]>(jr);
                }

                return new TrangChuThongTin_Content[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                ContentJSON = sw.ToString();
            }
        }
    }
    public class TrangChuThongTin_Content
    {
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Mô tả")]
        public string Content { get; set; }
        [Display(Name = "Link")]
        public string Link { get; set; }
    }

    public class TrangChuMoTaDichVu
    {
        [JsonIgnore]
        public static string FileName = "TrangChuMoTaDichVu.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Tiêu đề phụ")]
        public string Subtitle { get; set; }

        [Display(Name = "Nội dung")]
        [NotMapped]
        public string ContentJSON { get; set; }
        [Display(Name = "Nội dung")]
        public TrangChuMoTaDichVu_Content[] Content
        {
            get
            {
                if (!string.IsNullOrEmpty(ContentJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(ContentJSON));

                    return ser.Deserialize<TrangChuMoTaDichVu_Content[]>(jr);
                }

                return new TrangChuMoTaDichVu_Content[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                ContentJSON = sw.ToString();
            }
        }
    }
    public class TrangChuMoTaDichVu_Content
    {
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Mô tả")]
        public string Content { get; set; }

    }

    public class TrangChuMoTaThiCong
    {
        [JsonIgnore]
        public static string FileName = "TrangChuMoTaThiCong.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Tiêu đề phụ")]
        public string Subtitle { get; set; }

        [Display(Name = "Nội dung")]
        [NotMapped]
        public string ContentJSON { get; set; }
        [Display(Name = "Nội dung")]
        public TrangChuMoTaThiCong_Content[] Content
        {
            get
            {
                if (!string.IsNullOrEmpty(ContentJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(ContentJSON));

                    return ser.Deserialize<TrangChuMoTaThiCong_Content[]>(jr);
                }

                return new TrangChuMoTaThiCong_Content[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                ContentJSON = sw.ToString();
            }
        }
    }
    public class TrangChuMoTaThiCong_Content
    {
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Mô tả")]
        public string Content { get; set; }
        [Display(Name = "Link")]
        public string Link { get; set; }

    }

    public class TrangChuThamKhaoThietKe
    {
        [JsonIgnore]
        public static string FileName = "TrangChuThamKhaoThietKe.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Tiêu đề phụ")]
        public string Subtitle { get; set; }
    }
    public class TrangChuDeXuatThietKe
    {
        [JsonIgnore]
        public static string FileName = "TrangChuDeXuatThietKe.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Tiêu đề phụ")]
        public string Subtitle { get; set; }
    }

    public class TrangChuHeThongBeta
    {
        [JsonIgnore]
        public static string FileName = "TrangChuHeThongBeta.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Tiêu đề phụ")]
        public string Subtitle { get; set; }

        [Display(Name = "Nội dung")]
        [NotMapped]
        public string ContentJSON { get; set; }
        [Display(Name = "Nội dung")]
        public string[] Content
        {
            get
            {
                if (!string.IsNullOrEmpty(ContentJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(ContentJSON));

                    return ser.Deserialize<string[]>(jr);
                }

                return new string[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                ContentJSON = sw.ToString();
            }
        }

    }

    public class TrangChuThamQuanCongTrinh
    {
        [JsonIgnore]
        public static string FileName = "TrangChuThamQuanCongTrinh.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Tiêu đề phụ")]
        public string Subtitle { get; set; }

        [Display(Name = "Nội dung")]
        [NotMapped]
        public string ContentJSON { get; set; }
        [Display(Name = "Nội dung")]
        public TrangChuThamQuanCongTrinh_Content[] Content
        {
            get
            {
                if (!string.IsNullOrEmpty(ContentJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(ContentJSON));

                    return ser.Deserialize<TrangChuThamQuanCongTrinh_Content[]>(jr);
                }

                return new TrangChuThamQuanCongTrinh_Content[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                ContentJSON = sw.ToString();
            }
        }
    }
    public class TrangChuThamQuanCongTrinh_Content
    {
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Link")]
        public string Link { get; set; }

    }

    public class TrangChuCongTyThanhVien
    {
        [JsonIgnore]
        public static string FileName = "TrangChuCongTyThanhVien.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Tiêu đề phụ")]
        public string Subtitle { get; set; }
    }
    public class TrangChuVideoDuAn
    {
        [JsonIgnore]
        public static string FileName = "TrangChuVideoDuAn.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Tiêu đề phụ")]
        public string Subtitle { get; set; }
    }

    public class TrangChuLoiTheNoiBat
    {
        [JsonIgnore]
        public static string FileName = "TrangChuLoiTheNoiBat.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Tiêu đề phụ")]
        public string Subtitle { get; set; }

        [Display(Name = "Nội dung")]
        [NotMapped]
        public string ContentJSON { get; set; }
        [Display(Name = "Nội dung")]
        public TrangChuLoiTheNoiBat_Content[] Content
        {
            get
            {
                if (!string.IsNullOrEmpty(ContentJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(ContentJSON));

                    return ser.Deserialize<TrangChuLoiTheNoiBat_Content[]>(jr);
                }

                return new TrangChuLoiTheNoiBat_Content[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                ContentJSON = sw.ToString();
            }
        }
    }
    public class TrangChuLoiTheNoiBat_Content
    {
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Mô tả")]
        public string Content { get; set; }
        [Display(Name = "Link")]
        public string Link { get; set; }

    }

    public class TrangChuQuyTrinhThucHien
    {
        [JsonIgnore]
        public static string FileName = "TrangChuQuyTrinhThucHien.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Tiêu đề phụ")]
        public string Subtitle { get; set; }

        [Display(Name = "Nội dung")]
        [NotMapped]
        public string ContentJSON { get; set; }
        [Display(Name = "Nội dung")]
        public TrangChuQuyTrinhThucHien_Content[] Content
        {
            get
            {
                if (!string.IsNullOrEmpty(ContentJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(ContentJSON));

                    return ser.Deserialize<TrangChuQuyTrinhThucHien_Content[]>(jr);
                }

                return new TrangChuQuyTrinhThucHien_Content[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                ContentJSON = sw.ToString();
            }
        }
    }
    public class TrangChuQuyTrinhThucHien_Content
    {
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Mô tả")]
        public string Content { get; set; }
    }

    public class TrangChuShowroom
    {
        [JsonIgnore]
        public static string FileName = "TrangChuShowroom.json";

        [Display(Name = "Nội dung")]
        [NotMapped]
        public string ContentJSON { get; set; }
        [Display(Name = "Nội dung")]
        public TrangChuShowroom_Content[] Content
        {
            get
            {
                if (!string.IsNullOrEmpty(ContentJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(ContentJSON));

                    return ser.Deserialize<TrangChuShowroom_Content[]>(jr);
                }

                return new TrangChuShowroom_Content[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                ContentJSON = sw.ToString();
            }
        }
    }
    public class TrangChuShowroom_Content
    {
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Mô tả")]
        public string Content { get; set; }
        [Display(Name = "Link")]
        public string Link { get; set; }
    }

    public class TrangChuKienThuc
    {
        [JsonIgnore]
        public static string FileName = "TrangChuKienThuc.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Tiêu đề phụ")]
        public string Subtitle { get; set; }
    }

    public class TrangChuLienKet
    {
        [JsonIgnore]
        public static string FileName = "TrangChuLienKet.json";

        [Display(Name = "Nội dung")]
        [NotMapped]
        public string ContentJSON { get; set; }
        [Display(Name = "Nội dung")]
        public TrangChuLienKet_Content[] Content
        {
            get
            {
                if (!string.IsNullOrEmpty(ContentJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(ContentJSON));

                    return ser.Deserialize<TrangChuLienKet_Content[]>(jr);
                }

                return new TrangChuLienKet_Content[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                ContentJSON = sw.ToString();
            }
        }
    }
    public class TrangChuLienKet_Content
    {
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Link")]
        public string Link { get; set; }
    }

}