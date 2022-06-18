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
    public class VeChungToi
    {
        [JsonIgnore]
        public static string FileName = "VeChungToi.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Lãnh đạo")]
        [NotMapped]
        public string LeadersJSON { get; set; }
        [Display(Name = "Lãnh đạo")]
        public VeChungToi_Leader[] Leaders
        {
            get
            {
                if (!string.IsNullOrEmpty(LeadersJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(LeadersJSON));

                    return ser.Deserialize<VeChungToi_Leader[]>(jr);
                }

                return new VeChungToi_Leader[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                LeadersJSON = sw.ToString();
            }
        }
    }
    public class VeChungToi_Leader
    {
        [Display(Name = "Tên")]
        public string Title { get; set; }
        [Display(Name = "Ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Chức vụ")]
        public string Position { get; set; }
        [Display(Name = "Mô tả")]
        public string Content { get; set; }
        
    }


    public class GiaTriNiemTin
    {
        [JsonIgnore]
        public static string FileName = "GiaTriNiemTin.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Tầm nhìn")]
        public string TamNhin { get; set; }
        [Display(Name = "Sứ mệnh")]
        public string SuMenh { get; set; }
        [Display(Name = "Giá trị cốt lõi")]
        public string GiaTriCotLoi { get; set; }
        [Display(Name = "Sản phẩm - dịch vụ cốt lõi")]
        public string SanPhamDichVuCotLoi { get; set; }

        [Display(Name = "Nhà máy sản xuất")]
        [NotMapped]
        public string NhaMaySanXuatJSON { get; set; }
        [Display(Name = "Nhà máy sản xuất")]
        public string[] NhaMaySanXuat
        {
            get
            {
                if (!string.IsNullOrEmpty(NhaMaySanXuatJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(NhaMaySanXuatJSON));

                    return ser.Deserialize<string[]>(jr);
                }

                return new string[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                NhaMaySanXuatJSON = sw.ToString();
            }
        }

        [Display(Name = "Showroom nội thất mật khẩu")]
        [NotMapped]
        public string ShowroomJSON { get; set; }
        [Display(Name = "Showroom nội thất mật khẩu")]
        public string[] Showroom
        {
            get
            {
                if (!string.IsNullOrEmpty(ShowroomJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(ShowroomJSON));

                    return ser.Deserialize<string[]>(jr);
                }

                return new string[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                ShowroomJSON = sw.ToString();
            }
        }

        [Display(Name = "Hoạt động sự kiện")]
        [NotMapped]
        public string HoatDongSuKienJSON { get; set; }
        [Display(Name = "Hoạt động sự kiện")]
        public string[] HoatDongSuKien
        {
            get
            {
                if (!string.IsNullOrEmpty(HoatDongSuKienJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(HoatDongSuKienJSON));

                    return ser.Deserialize<string[]>(jr);
                }

                return new string[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                HoatDongSuKienJSON = sw.ToString();
            }
        }
    }


    public class LichSuPhatTrien
    {
        [JsonIgnore]
        public static string FileName = "LichSuPhatTrien.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
 
        [Display(Name = "Lịch sử phát triển")]
        [NotMapped]
        public string LichSuPhatTrienJSON { get; set; }
        [Display(Name = "Lịch sử phát triển")]
        public LichSuPhatTrien_Content[] LichSuPhatTrien_Content
        {
            get
            {
                if (!string.IsNullOrEmpty(LichSuPhatTrienJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(LichSuPhatTrienJSON));

                    return ser.Deserialize<LichSuPhatTrien_Content[]>(jr);
                }

                return new LichSuPhatTrien_Content[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                LichSuPhatTrienJSON = sw.ToString();
            }
        }
    }
    public class LichSuPhatTrien_Content
    {
        [Display(Name = "Năm")]
        public string Year { get; set; }
        [Display(Name = "Ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Mô tả")]
        public string Content { get; set; }

    }

    public class CoCauToChuc
    {
        [JsonIgnore]
        public static string FileName = "CoCauToChuc.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Mô tả")]
        public string Content { get; set; }

    }

    public class CamNhanKhachHang
    {
        [JsonIgnore]
        public static string FileName = "CamNhanKhachHang.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Mô tả")]
        public string Content { get; set; }

        [Display(Name = "Youtube")]
        [NotMapped]
        public string VideoLinksJSON { get; set; }
        [Display(Name = "Youtube")]
        public CamNhanKhachHang_VideoLink[] VideoLinks
        {
            get
            {
                if (!string.IsNullOrEmpty(VideoLinksJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(VideoLinksJSON));

                    return ser.Deserialize<CamNhanKhachHang_VideoLink[]>(jr);
                }

                return new CamNhanKhachHang_VideoLink[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                VideoLinksJSON = sw.ToString();
            }
        }
    }
    public class CamNhanKhachHang_VideoLink
    {
        [Display(Name = "Ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Youtube Link")]
        public string YoutubeLink { get; set; }

    }

    public class BaoChiNoi
    {
        [JsonIgnore]
        public static string FileName = "BaoChiNoi.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Mô tả")]
        public string Content { get; set; }

        [Display(Name = "Báo chí nói")]
        [NotMapped]
        public string BaoChiNoi_ContentJSON { get; set; }
        [Display(Name = "Báo chí nói")]
        public BaoChiNoi_Content[] BaoChiNoi_Content
        {
            get
            {
                if (!string.IsNullOrEmpty(BaoChiNoi_ContentJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(BaoChiNoi_ContentJSON));

                    return ser.Deserialize<BaoChiNoi_Content[]>(jr);
                }

                return new BaoChiNoi_Content[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                BaoChiNoi_ContentJSON = sw.ToString();
            }
        }
    }
    public class BaoChiNoi_Content
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

    public class TuyenDung
    {
        [JsonIgnore]
        public static string FileName = "TuyenDung.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Tuyển dụng")]
        [NotMapped]
        public string TuyenDung_ContentJSON { get; set; }
        [Display(Name = "Tuyển dụng")]
        public TuyenDung_Content[] TuyenDung_Content
        {
            get
            {
                if (!string.IsNullOrEmpty(TuyenDung_ContentJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(TuyenDung_ContentJSON));

                    return ser.Deserialize<TuyenDung_Content[]>(jr);
                }

                return new TuyenDung_Content[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                TuyenDung_ContentJSON = sw.ToString();
            }
        }
    }
    public class TuyenDung_Content
    {
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }


        [Display(Name = "Mô tả")]
        public string Content { get; set; }

    }

    public class LienHe
    {
        [JsonIgnore]
        public static string FileName = "LienHe.json";

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Liên hệ")]
        [NotMapped]
        public string LienHe_ContentJSON { get; set; }
        [Display(Name = "Liên hệ")]
        public LienHe_Content[] LienHe_Content
        {
            get
            {
                if (!string.IsNullOrEmpty(LienHe_ContentJSON))
                {
                    var ser = new Newtonsoft.Json.JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(LienHe_ContentJSON));

                    return ser.Deserialize<LienHe_Content[]>(jr);
                }

                return new LienHe_Content[0];
            }
            set
            {
                var ser = new Newtonsoft.Json.JsonSerializer();
                var sw = new StringWriter();
                ser.Serialize(sw, value);
                LienHe_ContentJSON = sw.ToString();
            }
        }
    }
    public class LienHe_Content
    {
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Mô tả")]
        public string Content { get; set; }

    }
}
