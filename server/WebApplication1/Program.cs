var builder = WebApplication.CreateBuilder(args);


    // Add services to the container.

    // Register DbContext for EF Core
    builder.Services.AddDbContext<EfcRepositories.AppContext>();

    // Register EF repositories
    builder.Services.AddScoped<RepositoryContracts.IPostRepository, EfcRepositories.EfcPostRepository>();
    builder.Services.AddScoped<RepositoryContracts.IUserRepository, EfcRepositories.EfcUserRepository>();
    builder.Services.AddScoped<RepositoryContracts.ICommentRepository, EfcRepositories.EfcCommentRepository>();
    

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

app.Run();