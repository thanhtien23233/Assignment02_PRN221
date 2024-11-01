using Candidate_Services.CandidateService;
using Candidate_Repositories.CandidateRepo;
using Candidate_Services.JobPostingService;
using Candidate_Repositories.JobPostingRepo;
using Candidate_Services.HRAccountService;
using Candidate_Repositories.HRAccountRepo;
var builder = WebApplication.CreateBuilder(args);

//builder.Services.Use

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<ICandidateRepo, CandidateRepo>();
builder.Services.AddScoped<IJobPostingService, JobPostingService>();
builder.Services.AddScoped<IJobPostingRepo, JobPostingRepo>();
builder.Services.AddScoped<IHRAccountService, HRAccountService>();
builder.Services.AddScoped<IHRAccountRepo, HRAccountRepo>();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();