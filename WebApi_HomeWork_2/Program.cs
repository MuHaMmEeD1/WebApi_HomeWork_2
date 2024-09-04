using WebApi_HomeWork_2.Formatters.Inputs;
using WebApi_HomeWork_2.Formatters.Outputs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options=>
{

    options.OutputFormatters.Insert(0, new TextCsvOutputFormatter());
    options.InputFormatters.Insert(0, new TextCsvInputFormatter());

}
);



builder.Services.AddControllers();
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
