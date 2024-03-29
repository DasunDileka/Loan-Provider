using DataLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ContactsAPIDbContext>(option =>
option.UseSqlServer("Data Source=AD-044\\SQLEXPRESS;Initial Catalog=LoanProvider;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true;"));;
/*builder.Services.AddDbContext<ContactsAPIDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("ContactAPIConnectionString")));*/
/*builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader();
    });
});*/

builder.Services.AddCors(opt => {
    opt.AddPolicy(name:"AllowOrigin", builder => {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
