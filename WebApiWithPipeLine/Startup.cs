using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PipeLine.Domain.Abstract;
using PipeLine.Domain.Builder;
using PipeLine.Domain.Executors;
using PipeLine.Domain.Options;
using PipeLine.Interfaces;
using PipeLine.Models.AddInfoToFileModels;

namespace WebApiWithPipeLine
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
            services.AddControllers();


            var options = new AddInfoToFileOptions();
            Configuration.GetSection(nameof(AddInfoToFileOptions)).Bind(options);
            services.AddOptions<AddInfoToFileOptions>().Configure(x => { x.FilePath = options.FilePath; });


            services.AddSingleton<IAddInfoToFileExecutor<AddInfoToFileInModel>, AddInfoToFileExecutor>();
            services.AddSingleton<IAddInfoToFileBuilder, AddInfoToFileBuilder>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }           

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
