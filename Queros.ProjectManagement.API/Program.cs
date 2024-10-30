using Queros.ProjectManagement;
using Queros.ProjectManagement.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProjectManagementContextServices(builder.Configuration);
builder.Services.AddProjectManagementServices();
builder.Services.AddControllers();


var app = builder.Build();

app.UseRouting();
// Configure the HTTP request pipeline.
app.UseSwagger(options =>
{
    options.RouteTemplate = "projectManagement/swagger/{documentname}/swagger.json";
});
app.UseSwaggerUI(options => {
    options.SwaggerEndpoint("/projectManagement/swagger/v1/swagger.json", "projectManagement docs V1");
    options.RoutePrefix = "projectManagement/swagger";
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();

