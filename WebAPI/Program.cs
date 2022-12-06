namespace WebAPI;

public class Program
{
 public static void Main(string[] args)
 {

  var builder = WebApplication.CreateBuilder(args);

  // Get Connection String
  DA.WWWingsContext.ConnectionString = builder.Configuration.GetConnectionString("WWWings");

  #region Enable CORS 
  builder.Services.AddCors();
  #endregion


  // Add services to the container.

  builder.Services.AddControllers();
  builder.Services.AddRazorPages();

  // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen();

  var app = builder.Build();

  #region CORS
  // Namespace: using Microsoft.AspNet.Cors;
  app.UseCors(builder =>
  builder.SetIsOriginAllowed((x) => true) // statt .AllowAnyOrigin(), notwendig für SignalR-JavaScript-Client
         .AllowAnyHeader()
         .AllowAnyMethod()
         .AllowCredentials() // notwendig für SignalR-JavaScript-Client, siehe https://docs.microsoft.com/en-us/aspnet/core/signalr/javascript-client?view=aspnetcore-6.0
          );

  //.AllowCredentials() // InvalidOperationException: The CORS protocol does not allow specifying a wildcard (any) origin and 
  #endregion

  // Configure the HTTP request pipeline.
  //if (app.Environment.IsDevelopment()) // in diesem Fall auch öffentlich!
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
