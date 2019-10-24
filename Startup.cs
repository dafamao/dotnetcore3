using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using New_Three.Services;

namespace New_Three
{
    //StartupDevelopment针对开发环境
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //services.AddSingleton<IClock, ChinaClock>();
            services.AddSingleton<IClock, UtcClock>();

            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
        }

        //针对开发环境配置方法
        //public void ConfigureDevelopment(IApplicationBuilder app, IWebHostEnvironment env) { }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //判断环境变量是否是开发环境
            //if(env.IsEnvironment("ok"))//判断自定义环境变量的值 在项目->属性->调试->环境变量中配置
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //获取静态文件中间件
            app.UseStaticFiles();

            //把HTTP请求转换为HTTPS请求
            app.UseHttpsRedirection();

            //身份认证中间件
            app.UseAuthentication();

            //路由中间件
            app.UseRouting();

            //端点中间件
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Department}/{action=Index}/{id?}"
                    );
                //原来的
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
