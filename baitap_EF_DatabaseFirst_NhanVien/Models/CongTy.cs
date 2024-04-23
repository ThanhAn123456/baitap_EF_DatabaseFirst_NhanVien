using System;
using System.Collections.Generic;

namespace baitap_EF_DatabaseFirst_NhanVien.Models;

public partial class CongTy
{
    public string MaCongTy { get; set; } = null!;

    public string? TenCongTy { get; set; }

    public virtual ICollection<PhongBan> PhongBans { get; set; } = new List<PhongBan>();
}
