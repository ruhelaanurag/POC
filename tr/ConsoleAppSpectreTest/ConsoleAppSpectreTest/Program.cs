// See https://aka.ms/new-console-template for more information
using Spectre.Console;

Console.WriteLine("Hello, World!");

var project_name = "gtm,cypress_gtm".Split(',');
var users = "jpatel2,rpatel3,selenium".Split(',');
var launch_name = "FTAANALYZER_DailyExecution,FTA-MODERNIZATION_DailyExecution,ILR - FTA".Split(',');

var project = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("What [red]project[/] you want to execute?")
        .PageSize(10)
        //.MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
        .AddChoices(project_name));

var usrs = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("What user you want to filter data for?")
        .PageSize(10)
        //.MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
        .AddChoices(users));

var launchname = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("What [red]launch name[/] you want records for?")
        .PageSize(10)
        //.MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
        .AddChoices(launch_name));


AnsiConsole.MarkupLine($"You selected [green]{project} [/], [blue]{usrs}[/] and [yellow]{launchname}[/].");
// Echo the fruit back to the terminal
//AnsiConsole.WriteLine($"I agree. {fruit} is tasty!");


var panel = new Panel($"Project: {project}\nUser: {usrs}\nLaunch Name: {launchname}");
panel.Border = BoxBorder.Rounded;

panel.Header = new PanelHeader(launchname);
panel.Expand = true;
AnsiConsole.WriteLine("one");
AnsiConsole.WriteLine("two");
AnsiConsole.WriteLine("three");
AnsiConsole.Write(panel);
