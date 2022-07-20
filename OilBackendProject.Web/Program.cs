using OilBackendProject.Core;
using OilBackendProject.Web.Configuration;
using System.Reflection;
using Tochka.JsonRpc.Common.Serializers;
using Tochka.JsonRpc.Server;
using Tochka.JsonRpc.Server.Pipeline;
using Tochka.JsonRpc.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvc(option => option.EnableEndpointRouting = false)
    .AddJsonRpcServer(options =>
    {
        options.DefaultMethodOptions.Route = "/jsonrpc";
        options.AllowRawResponses = true;
        options.DefaultMethodOptions.RequestSerializer = typeof(CamelCaseJsonRpcSerializer);
    });
//.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

builder.Services.TryAddJsonRpcSerializer<CamelCaseJsonRpcSerializer>();
builder.Services.AddSwaggerWithJsonRpc(Assembly.GetExecutingAssembly());

var config = new AppConfig();
builder.Configuration.GetSection("AppConfig").Bind(config);
builder.Services.AddSingleton(s => OilServiceFactory.Create(config.OilJsonDataUrl));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<JsonRpcMiddleware>();
app.UseMvc();

app.MapControllers();

app.Run();
