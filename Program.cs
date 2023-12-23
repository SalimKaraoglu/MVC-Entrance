
/*
 *.net core kütüphanesi olabildiðince minimum gereksinimlere göre yazýldýðý için sadece uygulama yaþam döngüsü olan yapýlar sisteme program.cs dosyasýnda tanýmlanýr.
 *
 *Program.cs dosyasý .Net Core uygulamasýnýn çalýþtýðý dosyadýr. Burda uygulam ile ilgili tüm ayarlamalar yapýlýr. Örneðin uygulamanýn API , Razor veya MVC olarak tanýmlanmasý bu class üzerinden 
 *gerçekleþir. Bunun dýþýnda uygulamanýn içerisinde kullanýlacak olan tüm ayarlarda yine bu dosya üzerinde yapýlýr. Uygulamanýn Authorization (Yetkilendirme) ve Authentication(Kimlik Doðrulama) 
 *ayarlarý , database baðlantýlarý , HTTPS sertifika kullaným ayarlarý , Route ayarlarý ve birçok ayar buradan yönetilir.
 */

var builder = WebApplication.CreateBuilder(args);

// Buraya ara servisler tanýmlanýr (Middleware'ler)
// Add services to the container.
builder.Services.AddControllersWithViews();

// Bütün servisler burada öncesinde tanýmlanmalýdýr

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())// Geliþtirme ortamýnda deðil ise(canlýdaysa) hata durumda Home/Error sayfasý çalýþtýrýr
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Https yönlendirmesini aktive eder 
app.UseHttpsRedirection();

// Projede resim , müzik gibi yapýlarýn kullanýlabileceðini söyler
app.UseStaticFiles();// Static dosyalar

// Uygulamada isteðe baðlý opsiyonel olarak yönlendirmeden sorumlu method
// Uygulama tarafýndan tanýmlanan endpoint lere bakar ve isteðe baðlý olarak en iyi eþleþmeyi seçer
app.UseRouting();

// Uygulamada yetkilendirme kullan
app.UseAuthorization();

// URL de arama kýsmýnda yazan yerdir
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
