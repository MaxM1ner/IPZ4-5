using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace IPZ4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();
            items.Add(new Foundation("Зсув", 3, "Бетонований піщаник"));
            items.Add(new Window("Подряпини", 4, "Скло", "Світло-коричневий"));

            items.Add(new Keyboard("Стирання фарби з клавіш", 3, 104, true));
            items.Add(new Computer("Запиленість", 10, "AMD Ryzen 7 3700X", (Keyboard)items.Where(x => x.Type == "Клавіатура").First()));

            var computers = (IEnumerable<Computer>)items.Where(x => x.Type == "Комп'ютер");
            Computer computer = computers.First();
            foreach(var pc in computers)
            {
                if (pc.WearAmount < computer.WearAmount)
                {
                    computer = pc;
                }
            }

            Console.WriteLine("PC dustiness: " + computer.WearAmount);
            computer.DoChanges();

            List<Book> booksList = new List<Book>();
            items.Add(new BookShelf("Заповненість", 20, booksList));

            var testbook = new Book("Вицвітання фарби", 5, "C# in Depth");
            items.Add(testbook);
            items.Add(new Book("Вицвітання фарби", 0, "50 shadows of grey"));
            Book listBook = items.Where(x => x.Type == "Книга").First() as Book;

            items.Add(new Redactor("Втома", 20, listBook, ref computer));
            Redactor redactor = items.Where(x => x.Type == "Редактор").First() as Redactor;
            BookShelf currShelf = items.Where(x => x.Type == "Полиця").First() as BookShelf;

            Redact.RedactOne(in items, in redactor, in testbook);

            Window window = (Window)items.Where(x => x.Type == "Вікно").First();
            Redact.RedactAll(in items, in redactor, in currShelf, window);

            items.Add(new Book("Вицвітання фарби", 3, "Біблія"));
            items.Add(new Book("Вицвітання фарби", 2, "Windows 11 Manual"));
            Redact.RedactAll(in items, in redactor, in currShelf, window);
        }


    }
}
