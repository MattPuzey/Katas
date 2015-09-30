using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStoryCards
{
    class Library
    {
        public ICollection<Book> BooksInventory;

        public void GetBookReport(ICollection<Book> inventory, int userInput)
        {
            IOrderedEnumerable<Book> orderedBookInventory;

            if (userInput == 1)
            {
                 orderedBookInventory = OrderBooksbyAuthor(inventory);
            }
            else if (userInput == 2)
            {
                orderedBookInventory = OrderBooksbyTitle(inventory);
            }

            var distinctBookInventory = orderedBookInventory.GroupBy(x => x.Title).Select(y => y.First());
            var duplicates = distinctBookInventory.Where(p => orderedBookInventory.All(p2 => p2.Title != p.Title));
            int titlesCount = distinctBookInventory.Count();
            int duplicatesCount = duplicates.Count();
            Console.WriteLine("Inventory report");
            foreach (Book book in distinctBookInventory)
            {
                var author = book.AuthorName;
                var bookTitle = book.Title;
                Console.WriteLine(bookTitle + " by " + author);
            }

            Console.WriteLine("There are " + titlesCount + " unique titles in the inventory");
            Console.WriteLine("There are also " + duplicatesCount + " duplicates in the inventory.");
        }

        private IOrderedEnumerable<Book> OrderBooksbyTitle(ICollection<Book> inventory)
        {
            var orderedBookInventory = inventory.OrderBy(x => x.Title);
            return orderedBookInventory;
        }

        private IOrderedEnumerable<Book> OrderBooksbyAuthor(ICollection<Book> inventory)
        {
            var orderedBookInventory = inventory.OrderBy(x => x.AuthorName);
            return orderedBookInventory;
        }

        public IOrderedEnumerable<Book> SearchforBookByAuthor(string authorName)
        {
            return NotImplementedException;
        }
    }
}
