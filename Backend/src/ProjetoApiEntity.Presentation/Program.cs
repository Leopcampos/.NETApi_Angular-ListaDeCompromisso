using ProjetoApiEntity.Presentation.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configurar o Entity Framework
builder.AddEntityFrameworkConfiguration();
builder.AddJwt();

#region CORS - Cross Origin Resource Sharing

builder.Services.AddCors(
s => s.AddPolicy("DefaultPolicy",
builder =>
{
    builder.AllowAnyOrigin()//clientes de qualquer origem
    .AllowAnyMethod()  //qualquer método (POST, PUT, DELETE, GET, etc)
    .AllowAnyHeader(); //qualquer cabeçalho
})
);

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region CORS - Cross Origin Resource Sharing

app.UseCors("DefaultPolicy");

#endregion

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
