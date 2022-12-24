using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._6_HomeWork
{
    class Program
    {
        static void getInfo()
        {
            using (StreamReader get = new StreamReader("Справочник.txt", Encoding.UTF8))
            {
                string line;
                while ((line = get.ReadLine()) != null)
                {
                    string[] data = line.Split('#');
                    Console.WriteLine($"{data[0]} {data[1]} {data[2]} {data[3]} {data[4]} {data[5]} {data[6]}");
                }
            }
        }

        static void putInfo()
        {
            using (StreamWriter put = new StreamWriter("Справочник.txt", true, Encoding.UTF8))
            {
                char key = 'д';
                do
                {
                    string line = string.Empty;
                    Console.Write("\nВведите ID сотрудника: ");
                    line += $"{Console.ReadLine()}#";

                    string nowDate = DateTime.Now.ToShortDateString();
                    string nowTime = DateTime.Now.ToShortTimeString();
                    Console.WriteLine($"Дата и время добавления записи: {nowDate} {nowTime}");
                    line += $"{nowDate} ";
                    line += $"{nowTime}#";

                    Console.Write("\nВведите Ф.И.О. сотрудника: ");
                    line += $"{Console.ReadLine()}#";

                    Console.Write("\nВведите дату рождения сотрудника: ");
                    string dateBirth = Console.ReadLine();
                    line += $"{dateBirth}#";

                    int yearBirth = Convert.ToInt32(dateBirth.Substring(6));
                    int nowYear = Convert.ToInt32(nowDate.Substring(6));
                    int age = nowYear - yearBirth;
                    string ageTaken = Convert.ToString(age);
                    Console.WriteLine($"Возраст сотрудника: {ageTaken}");
                    line += $"{ageTaken}#";

                    Console.Write("\nВведите рост сотрудника: ");
                    line += $"{Console.ReadLine()}#";

                    Console.Write("\nВведите место рождения сотрудника: ");
                    line += $"{Console.ReadLine()}";

                    put.WriteLine(line);

                    Console.Write("Продожить (н/д): ");
                    key = Console.ReadKey(true).KeyChar;
                } while (char.ToLower(key) == 'д');
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите '1', чтобы вывести данные о сотрудниках на экран\n" +
                          "Введите '2', чтобы внести данные о новых сотрудниках в Справочник: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    getInfo();
                    break;
                case "2":
                    putInfo();
                    break;
                default:
                    Console.Write("Вы ввели не '1' и не '2'");
                    break;
            }

            Console.ReadLine();
        }
    }
}
