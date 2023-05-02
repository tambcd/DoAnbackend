using QuanLyLopHocBL.ImplementService;
using QuanLyLopHocBL.IService;
using QuanLyLopHocDL.ImplementReponsitory;
using QuanLyLopHocDL.IReponsitory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/// <summary>
/// DL interface
/// </summary>
builder.Services.AddScoped<IBaseDL<object>, BaseDL<object>>();
builder.Services.AddScoped<IAccountDL, AccountDL>();
builder.Services.AddScoped<IUserDL, UserDL>();
builder.Services.AddScoped<IScheduleDL, ScheduleDL>();

/// <summary>
/// BLL Interface
/// </summary>
builder.Services.AddScoped<IBaseBL<object>, BaseBL<object>>();
builder.Services.AddScoped<IAccountBL, AccountBL>();
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.AddScoped<IScheduleBL, ScheduleBL>();

builder.Services.AddCors();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.UseAuthorization();

app.MapControllers();

app.Run();
