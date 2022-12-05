
namespace WebAPI;

public class Program
{
 public static void Main(string[] args)
 {
  var builder = WebApplication.CreateBuilder(args);

  // Add services to the container.

  builder.Services.AddControllers();
  builder.Services.AddRazorPages();

  // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen();

  var app = builder.Build();

  // Configure the HTTP request pipeline.
  //if (app.Environment.IsDevelopment()) // in diesem Fall auch �ffentlich!
  //{
   app.UseSwagger();
   app.UseSwaggerUI();
  //}

  app.UseHttpsRedirection();

  app.UseAuthorization();
  app.UseStaticFiles();

  app.MapControllers();
  app.MapRazorPages();

  app.Run();
 }
}
