
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<IKycService, KycService>();

var app = builder.Build();

app.UseMiddleware<MockMiddleware>();

app.MapControllers();

app.Run();

