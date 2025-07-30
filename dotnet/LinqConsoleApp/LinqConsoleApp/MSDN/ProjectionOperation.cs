using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsoleApp.MSDN
{
    public class ProjectionOperation
    {
        List<string> phrases = ["an apple a day", "the quick brown fox"];
        List<string> words = ["an", "apple", "a", "day"];
        IEnumerable<int> numbers = [1, 2, 3, 4, 5, 6, 7];
        IEnumerable<char> letters = ['A', 'B', 'C', 'D', 'E', 'F'];


        public void Select_MethodSyntax()
        {
            //Projects values that are based on a transform function.	

            var query = words.Select(word => word.Substring(0, 1)); //Selects the first letter of each word

            foreach (string s in query)
            {
                Console.WriteLine(s);
            }

        }

        public void SelectMany_MethodSyntax()
        {
            //Projects sequences of values that are based on a transform function and then flattens them into one sequence.	

            //Example 1
            //List<string> phrases = ["an apple a day", "the quick brown fox"];
            var query = phrases.SelectMany(phrases => phrases.Split(' '));

            foreach (string s in query)
            {
                Console.WriteLine(s);
            }

            //Example 2

            var method = numbers.SelectMany(number => letters, (number, letter) => (number, letter));

            foreach (var item in method)
            {
                Console.WriteLine(item);
            }
        }

        public void SelectVsSelectMany()
        {

            List<Bouquet> bouquets =
            [
                new Bouquet { Flowers = ["sunflower", "daisy", "daffodil", "larkspur"] },
                new Bouquet { Flowers = ["tulip", "rose", "orchid"] },
                new Bouquet { Flowers = ["gladiolis", "lily", "snapdragon", "aster", "protea"] },
                new Bouquet { Flowers = ["larkspur", "lilac", "iris", "dahlia"] }
            ];

            IEnumerable<List<string>> query1 = bouquets.Select(bq => bq.Flowers);

            IEnumerable<string> query2 = bouquets.SelectMany(bq => bq.Flowers);

            Console.WriteLine("Results by using Select():");
            // Note the extra foreach loop here.
            foreach (IEnumerable<string> collection in query1)
            {
                foreach (string item in collection)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("\nResults by using SelectMany():");
            foreach (string item in query2)
            {
                Console.WriteLine(item);
            }
        }

        public void Zip_MethodSyntax()
        {
            //Produces a sequence of tuples with elements from 2-3 specified sequences.	
            //The resulting sequence from a zip operation is never longer in length than the shortest sequence.

            var zipped = numbers.Zip(letters);

            foreach ((int number, char letter) in zipped)
            {
                Console.WriteLine($"Number: {number} zipped with letter: '{letter}'");
            }

            //     Number: 1 zipped with letter: 'A'
            //     Number: 2 zipped with letter: 'B'
            //     Number: 3 zipped with letter: 'C'
            //     Number: 4 zipped with letter: 'D'
            //     Number: 5 zipped with letter: 'E'
            //     Number: 6 zipped with letter: 'F'


            var zippedMulti = numbers.Zip(letters, words);
            foreach ((int number, char letter, string words) in zippedMulti)
            {
                Console.WriteLine($"Number: {number} zipped with letter: '{letter}'");
            }
        }

        public void Select_QuerySyntax()
        {

            var query = from word in words
                        select word.Substring(0, 1);

            foreach (string s in query)
            {
                Console.WriteLine(s);
            }
        }

        public void SelectMany_QuerySyntax() 
        {
            var query = from phrase in phrases
                        from word in phrase.Split(' ')
                        select word;

            foreach (string s in query)
            {
                Console.WriteLine(s);
            }
        }
    }

    class Bouquet
    {
        public required List<string> Flowers { get; init; }
    }
}
