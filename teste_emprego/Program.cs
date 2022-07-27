

var builder = WebApplication.CreateBuilder(args);
var con = new teste_emprego.DAO.Conexao();


// Add services to the container.

builder.Services.AddControllers();
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

var status = con.testeConexao();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



