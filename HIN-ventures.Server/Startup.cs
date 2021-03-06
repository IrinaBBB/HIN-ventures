using System;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using HIN_ventures.Business.Repositories;
using HIN_ventures.Business.Repositories.IRepositories;
using HIN_ventures.DataAccess.Data;
using HIN_ventures.DataAccess.Entities;
using HIN_ventures.Server.Hubs;
using HIN_ventures.Server.Service;
using HIN_ventures.Server.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;

namespace HIN_ventures.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            
            //services.AddResponseCompression(
            //    options => options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
            //        new[] { MediaTypeNames.Application.Octet }));

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSignalR();
            
            services.AddSingleton<HttpClient>(); //needed to consume external API in razor pages

            string dbConnectionString = Configuration.GetConnectionString("DefaultConnection");
            
            //MySQL
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString));
            });
            //SQL local server
            //services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            //});

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();
            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMudServices();

            services.AddScoped<IAssignmentRepository, AssignmentRepository>();
            services.AddScoped<IFreelancerRepository, FreelancerRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<ICrytoService, CryptoService>();
            services.AddScoped<ICodeFileRepository, CodeFileRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer)
        {

            //app.UseResponseCompression();
         
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            dbInitializer.Initalize();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{ action = Index2}/{ id ?}");
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                //endpoints.MapHub<ChatHub>("/chathub");
                endpoints.MapFallbackToPage("/_Host");
                //endpoints.MapHub<BlazorChatSampleHub>(BlazorChatSampleHub.HubUrl);
            });
        }
    }
}