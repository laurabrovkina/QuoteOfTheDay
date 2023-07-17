using GraphQL.Server;
using Microsoft.EntityFrameworkCore;
using QuoteOfTheDay.Data;
using QuoteOfTheDay.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContextPool<QuoteOfTheDayDbContext>(o => o.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=QuoteOfTheDay;Trusted_Connection=True;"));
builder.Services.AddScoped<QuoteRepository>();

builder.Services.AddScoped<QuoteOfTheDaySchema>()
                .AddScoped<QuoteMutation>()
                .AddScoped<QuoteQuery>()
                .AddGraphQL(options => options.EnableMetrics = false)
                .AddSystemTextJson()
                .AddGraphTypes(typeof(QuoteOfTheDaySchema));
                
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseGraphQL<QuoteOfTheDaySchema>();
app.UseGraphQLPlayground();

app.UseRouting();

app.Run();
