using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Data;
using SchoolManagement.Repositories;
using SchoolManagement.Repositories.Interfaces;
using SchoolManagement.Services;
using SchoolManagement.Services.Interfaces;

namespace SchoolManagement
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<SchoolManagementDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SchoolManagementDb")));

            services.AddIdentity<IdentityUser,IdentityRole>()
                .AddEntityFrameworkStores<SchoolManagementDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
            });

            services.AddSignalR();

            services.AddTransient<IExamService, ExamService>();
            services.AddTransient<IExamRepositoty, ExamRepositoty>();

            services.AddTransient<ISubjectService,SubjectService>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();

            services.AddTransient<IClassroomService, ClassroomService>();
            services.AddTransient<IClassroomRepository, ClassroomRepository>();

            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IChatRepository, ChatRepository>();

            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IMessageRepository, MessageRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseSignalR(routes =>
            {

            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Auth}/{action=Login}/{id?}");
            });
        }
    }
}
