using System;
using System.Linq;
using MoreLinq;
using System.Collections.Generic;

namespace HarryPotterKata
{
    public class MainClass
    {
        public static void Main()
        {

            Console.WriteLine("How many of each Harry Potter book does the customer have?");

            Basket basket = new Basket();
            List<Book> books = new List<Book>();
            basket.BooksInBasket = books;

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Copies of Book" + i + "?");
                string userInput = Console.ReadLine();
                int NumberOfBook = int.Parse(userInput);

                if (NumberOfBook != 0)
                {

                    for (int j = 1; j <= NumberOfBook; j++)
                    {
                        Book book = new Book();
                        book.BookId = i;
                        basket.BooksInBasket.Add(book);
                    }
                }


            }
            var booksCount = basket.BooksInBasket.Count();
            var costBeforeDiscounts = booksCount*8;
            int finalPrice;
            Console.WriteLine("There are " + booksCount + " books in the basket...");
            Console.ReadLine();
            var distinctBooks = GetNumberOfDistinctBooks(basket.BooksInBasket);
            Console.WriteLine(distinctBooks + " distinct books");


            if (distinctBooks < 2)
            {
                finalPrice = costBeforeDiscounts;
                Console.WriteLine("Final price is " + finalPrice);
            }
            else
            {
                switch (distinctBooks)
                {
                    case 2:
                        double discount = (distinctBooks * 8)*0.95;
                        break;
                }
            }

            Console.ReadLine();
        }


        public static List<Book> ApplyBestDiscountToBooks(List<Book> booksInBasket)
        {
            var distinctBooks = GetNumberOfDistinctBooks(booksInBasket);

        }

        public static List<Book> ApplyDiscountToLargestDistinctSet(List<Book> booksInBasket)
        {
            var distinctBooks = GetNumberOfDistinctBooks(booksInBasket);
            switch (distinctBooks)
            {
                case 5:
                   //For each distinct book update discount and apply to price
            }
        }

        public static int GetNumberOfDistinctBooks(List<Book> booksInBasket)
        {
            return (booksInBasket.DistinctBy(i => i.BookId)).Count();
        }

        public class Basket
        {
            public List<Book> BooksInBasket { get; set; }
        }

        
    }
}

