using baitap_EF_DatabaseFirst_NhanVien.Models;

namespace baitap_EF_DatabaseFirst_NhanVien
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var context = new QuanLyNhanVienContext();

            var list = from nv in context.NhanViens
                       join pb in context.PhongBans on nv.MaPb equals pb.MaPb
                       where nv.Tuoi>=30 && nv.Tuoi<=40 && pb.MaPb== "PB001" 
                             && nv.GioiTinh=="Nam"
                       select new { nv, pb };
            Console.WriteLine("Cac nhan vien co tuoi tu 30 den 40 cua phong marketing la:");
            foreach ( var item in list )
            {
                Console.WriteLine($"MaNV: {item.nv.MaNv}, Ten: {item.nv.HoTen}, Tuoi: {item.nv.Tuoi}, Gioi tinh: {item.nv.GioiTinh}, Phong ban: {item.pb.TenPb}");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
