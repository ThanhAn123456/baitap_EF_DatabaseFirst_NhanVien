using System;
using System.Collections.Generic;

namespace baitap_EF_DatabaseFirst_NhanVien.Models;

public partial class PhongBan
{
    public string MaPb { get; set; } = null!;

    public string? TenPb { get; set; }

    public string? MaCongTy { get; set; }

    public virtual CongTy? MaCongTyNavigation { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
