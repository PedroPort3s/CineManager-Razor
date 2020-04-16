using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using CineManager.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using CineManager.Services;

namespace CineManager {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => {

            options.SignIn.RequireConfirmedAccount = true;
                options.SignIn.RequireConfirmedEmail = true;

                // provedor personalizado dos tokens de usuario de identidade - 1 dia � o padrao
                options.Tokens.ProviderMap.Add("CustomEmailConfirmacao", 
                    new TokenProviderDescriptor(typeof(CustomEmailTokenProv<IdentityUser>)));

                options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmacao";

            }).AddEntityFrameworkStores<ApplicationDbContext>();

            //Seri�o de personaliza��o do token
            services.AddTransient<CustomEmailTokenProv<IdentityUser>>();

            services.AddControllersWithViews();

            //Vida do token de seguran�a do email - identidade interna
            services.Configure<DataProtectionTokenProviderOptions>(o => o.TokenLifespan = TimeSpan.FromHours(3));

            //Autenticacao email e senha
            services.AddTransient<IEmailSender, SenderEmailConfirmacao>();
            services.Configure<EmailConfirmacao>(Configuration);

            //Inatividade padrao de 14 dias, mudando para 7 dias
            services.ConfigureApplicationCookie(o =>
            {
                o.ExpireTimeSpan = TimeSpan.FromDays(7);
                o.SlidingExpiration = true;
            });


            services.AddAuthorization(options => options.AddPolicy("CineManeger", policy => policy.RequireUserName("cinemanagerteam@gmail.com")));

            services.AddRazorPages();

            //Autentica��o do Google
            services.AddAuthentication().AddGoogle(options =>
            {
                IConfigurationSection googleAutentication = Configuration.GetSection("Authentication:Google");

                options.ClientId = googleAutentication["ClientId"];
                options.ClientSecret = googleAutentication["ClientSecret"];
            }).AddFacebook(facebookOptions => // Autentica��o do Facebook
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });


            // Problemas com o redirecionamento de falhas externas https://github.com/aspnet/Security/issues/1165
            //.AddMicrosoftAccount(ms => //Autentica��o da Microsoft 
            // {
            //     ms.ClientId = Configuration["Authentication:Microsoft:ClientId"];
            //     ms.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
            // })
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
