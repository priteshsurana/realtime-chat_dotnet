var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional:false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional:true)
    .AddEnvironmentVariables();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
    options.HttpsPort = 7136;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.Run();

