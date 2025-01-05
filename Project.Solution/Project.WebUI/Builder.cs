using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Project.WebUI
{
    public static class Builder
    {
        public static void AddWebServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }

        public static void UseWebServices(this WebApplicationBuilder builder)
        {
            IWebHostEnvironment env = builder.Environment;
            WebApplication app = builder.Build();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
