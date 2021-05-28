using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TesteVaiVoa.Repositories;

namespace TesteVaiVoa
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("BDCartaoVirtual"));

            //explico que a interface Icartaovirtualrepository é tratada pela cartaovirtualrepository
            services.AddTransient<ICartaoVirtualRepository, CartaoVirtualRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
            
        }
    }
}
