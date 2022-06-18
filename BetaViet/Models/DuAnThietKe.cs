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

    public class TienDoThiCong : BaseEntity
    {
        [Required]
        [Display(Name = "Giá trị")]
        public string Value { get; set; }
        [Display(Name = "Thứ tự")]
        public int Order { get; set; }

        [Display(Name = "Cho trang")]
        public TrangBoLoc Page { get; set; }
    }

    public enum TrangThaiDuAn
    {
        Moi, DangThiCong, DaXong
    }
}
