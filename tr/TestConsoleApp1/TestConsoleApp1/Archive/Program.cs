// See https://aka.ms/new-console-template for more information
using TestConsoleApp1;
public partial class Program
{
    public static void something()
    {
        Console.WriteLine("Hello, World!");

        SoryArrayByParity soryArrayByParity = new SoryArrayByParity();
        soryArrayByParity.SortByParity(new int[] { 3, 1, 2, 4 });
        soryArrayByParity.SortByParity(new int[] { 0, 1, 2 });
        soryArrayByParity.SortByParity(new int[] { 0 });
    }
}
//ReplaceOnRight replaceOnRight = new ReplaceOnRight();
//replaceOnRight.ReplaceElements(new int[] { 17, 18, 5, 4, 6, 1 });
//replaceOnRight.ReplaceElements(new int[] { 400 });

//Mountain mountain = new Mountain();
//mountain.ValidMountainArray();

//MergeTwoArr mergeTwoArr = new MergeTwoArr();
//mergeTwoArr.MergeTwo();