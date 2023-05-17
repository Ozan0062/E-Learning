using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Configuration
var configuration = new ConfigurationBuilder()
	.SetBasePath(builder.Environment.ContentRootPath)
	.AddJsonFile("appsettings.json")
	.Build();

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
	// Add authorization options
	//options.Conventions.AuthorizeFolder("/Products");
	//options.Conventions.AuthorizeFolder("/Orders");
	//options.Conventions.AuthorizeFolder("/Customers");
});

// Add data services
builder.Services.AddSingleton<IUserDataService, EFCUserDataService>();

builder.Services.AddSingleton<ICourseDataService, EFCCourseDataService>();
builder.Services.AddSingleton<IAdminDataService, EFCAdminDataService>();
builder.Services.AddSingleton<IInstructorDataService, EFCInstructorDataService>();
builder.Services.AddSingleton<IEducationDataService, EFCEducationDataService>();
builder.Services.AddSingleton<IExerciseDataService, EFCExerciseDataService>();
builder.Services.AddSingleton<IFavoriteDataService, EFCFavoriteDataService>();

// Add DbContext
builder.Services.AddDbContext<ELearningDBContext>(options =>
{
	options.UseSqlServer(configuration.GetConnectionString("UserDB"));
});

// Add cookie-based Authentication
builder.Services.Configure<CookiePolicyOptions>(options =>
{
	options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
	options.LoginPath = "/LogIn/LogInPage";
	options.LoginPath = "/LogIn/AdminLogIn";
	options.LoginPath = "/LogIn/InstructoLogIn";
	options.LoginPath = "/Register/RegisterPage";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); // Enables cookie-based Authentication
app.UseAuthorization();

app.MapRazorPages();

app.Run();
