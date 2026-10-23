

using FootyCore.BusinessLayer.Abstract;
using FootyCore.BusinessLayer.Concrete;
using FootyCore.DataAccessLayer.Abstract;
using FootyCore.DataAccessLayer.EntityFramework;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILeagueService, LeagueManager>();
builder.Services.AddScoped<ILeagueDal, EfLeagueDal>();

builder.Services.AddScoped<IMatchService, MatchManager>();
builder.Services.AddScoped<IMatchDal, EfMatchDal>();

builder.Services.AddScoped<IMatchDetailService, MatchDetailManager>();
builder.Services.AddScoped<IMatchDetailDal, EfMatchDetailDal>();

builder.Services.AddScoped<IMatchStatisticService, MatchStatisticManager>();
builder.Services.AddScoped<IMatchStatisticDal, EfMatchStatisticDal>();

builder.Services.AddScoped<IMatchStatusService, MatchStatusManager>();
builder.Services.AddScoped<IMatchStatusDal, EfMatchStatusDal>();

builder.Services.AddScoped<ISeasonService, SeasonManager>();
builder.Services.AddScoped<ISeasonDal, EfSeasonDal>();

builder.Services.AddScoped<IStadiumService, StadiumManager>();
builder.Services.AddScoped<IStadiumDal, EfStadiumDal>();

builder.Services.AddScoped<ITeamService, TeamManager>();
builder.Services.AddScoped<ITeamDal, EfTeamDal>();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("FootyCore", opts =>
    {
        opts.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("FootyCore");
app.MapControllers();

app.Run();
