using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using WebApplication1.Data;
using WebApplication1.Serves.functions;


namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Console()
               .WriteTo.File("loggers/logger.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();






            builder.Host.UseSerilog();

            builder.Services.AddControllers(

                options =>
            {
                options.ReturnHttpNotAcceptable = true;

            }
            )
                .AddNewtonsoftJson()
                .AddXmlDataContractSerializerFormatters();



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //builder.Services.AddScoped<IHottelRepo, HottelRepo>();
            builder.Services.AddScoped<IFunctionGet, FunctionGet>();
            builder.Services.AddScoped<IFunctionPost, FunctionPost>();
            builder.Services.AddScoped<IFunctionDelete, FunctionDelete>();
            builder.Services.AddScoped<IFunctionPut, FunctionPut>();
            builder.Services.AddScoped<IFunctionUpdate, FunctionUpdate>();

            builder.Services.AddDbContext<AdminContext>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration["ConnectionStrings:database"]);
                }
                );

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // ÈÊÍãá ßá ÇáßáÇÓÇÊ (dll)


            builder.Services.AddAuthentication().AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidIssuer = builder.Configuration["Authentication:Issur"],
                    ValidAudience = builder.Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                };
            });

            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseAuthentication();



            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
