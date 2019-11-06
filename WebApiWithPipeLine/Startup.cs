using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PipeLine.AddInfoToFile.Adapters;
using PipeLine.AddInfoToFile.Interfaces;
using PipeLine.AddInfoToFile.Models;
using PipeLine.AddInfoToFile.Steps;
using PipeLine.AddInfoToFile.Steps.Options;
using PipeLine.Domain.Builder;
using PipeLine.Domain.Executors;
using PipeLine.Interfaces;
using PipeLine.StandardPipeLine;

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
            ConfigureAllRelatedToPipeLine(services);
        }

        // TODO наверное лучше разбить эти конфигурации и часть делать именно в AddInfoToFile стартапе
        private void ConfigureAllRelatedToPipeLine(IServiceCollection services)
        {
            ConfigurePipeLine(services);
            ConfigureAddInfoFileExecutor(services);
            ConfigureStepsBuilder(services);
            ConfigureSteps(services);
        }

        private void ConfigureAddInfoFileExecutor(IServiceCollection services)
        {
            services.AddSingleton<IAddInfoToFileExecutor<AddInfoToFileInModel>, AddInfoToFileExecutor>();
        }

        /// <summary>
        /// Бинд реализации пайп лайна
        /// </summary>
        /// <param name="services"></param>
        private void ConfigurePipeLine(IServiceCollection services)
        {            
            services.AddSingleton<IPipeLine<AddInfoToFileInModel, AddInfoToFileResult>, StandardPipeLine<AddInfoToFileInModel, AddInfoToFileResult>>();
        }

        /// <summary>
        /// Бинд билдера шагов
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureStepsBuilder(IServiceCollection services)
        {
            services.AddSingleton<IAddInfoToFileBuilder<AddInfoToFileInModel, AddInfoToFileResult>, AddInfoToFileBuilder>();            
        }

        /// <summary>
        /// Бинд самих шагов
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureSteps(IServiceCollection services)
        {
            // Нужны т.к. будут использоваться вэтих шагах
            AddSaveWordsToFileOptions(services);
            AddSeparateWordsOptions(services);

            services.AddSingleton<IStepsAdapter<AddInfoToFileInModel, SeparateWordsInModel>, StartInfoToSeparateWordsAdapter>();
            services.AddSingleton<IStep<SeparateWordsInModel, SeparateWordsResult>, SeparateWords>();
            services.AddSingleton<IStepsAdapter<SeparateWordsResult, SaveWordsToFileInModel>, SaveGoodWordsToFileAdapter>();
            services.AddSingleton<IStep<SaveWordsToFileInModel, SaveWordsToFileResult>, SaveWordsToFile>();
            services.AddSingleton<IStepsAdapter<SaveWordsToFileResult, AddInfoToFileResult>, SaveWordsResultToAddInfoToFileResultAdapter>();
        }

        public void AddSaveWordsToFileOptions(IServiceCollection services)
        {
            var saveWordsToFileOptions = new SaveWordsToFileOptions();
            Configuration.GetSection(nameof(SaveWordsToFileOptions)).Bind(saveWordsToFileOptions);
            services.AddOptions<SaveWordsToFileOptions>().Configure(x => { x.FilePath = saveWordsToFileOptions.FilePath; x.DelayTime = saveWordsToFileOptions.DelayTime; });
        }

        public void AddSeparateWordsOptions(IServiceCollection services)
        {
            var separateWordsOptions = new SeparateWordsOptions();
            Configuration.GetSection(nameof(SeparateWordsOptions)).Bind(separateWordsOptions);
            services.AddOptions<SeparateWordsOptions>().Configure(x => { x.DelayTime = separateWordsOptions.DelayTime; x.BadWords = separateWordsOptions.BadWords; });
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

