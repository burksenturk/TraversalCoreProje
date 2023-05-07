using BusinessLayer.Container;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using TraversalCoreProje.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProje.Models;

namespace TraversalCoreProje
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<GetAllDestinationQueryHandler>();
            services.AddScoped<GetDestinationByIDQueryHandler>();
            services.AddScoped<CreateDestinationCommandHandler>();
            services.AddScoped<RemoveDestinationCommandHandler>();
            services.AddScoped<UpdateDestinationCommandHandler>();

            services.AddMediatR(typeof(Startup));
            //loglama iþlemleri için oluþturdum
            services.AddLogging(x =>
            {
                x.ClearProviders(); //mevcutta saðlayýcýlar varsa temizle çünkü ben kendi loglaarýmý kaydedicem
                x.SetMinimumLevel(LogLevel.Debug); // loglama iþlemi debug dan itibaren baþlasýn
                x.AddDebug(); // nereye loglamak istiyoruz. burada output da gözeücek
            });

            services.AddDbContext<Context>(); //amacýmýz Identity yapýsýný  ConfigureServices içerisinde tanýmlamak hem de proje seviyesinde bir authentication uygulamak ki sadece benim istediðim sayfalarda bu authentication kodlarý allowanonymous komutuyla bunu bozabiliriz
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>();//Identity yapýlandýramsýný eklemiþ olduk  ConfigureServices A

            services.AddHttpClient();

            services.ContainerDependencies();  //kod kalabalýðýný container klasörü açarak yok ettik. BusinessLayer Container klsörü
            
            services.CustomerValidator();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews().AddFluentValidation();

            //proje seviyesinde bir authentication iþlemi kullanýyor olucaz
            services.AddMvc(config=>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser() //kullanýcýnýn mutlaka Authenticate olmasý lazým.
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddMvc();
            //bir kullanýcý autotantice olmadan giriþ yapmýþsa buraya yönlendir...
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/SignIn/";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log1.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}"); //Hata sayfasna eriþmem için yazdým.

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
