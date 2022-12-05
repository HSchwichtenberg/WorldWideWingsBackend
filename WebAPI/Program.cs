//namespace WebAPI;

//public class Program
//{
// public static void Main(string[] args)
// {
//  var builder = WebApplication.CreateBuilder(args);

//  // Add services to the container.

//  builder.Services.AddControllers();
//  // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//  builder.Services.AddEndpointsApiExplorer();
//  builder.Services.AddSwaggerGen();

//  //builder.Services.AddRazorPages();

//  var app = builder.Build();

//  // Configure the HTTP request pipeline.
//  if (!app.Environment.IsDevelopment())
//  {
//   app.UseExceptionHandler("/Error");
//   // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//   app.UseHsts();
//  }

//  app.UseHttpsRedirection();
//  app.UseStaticFiles();

//  //app.UseRouting();

//  app.UseHttpsRedirection();
// app.UseAuthorization();

//  app.MapControllers();
//  //app.MapRazorPages();

//  app.Run();
// }
//}



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
  if (app.Environment.IsDevelopment())
  {
   app.UseSwagger();
   app.UseSwaggerUI();
  }

  app.UseHttpsRedirection();

  app.UseAuthorization();
  app.UseStaticFiles();

  app.MapControllers();
  app.MapRazorPages();

  app.Run();
 }
}
