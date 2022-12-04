using System;
using System.Collections.Generic;
using System.Linq;

namespace IPZ4_5
{
    public class Foundation : Item, IMaterial
    {
        public override string Type { get; } = "Фундамент";

        public string MaterialType { get; set; }

        public override void DoChanges()
        {
            Console.WriteLine("Неможливо використати фундамент");
            this.WearIt();
        }
        public Foundation(string wearType, int wearAmount, string materialType) : base(wearType, wearAmount)
        {
            MaterialType = materialType;
        }
    }

    public class Window : Item, IMaterial
    {
        public override string Type { get; } = "Вікно";

        public string MaterialType { get; set; }

        internal string CoverColor { get; set; }

        internal bool IsOpened { get; set; }
        public override void DoChanges()
        {
            if (IsOpened) { Console.WriteLine("Ви закрили вікно"); IsOpened = false; }
            else
            {
                Console.WriteLine("Ви відкрили вікно"); IsOpened = true;
            }
            this.WearIt();
        }
        public Window(string wearType, int wearAmount, string materialType, string coverColor) : base(wearType, wearAmount)
        {
            MaterialType = materialType;
            CoverColor = coverColor;
        }
    }

    public class Book : Item
    {
        public override string Type { get; } = "Книга";
        internal string Name { get; set; }
        internal bool IsRedacted { get; set; }
        public override void DoChanges()
        {
            Console.WriteLine($"Ви прочитали книгу {Name}");
            this.WearIt();
        }
        public void Redact()
        {
            IsRedacted = true;
        }
        public Book(string wearType, int wearAmount, string name) : base(wearType, wearAmount)
        {
            Name = name;
        }
    }

    public class Redactor : Item
    {
        public override string Type { get; } = "Редактор";

        internal Book BookToRedact { get; set; }

        internal Computer PC { get; set; }

        public override void DoChanges()
        {
            PC.Redact(BookToRedact);
            Console.WriteLine($"{BookToRedact.Name} відредаговано.");
            this.WearIt();
        }
        public void WindowSwitch(Window window)
        {
            if (window.IsOpened)
            {
                window.DoChanges();
            }
        }
        public Redactor(string wearType, int wearAmount, Book book, ref Computer pc) : base(wearType, wearAmount)
        {
            BookToRedact = book;
            PC = pc;
        }
    }
    public class BookShelf : Item
    {
        public override string Type { get; } = "Полиця";
        internal List<Book> Books;
        public override void DoChanges()
        {
            Console.WriteLine($"На полиці міститься {Books.Count()} книг");
            this.WearIt();
        }
        public BookShelf(string wearType, int wearAmount, List<Book> books) : base(wearType, wearAmount)
        {
            Books = books;
        }
    }
    public class Keyboard : Item
    {
        public override string Type { get; } = "Клавіатура";
        internal uint KeysCount { get; set; }
        internal bool IsMechanical { get; set; }
        internal string Result { get; set; }
        public override void DoChanges()
        {
            Console.Write("Введіть текст: ");
            Result = Console.ReadLine();
            if (Result.Length >= 20)
            {
                var wearAmount = Result.Length / 20;
                for (int i =0; i < wearAmount; i++)
                {
                    this.WearIt();
                }
            }
        }
        public Keyboard(string wearType, int wearAmount, uint keysCount, bool isMechanical) : base(wearType, wearAmount)
        {
            KeysCount = keysCount;
            IsMechanical = isMechanical;
        }
    }
    public class Computer : Item
    {
        public override string Type { get; } = "Комп'ютер";
        internal string CPU { get; set; }
        internal Keyboard KBoard { get; set; }
        public override void DoChanges()
        {
            Console.WriteLine($"Current CPU: {CPU}");
            Console.WriteLine($"Keyboard is mechanical: {KBoard.IsMechanical}");
            Console.WriteLine($"Keys count: {KBoard.KeysCount}");
            KBoard.DoChanges();
            Console.WriteLine("Ваш текст: " + KBoard.Result);
            this.WearIt();
        }
        public void Redact(Book book)
        {
            KBoard.WearIt();
            this.WearIt();
            book.Redact();
        }
        public Computer(string wearType, int wearAmount, string cpuName, Keyboard kBoard) : base(wearType, wearAmount)
        {
            CPU = cpuName;
            KBoard = kBoard;
        }
    }
}
