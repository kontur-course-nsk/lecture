namespace Notes.API
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Notes.Models.Notes.Repositories;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<INoteRepository, MemoryNoteRepository>();
        }

        public void Configure(IApplicationBuilder appBuilder)
        {
            appBuilder.UseMvc();
        }
    }
}
