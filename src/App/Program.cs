using App.Services;
using App.Services.Contracts;
using App.Settings;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.Configure<GmailSettings>(builder.Configuration.GetSection(nameof(GmailSettings)));
builder.Services.Configure<SendinBlueSettings>(builder.Configuration.GetSection(nameof(SendinBlueSettings)));
// builder.Services.Configure<SendGridSettings>(builder.Configuration.GetSection(nameof(SendGridSettings)));

builder.Services.AddSingleton<IHtmlTemplateService, HtmlTemplateService>();

// builder.Services.AddSingleton<IEmailService, GmailService>();
builder.Services.AddSingleton<IEmailService, SendinBlueService>();
// builder.Services.AddSingleton<IEmailService, SendGridService>();

builder.Services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

app.Run();
