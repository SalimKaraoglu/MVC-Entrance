
/*
 *.net core k�t�phanesi olabildi�ince minimum gereksinimlere g�re yaz�ld��� i�in sadece uygulama ya�am d�ng�s� olan yap�lar sisteme program.cs dosyas�nda tan�mlan�r.
 *
 *Program.cs dosyas� .Net Core uygulamas�n�n �al��t��� dosyad�r. Burda uygulam ile ilgili t�m ayarlamalar yap�l�r. �rne�in uygulaman�n API , Razor veya MVC olarak tan�mlanmas� bu class �zerinden 
 *ger�ekle�ir. Bunun d���nda uygulaman�n i�erisinde kullan�lacak olan t�m ayarlarda yine bu dosya �zerinde yap�l�r. Uygulaman�n Authorization (Yetkilendirme) ve Authentication(Kimlik Do�rulama) 
 *ayarlar� , database ba�lant�lar� , HTTPS sertifika kullan�m ayarlar� , Route ayarlar� ve bir�ok ayar buradan y�netilir.
 */

var builder = WebApplication.CreateBuilder(args);

// Buraya ara servisler tan�mlan�r (Middleware'ler)
// Add services to the container.
builder.Services.AddControllersWithViews();

// B�t�n servisler burada �ncesinde tan�mlanmal�d�r

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())// Geli�tirme ortam�nda de�il ise(canl�daysa) hata durumda Home/Error sayfas� �al��t�r�r
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Https y�nlendirmesini aktive eder 
app.UseHttpsRedirection();

// Projede resim , m�zik gibi yap�lar�n kullan�labilece�ini s�yler
app.UseStaticFiles();// Static dosyalar

// Uygulamada iste�e ba�l� opsiyonel olarak y�nlendirmeden sorumlu method
// Uygulama taraf�ndan tan�mlanan endpoint lere bakar ve iste�e ba�l� olarak en iyi e�le�meyi se�er
app.UseRouting();

// Uygulamada yetkilendirme kullan
app.UseAuthorization();

// URL de arama k�sm�nda yazan yerdir
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
