using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStoryCards
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Library library = new Library();

            var booksInventory = library.BooksInventory;
            Console.WriteLine("Would you like a book inventory ordered by Author or by Title?");
            Console.WriteLine("Enter {0} to order by Author or {1} to order by Title:", 1, 2);
            double result = 0;
            do
            {
                Console.WriteLine("Enter {0} to order by Author or {1} to order by Title:", 1, 2);
                string userInputString = Console.ReadLine();
            } while ((result != 1) || (result != 2));
             if (result == 1)
                {
                    library.GetBookReport(booksInventory, 1);
                }
             library.GetBookReport(booksInventory, 2);
        }
    }
}
