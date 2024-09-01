using checkpoint4.Interfaces;
using checkpoint4.Services;

namespace checkpoint4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            //// Adiciona a configuração do CORS
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAll", policy =>
            //    {
            //        policy.AllowAnyOrigin()
            //              .AllowAnyMethod()
            //              .AllowAnyHeader();
            //    });
            //});

            builder.Services.AddHttpClient<IConversionRate, ExchangeRateService>(); // Adiciona o serviço com HttpClient
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "Currency Conversion API", Version = "v1" });
                c.DescribeAllParametersInCamelCase();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Currency Conversion API v1"));
            }

            // Adiciona o uso do CORS com a política definida
            //app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.MapControllers();

            // Corrigindo a adição de URLs separando-as corretamente.
            //app.Urls.Add("http://localhost:5002");
            //app.Urls.Add("https://localhost:5003");

            app.Run();
        }
    }
}
