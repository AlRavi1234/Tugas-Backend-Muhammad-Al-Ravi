using Microsoft.EntityFrameworkCore;
using TugasMinggu1.data.DAL;
using TugasMinggu1.Data;
using TugasMinggu1.Data.DAL;
//using TugasMinggu1.Helpers;
//using TugasMinggu1.Services;
using TugasMinggu1.Helpers;
using TugasMinggu1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//menambahkan automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//menambahkan konfigurasi EF
builder.Services.AddDbContext<SwordContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SwordConnection")).EnableSensitiveDataLogging());
//builder.Services.AddDbContext<SwordContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SwordConnection")));

// database connection string configuration  
//builder.Services.AddDbContextPool<SwordContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnectionString"),
//  mySqlOptionsAction: options => { options.EnableRetryOnFailure(); }
//  ));
//inject class DAL
builder.Services.AddScoped<ISword, SwordDAL>();
builder.Services.AddScoped<IElemen, ElemenDAL>();
builder.Services.AddScoped<ISamurai, SamuraiDAL>();
builder.Services.AddScoped<ITipe, TipeDAL>();
builder.Services.AddScoped<IUserService, UserService>();

// configure strongly typed settings object
//builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// configure DI for application services


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

//app.UseHttpsRedirection();
//app.UseAuthorization();
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();