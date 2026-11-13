using AspNetCoreUseKeyedServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// 注册 keyed services
builder.Services.AddKeyedScoped<INotifier, SmsNotifier>("sms");
builder.Services.AddKeyedScoped<INotifier, EmailNotifier>("email");

builder.Services.AddScoped<INotifierFactory, NotifierFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
