using VimeoVideoTest2.Services;

namespace VimeoVideoTest2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IVimeoService, VimeoService>();
            //builder.Services.AddHttpClient<VimeoService>("VimeoApiClient", client =>
            //{
            //    client.BaseAddress = new Uri("https://api.vimeo.com/");
            //    client.DefaultRequestHeaders.Add("Authorization", "Bearer 50112eb714ef47dcbb89f13858047fc9");
            //});

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
