using Delsoft.Calendars;
using Delsoft.Calendars.Belgian;
using Delsoft.Calendars.Belgian.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(BelgianCalendarController).Assembly)
    .Services.AddScoped<ICalendarFactory<IBelgianCalendar>, CalendarFactory<IBelgianCalendar>>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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