using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

services.AddControllers();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

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



//// Create a new user with an empty wallet
//User user = new User();

//// Increase cash balance by 100
//user.Wallet.IncreaseCash(100);

//// Increase non-cash balance by 50 with a source
//user.Wallet.IncreaseNonCash(50, "Gift Code");

//// Decrease cash balance by 30
//user.Wallet.DecreaseCash(30);

//// Increase cash balance from a return by 20
//user.Wallet.IncreaseCashFromReturn(20);

//foreach (var transaction in user.Wallet.Transactions)
//{
//    Console.WriteLine($"Type: {transaction.Type}, Date: {transaction.Date}, Amount: {transaction.Amount}, GiftCode: {transaction.GiftCode}");
//}