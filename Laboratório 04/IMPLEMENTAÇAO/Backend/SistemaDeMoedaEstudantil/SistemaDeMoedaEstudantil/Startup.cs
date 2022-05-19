using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SistemaDeMoedaEstudantil.Business;
using SistemaDeMoedaEstudantil.Repository;
using SistemaDeMoedaEstudantil.Repository.Implementation;
using SistemaDeMoedaEstudantil.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeMoedaEstudantil
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

            services.AddCors(oprtions => oprtions.AddDefaultPolicy(builder => {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            services.AddDbContext<SistemaMoedaEstudantilContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), builder =>
            builder.MigrationsAssembly("SistemaDeMoedaEstudantil")));

            //Dependency Injection
            services.AddScoped<IAlunoRepository, AlunoRepositoryImplementation>();
            services.AddScoped<IAlunoBusiness, AlunoBusinessImplementation>();
            services.AddScoped<IProfessorRepository, ProfessorRepositoryImplementation>();
            services.AddScoped<IProfessorBusiness, ProfessorBusinessImplementation>();
            services.AddScoped<IContaRepository, ContaRepositoryImplementation>();
            services.AddScoped<IContaBusiness, ContaBusinessImplementation>();
            services.AddScoped<IExtratoRepository, ExtratoRepositoryImplementation>();
            services.AddScoped<IExtratoBusiness, ExtratoBusinessImplementation>();
            services.AddScoped<IEmpresaParceiraRepository, EmpresaParceiraRepositoryImplementation>();
            services.AddScoped<IEmpresaParceiraBusiness, EmpresaParceiraBusinessImplementation>();
            services.AddScoped<IInstituicaoEnsinoRepository, InstituicaoEnsinoRepositoryImplementation>();
            services.AddScoped<IInstituicaoEnsinoBusiness, InstituicaoEnsinoBusinessImplementation>();
            services.AddScoped<IUserRepository, UserRepositoryImplementation>();
            services.AddScoped<IUserBusiness, UserBusinessImplementation>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
