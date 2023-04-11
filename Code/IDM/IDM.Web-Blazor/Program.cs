using IDM.Business.Contractors;
using IDM.Domain.Services;
using IDM.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<IDMDbContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("PROD_SQL_CON")));

builder.Services.AddScoped<ISecurityGroupService, SecurityGroupService>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
