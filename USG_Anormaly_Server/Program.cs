global using USG_Anormaly_Server.Models.db;
global using Microsoft.EntityFrameworkCore;
global using USG_Anormaly_Server.Hubs;

using USG_Anormaly_lib;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.FileProviders;
using USG_Anormaly_Server;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "UTAC SINGAPORE MVI System", Version = "v1" })
);
builder.Services.AddDbContext<usg_anormaly_mvi_systemContext>();
DbInitializer.Initialize(new usg_anormaly_mvi_systemContext());

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(option =>
{
    option.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] {"application/octet-stream"});
});

builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(PathProcess._uploadPath));

var app = builder.Build();

app.UseResponseCompression();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHub<NotificationHub>("/notic");


//Task.Factory.StartNew(async () =>
//{
//    var con = new NotificationHub();
//    while (true)
//    {
//        await Task.Delay(1000);
//        await con.SendMessage("hello test 1234");
//    }
//});



app.Run();



