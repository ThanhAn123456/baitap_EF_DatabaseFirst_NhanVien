using System;
using System.Collections.Generic;

namespace baitap_EF_DatabaseFirst_NhanVien.Models;

public partial class NhanVien
{
    public string MaNv { get; set; } = null!;

    public string? HoTen { get; set; }

    public int? Tuoi { get; set; }

    public string? GioiTinh { get; set; }

    public string? DienThoai { get; set; }

    public string? Email { get; set; }

    public string? MaPb { get; set; }

    public virtual PhongBan? MaPbNavigation { get; set; }
}
