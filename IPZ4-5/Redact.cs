using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPZ4_5
{
    internal class Redact
    {
        public static void RedactOne(in List<Item> items, in Redactor redactor, in Book book)
        {
                if (!book.IsRedacted)
                {
                    redactor.BookToRedact = book;
                    redactor.DoChanges();
                    var shelf = (BookShelf)items.Where(x => x.Type == "Полиця").First();
                    shelf.Books.Add(book);
                    Console.WriteLine("Тепер втома редактора: " + redactor.WearAmount + "%");
                }
        }
        public static void RedactAll(in List<Item> items, in Redactor redactor, in BookShelf currShelf, Window window)
        {
            var books = items.Where(x => x.Type == "Книга");
            if (books.Count() > 5)
            {
                redactor.WindowSwitch(window);
            }
            foreach (Book toRedact in books)
            {
                if (!toRedact.IsRedacted)
                {
                    redactor.BookToRedact = toRedact;
                    redactor.DoChanges();
                    currShelf.Books.Add(toRedact);
                    Console.WriteLine("Тепер втома редактора: " + redactor.WearAmount + "%");
                }
            }
        }
    }
}
