using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.(raboti sto ke gi dodavame vo proektot za injektirame vo drugite klasi)
builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});



var app = builder.Build();

// Configure the HTTP request pipeline.(doagaat requesti i isprakaat response)
app.MapControllers();

//za seed na db
DbInitializer.InitDb(app);

app.Run();
