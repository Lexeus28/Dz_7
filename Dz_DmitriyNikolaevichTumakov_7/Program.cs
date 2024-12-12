using Dz_DmitriyNikolaevichTumakov_7;
using System;
namespace Tumakov
{
    class Program
    {
        static void Main()
        {
            Upr_8_1();
            Upr_8_2();
            Upr_8_3();
            Upr_8_4();
            Dz_8_1();
            Dz_8_2();
        }
        static void Upr_8_1()
        {
            Console.WriteLine(@"Упражнение 8.1 В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить
            метод, который переводит деньги с одного счета на другой. У метода два параметра: ссылка
            на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.");
            Bank_account account = new Bank_account();
            Bank_account account2 = new Bank_account();
            account.NumInput(account.UniqueNum());
            account.BalInput("56789");
            account.TypeInput("сберегательный");
            account2.NumInput(account.UniqueNum());
            account2.BalInput("5678");
            account2.TypeInput("текущий");
            bool flag = true;
            decimal res;
            while (flag)
            {
                Console.WriteLine("\nВыберите операцию:\n1.Пополнить\n2.Снять\n3.Отобразить счёт\n4.Перевести деньги\n");
                switch (Console.ReadLine())
                {
                    case "1": account.Deposit(); account.Print(); break;
                    case "2": account.Withdraw(); account.Print(); break;
                    case "3": account.Print(); break;
                    case "4":
                        Console.WriteLine("Введите сумму, которую хотите перевести.\n");
                        while (!decimal.TryParse(Console.ReadLine(), out res))
                        {
                            Console.WriteLine("\nНеверный формат данных. Повторите попытку\n");
                        }
                        account.Transfer(account2, res);
                        break;
                    default: flag = false; break;
                }
            }
        }
        static void Upr_8_2()
        {
            Console.WriteLine(@"Упражнение 8.2 Реализовать метод, который в качестве входного параметра принимает
            строку string, возвращает строку типа string, буквы в которой идут в обратном порядке.
            Протестировать метод.");
            Console.WriteLine("\nВведите строку");
            Console.WriteLine(ReverseString(Console.ReadLine()!));
        }
        static string ReverseString(string inputString)
        {
            char[] charArray = inputString.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        static void Upr_8_3()
        {
            Console.WriteLine(@"Упражнение 8.3 Написать программу, которая спрашивает у пользователя имя файла. Если
            такого файла не существует, то программа выдает пользователю сообщение и заканчивает
            работу, иначе в выходной файл записывается содержимое исходного файла, но заглавными
            буквами.");
            Console.Write("\nВведите имя исходного файла: ");
            string inputFileName = Console.ReadLine();

            if (!File.Exists(inputFileName))
            {
                Console.WriteLine($"Файл '{inputFileName}' не существует.");
                return;
            }
            Console.WriteLine("Введите имя выходного файла: ");
            string outputFileName = Console.ReadLine();

            try
            {
                string content = File.ReadAllText(inputFileName);
                File.WriteAllText(outputFileName, content.ToUpper());
                Console.WriteLine($"\nСодержимое файла '{inputFileName}' успешно записано в '{outputFileName}' заглавными буквами.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПроизошла ошибка: {ex.Message}");
            }
        }
        static void Upr_8_4()
        {
            Console.WriteLine(@"Упражнение 8.4 Реализовать метод, который проверяет реализует ли входной параметр
            метода интерфейс System.IFormattable. Использовать оператор is и as. (Интерфейс
            IFormattable обеспечивает функциональные возможности форматирования значения объекта
            в строковое представление.)");
            CheckIfFormattable(123);
            CheckIfFormattable("Hello");
            CheckIfFormattable(DateTime.Now);
            CheckIfFormattable(new object());
        }
        static void CheckIfFormattable(object input)
        {
            if (input is IFormattable)
            {
                Console.WriteLine($"\n{input} реализует интерфейс IFormattable.");
            }
            else
            {
                Console.WriteLine($"\n{input} не реализует интерфейс IFormattable.");
            }
            var formattable = input as IFormattable;
            if (formattable != null)
            {
                Console.WriteLine($"\n{input} также удалось преобразовать с помощью оператора 'as'.");
            }
            else
            {
                Console.WriteLine($"\n{input} не удалось преобразовать с помощью оператора 'as'.");
            }
        }
        static void Dz_8_1()
        {
            Console.WriteLine(@"Домашнее задание 8.1 Работа со строками. Дан текстовый файл, содержащий ФИО и e-mail
            адрес. Разделителем между ФИО и адресом электронной почты является символ #:
            Иванов Иван Иванович # iviviv@mail.ru
            Петров Петр Петрович # petr@mail.ru
            Сформировать новый файл, содержащий список адресов электронной почты.
            Предусмотреть метод, выделяющий из строки адрес почты. Методу в
            качестве параметра передается символьная строка s, e-mail возвращается в той же строке s:
            public void SearchMail (ref string s).");
            string inputFilePath = "Dz_8_1.txt";
            string outputFilePath = "emails.txt";

            try
            {
                string[] lines = File.ReadAllLines(inputFilePath);
                string[] emails = new string[lines.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    SearchMail(ref line);
                    emails[i] = line;
                }
                File.WriteAllLines(outputFilePath, emails);

                Console.WriteLine("\nФайл с адресами электронной почты успешно создан: " + outputFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nОшибка: " + ex.Message);
            }
        }
        public static void SearchMail(ref string s)
        {
            string[] parts = s.Split('#');
            if (parts.Length == 2)
            {
                s = parts[1].Trim();
            }
            else
            {
                s = string.Empty;
            }
        }
        public static void Dz_8_2()
        {
            Console.WriteLine(@"Домашнее задание 8.2 Список песен. В методе Main создать список из четырех песен. В
            цикле вывести информацию о каждой песне. Сравнить между собой первую и вторую
            песню в списке. Песня представляет собой класс с методами для заполнения каждого из
            полей, методом вывода данных о песне на печать, методом, который сравнивает между
            собой два объекта:");
            List<Song> songs = new List<Song>
            {
            new Song(),
            new Song(),
            new Song(),
            new Song()
            };
            songs[0].GetName("Рюмка водки на столе");
            songs[0].GetAuthor("Григорий Лепс");

            songs[1].GetName("Лирика");
            songs[1].GetAuthor("Сектор Газа");

            songs[2].GetName("Кукушка");
            songs[2].GetAuthor("КИНО");

            songs[3].GetName("Сenturies");
            songs[3].GetAuthor("Fall out boy");
            for (int i = 1; i < songs.Count; i++)
            {
                songs[i].GetPrev(songs[i - 1]);
            }
            Console.WriteLine("\nСписок песен:");
            foreach (var song in songs)
            {
                Console.WriteLine(song.Title());
            }
            Console.WriteLine("\nСравнение первой и второй песни:");
            if (songs[0].Equals(songs[1]))
            {
                Console.WriteLine("Первая и вторая песни одинаковы.");
            }
            else
            {
                Console.WriteLine("Первая и вторая песни разные.");
            }
        }
    }
}