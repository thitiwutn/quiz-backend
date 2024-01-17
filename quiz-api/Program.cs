using Microsoft.EntityFrameworkCore;
using quiz_api.Entities;
using quiz_api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Add Service DatabaseContext
builder.Services.AddDbContext<DatabaseContext>();

// Add log
builder.Services.AddHttpLogging(o => { });
builder.Services.AddLogging();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<QuizService>();
builder.Services.AddScoped<GroupService>();

var app = builder.Build();

// Migrate database 
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseHttpLogging();


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