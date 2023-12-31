using demo_core;
using demo_model;
using demo_repository;
using demo_service;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBaseService, BaseServiceImpl>();
builder.Services.AddScoped<IReviewPeriodService, ReviewPeriodServiceImpl>();
builder.Services.AddScoped<IReviewPeriodRepo, ReviewPeriodRepoImpl>();
builder.Services.AddScoped<IPathRepo, PathRepoImpl>();
builder.Services.AddScoped<IPathService, PathServiceImpl>();
builder.Services.AddScoped<IStaffRepo, StaffRepoImpl>();
builder.Services.AddScoped<IStaffService, StaffServiceImpl>();
builder.Services.AddScoped<IAllReviewResultUserRepo, AllReviewResultUserRepoImpl>();
builder.Services.AddScoped<IAllReviewResultUserService, AllReviewResultUserServiceImpl>();
builder.Services.AddScoped<ICreterialLevelRepo, CreterialLevelRepoImpl>();
builder.Services.AddScoped<ICreterialLevelService, CreterialLevelServiceImpl>();
builder.Services.AddScoped<IReviewResultDetailRepo, ReviewResultDetailImpl>();
builder.Services.AddScoped<IReviewResultDetailService, ReviewResultDetailServiceImpl>();
builder.Services.AddScoped<IReviewResultRepo, ReviewResultRepoImpl>();
builder.Services.AddScoped<IReviewResultService, ReviewResultServiceImpl>();
builder.Services.AddScoped<ITreeLevelRepo, TreeLevelRepoImpl>();
builder.Services.AddScoped<ITreeLevelService, TreeLevelServiceImpl>();
builder.Services.AddScoped<ICriteriaRepo, CriteriaRepoImpl>();
builder.Services.AddScoped<ICriteria_LevelsService, Criteria_LevelsServiceImpl>();
builder.Services.AddScoped<ILevelRepo, LevelRepoImpl>();
builder.Services.AddScoped<ILevelService, LevelServiceImpl>();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
//Assessor
builder.Services.AddScoped<IAssessorRepo, AssessorRepoImpl>();
builder.Services.AddScoped<IAssessorService, AssessorServiceImpl>();
//Capacity
builder.Services.AddScoped<ICapacityRepo, CapacityRepoImpl>();
builder.Services.AddScoped<ICapacityService, CapacityServiceImpl>();
//CriteriaByCapacity
builder.Services.AddScoped<ICriteriaByCapacityRepo, CriteriaByCapacityRepoImpl>();
builder.Services.AddScoped<ICriteriaByCapacityService, CriteriaByCapacityServiceImpl>();
//Criteria_Detail


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("corsapp");
}
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
