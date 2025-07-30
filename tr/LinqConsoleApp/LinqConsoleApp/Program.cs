// See https://aka.ms/new-console-template for more information
using LinqConsoleApp.MSDN;

Console.WriteLine("Hello, World!");


//InnerJoin ij = new InnerJoin();
//ij.JoinvsGroupJoin();

{
    LeftOuterJoin loj = new LeftOuterJoin();
    loj.LeftOuterJoin_MethodSyntax();
}

{
    ProjectionOperation project = new ProjectionOperation();
    project.Select_MethodSyntax();
    project.SelectMany_MethodSyntax();
    project.Zip_MethodSyntax();
    project.SelectVsSelectMany();
}