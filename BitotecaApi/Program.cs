using BitotecaApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var conectionAutor = builder.Configuration.GetConnectionString("AutorConnection");

builder.Services.AddDbContext<AutorContext>(opts => opts.UseMySql(conectionAutor, ServerVersion.AutoDetect(conectionAutor)));

var conectionLivro = builder.Configuration.GetConnectionString("LivroConnection");

builder.Services.AddDbContext<LivroContext>(opts => opts.UseMySql(conectionLivro, ServerVersion.AutoDetect(conectionLivro)));

var conectionGenero = builder.Configuration.GetConnectionString("GeneroConnection");

builder.Services.AddDbContext<GeneroContext>(opts => opts.UseMySql(conectionGenero, ServerVersion.AutoDetect(conectionGenero)));

var conectionEditora = builder.Configuration.GetConnectionString("EditoraConnection");

builder.Services.AddDbContext<EditoraContext>(opts => opts.UseMySql(conectionEditora, ServerVersion.AutoDetect(conectionEditora)));

var conectionLinguagem = builder.Configuration.GetConnectionString("LinguagemConnection");

builder.Services.AddDbContext<IdiomaContext>(opts => opts.UseMySql(conectionLinguagem, ServerVersion.AutoDetect(conectionLinguagem)));


var apiCorsPolicy = "apiCorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: apiCorsPolicy,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:5173", "https://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                          //.WithMethods("OPTIONS", "GET");
                      });
});


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(apiCorsPolicy);

app.Run();
