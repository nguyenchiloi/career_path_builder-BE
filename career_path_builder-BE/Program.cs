using demo_core;
using demo_repository;
using demo_service;

var builder = WebApplication.CreateBuilder(args);

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
