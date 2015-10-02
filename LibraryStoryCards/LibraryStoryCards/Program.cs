using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStoryCards
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Todo Needs demo data 
            Library library = new Library();

            var booksInventory = library.BooksInventory;
            Console.WriteLine("Would you like an inventory ordered by Author or by Title?");
            var userInput = readValue();

            if (userInput == 1)
            {
                library.GetBookReport(booksInventory, true);
            }
            else
            {
                library.GetBookReport(booksInventory, false);
            }
        }

        public static int readValue()
        {
            int result = 0;
            do
            {
                string resultString = Console.ReadLine();
                result = int.Parse(resultString); 

            } while ((result != 1) && (result != 2));
            return result;
        }    
    }
}
