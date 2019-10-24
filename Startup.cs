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
    //StartupDevelopment��Կ�������
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

        //��Կ����������÷���
        //public void ConfigureDevelopment(IApplicationBuilder app, IWebHostEnvironment env) { }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //�жϻ��������Ƿ��ǿ�������
            //if(env.IsEnvironment("ok"))//�ж��Զ��廷��������ֵ ����Ŀ->����->����->��������������
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //��ȡ��̬�ļ��м��
            app.UseStaticFiles();

            //��HTTP����ת��ΪHTTPS����
            app.UseHttpsRedirection();

            //�����֤�м��
            app.UseAuthentication();

            //·���м��
            app.UseRouting();

            //�˵��м��
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Department}/{action=Index}/{id?}"
                    );
                //ԭ����
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
