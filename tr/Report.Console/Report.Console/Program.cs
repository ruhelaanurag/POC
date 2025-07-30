using Report.Infra;
using Report.Models;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Transactions;


// See https://aka.ms/new-console-template for more information
//https://spectreconsole.net/quick-start

Console.WriteLine("Hello, World!");
File.WriteAllText($"result_firstlog.txt", "random sample text");

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

Launch launch = new Launch();
Item item = new Item();
Log log = new Log();
List<LogItemModel> logItems = new List<LogItemModel>();

//Environment.Exit(0);

//Console.WriteLine("Enter the product name to search: ");
//string productName = Console.ReadLine();
//Console.WriteLine("Enter the owner name to search: ");
//string ownerName = Console.ReadLine();
//Console.WriteLine("Enter the date to search (yyyy-MM-dd): ");
//string dateInput = Console.ReadLine();
//DateTime dt = DateTime.Parse(dateInput);

//var result = DateTime.TryParse("2025-07-01", out DateTime dt);
//while (!result)
//{
//    Console.WriteLine("Invalid date format. Please enter a valid date (yyyy-MM-dd): ");
//    string dateInput = Console.ReadLine();
//    result = DateTime.TryParse(dateInput, out dt);
//}

string productName = "cypress_gtm";
string ownerName = "selenium";
DateTime dt = DateTime.Parse("2025-07-15");

var result = await launch.GetLaunches(productName, dt);
var launchResult = result.content.Where(c => c.name.Contains("FTAANALYZER_DailyExecution", StringComparison.OrdinalIgnoreCase) &&
                c.owner.Contains(ownerName, StringComparison.OrdinalIgnoreCase))
    .ToList();
foreach (var resultcontent in launchResult)
{
    var items = await item.GetItems(productName, resultcontent.id, resultcontent.statistics.executions.failed);
    var logs = await log.GetLogs(productName, resultcontent.id, resultcontent.statistics.executions.failed);
    foreach (var logitem in logs.content)
    {
        logItems.Add(new LogItemModel(logitem, items.content.Where(x => x.id == logitem.itemId).FirstOrDefault()));
    }
}

//ItemModel items = null;
//LogModel logs = null;
//await Parallel.ForEachAsync(launchResult, default(CancellationToken), async (x, y) =>
//{
//    items = await item.GetItems(x.id, x.statistics.executions.failed);
//    logs = await log.GetLogs(x.id, x.statistics.executions.failed);
//});

//foreach (var logitem in logs.content)
//{
//    logItems.Add(new LogItemModel(logitem, items.content.Where(x => x.id == logitem.itemId).FirstOrDefault()));
//}
Console.WriteLine(stopwatch.ElapsedMilliseconds);
var groupedLogs = logItems.GroupBy(x => new { x.itemName })
    .Select(g => g);

var firstLog = groupedLogs.Select(x=>x.OrderByDescending(y => y.time).FirstOrDefault()).ToList();
File.WriteAllText($"C:\\Users\\c279553\\Downloads\\result_firstlog.json", JsonSerializer.Serialize(firstLog));
File.WriteAllText($"C:\\Users\\c279553\\Downloads\\result.json", JsonSerializer.Serialize(logItems));
Console.WriteLine(stopwatch.ElapsedMilliseconds);

//Parallel.ForEachAsync(launchResult, default(CancellationToken), async (x, y) =>
//{
//    await item.GetItems(x.id, x.statistics.executions.failed);

//});
//Task.WhenAll(launchResult.Select(c => item.GetItems(c.id, c.statistics.executions.failed)));

launchResult.ForEach(c =>
    {
        Console.WriteLine($"Product: {c.name}, Owner: {c.owner}, Status: {c.status}");
        Console.WriteLine($"Start Time: {DateTimeOffset.FromUnixTimeMilliseconds(c.startTime).DateTime}");
        Console.WriteLine($"End Time: {DateTimeOffset.FromUnixTimeMilliseconds(c.endTime).DateTime}");
        Console.WriteLine($"Executions - Total: {c.statistics.executions.total}, Passed: {c.statistics.executions.passed}, Failed: {c.statistics.executions.failed}");
        Console.WriteLine($"Launch Id: {c.id}");
        Console.WriteLine();
    });


stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);