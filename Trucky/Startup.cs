using System.IO.Compression;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trucky.Interfaces;
using Trucky.Models.DB;
using Trucky.Services;

namespace Trucky {
  public class Startup {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      services
        .AddMvcCore()
        .AddJsonFormatters(settings => {
          settings.DateFormatString = "MM/dd/yyyy";
        })
        .AddAuthorization()
        .AddDataAnnotations();

      // Configure response compression
      services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);
      services.AddResponseCompression(options => { options.Providers.Add<GzipCompressionProvider>(); });

      services.AddScoped<ITruckyService, TruckyService>();

      services.AddDbContext<TruckyContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
      app.UseStaticFiles();

      ConfigureRoutes(app, env);
    }

    private void ConfigureRoutes(IApplicationBuilder app, IHostingEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseBrowserLink();
        app.UseDeveloperExceptionPage();
      }
      else {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseMvc(routes => {
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
