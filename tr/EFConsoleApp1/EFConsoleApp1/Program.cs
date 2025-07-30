// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();

var batchSize = config["AutoNumberOptions:BatchSize"];

Console.WriteLine("Hello, World!");
