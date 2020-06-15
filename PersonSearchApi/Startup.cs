using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PersonSearchApi.Data.Mappers;
using PersonSearchApi.Data.Models;
using PersonSearchApi.Helper;
using PersonSearchApi.Services;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PersonSearchApi
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
      services.AddDbContext<PersonDbContext>(options =>
        options.UseInMemoryDatabase("PersonDB"));

      services.AddCors(options =>
      {
        options.AddPolicy("AllowOrigin",
          builder => builder.WithOrigins("http://localhost:4700"));
      });

      services.AddScoped<IPersonService, PersonService>();
      services.AddAutoMapper(typeof(MappingProfiles));
      services.AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
          //options.SuppressModelStateInvalidFilter = true; //prevents auto validation
        });
      services.AddApiVersioning(options =>
      {
        options.ReportApiVersions = true;
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ApiVersionReader = new HeaderApiVersionReader("X-API-Version");
      });
      services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");
      services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
      services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
      services.AddAutoMapper(typeof(Startup));

      services.AddSingleton<IMapper, Mapper>();
      services.AddMediatR(typeof(Startup));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
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

      app.UseSwagger();
      app.UseSwaggerUI(options =>
      {
        foreach (var description in provider.ApiVersionDescriptions)
        {
          options.SwaggerEndpoint(
            $"/swagger/{description.GroupName}/swagger.json",
            description.GroupName.ToUpperInvariant()
          );
        }
      });
    }
  }
}
