using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SistemaDeMoedaEstudantil.Business;
using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repository;
using SistemaDeMoedaEstudantil.Repository.Implementation;
using SistemaDeMoedaEstudantil.Repositorys;
using SistemaDeMoedaEstudantil.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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

            //Configuração do Mapper
            var configMapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Vantagem, VantagemViewModel>().ReverseMap();
            });
            IMapper mapper = configMapper.CreateMapper();


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
            services.AddScoped<IVantagemRepository, VantagemRepositoryImplementation>();
            services.AddScoped<IVantagemBusiness, VantagemBusinessImplementation>();

            services.AddSingleton(mapper);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "wwwroot/Images")),
                RequestPath = "/Images"
            });
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
