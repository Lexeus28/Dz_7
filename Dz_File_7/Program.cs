using Dz_File_7;
using System;
namespace Pain
{
    class Program
    {
        static void Main()
        {
            Zadacha();
        }
        static void Zadacha()
        {
            Console.WriteLine(@"Написать программу, содержащую решение следующих задач:
            На совещании у начальства раздавали задачи. Сотрудники фирмы так задолбались, что
            решили, что будут получать задачи только в том случае, если это их прямое руководство.
            Все возмущение началось из‐за того, что бухгалтерия решила автоматизировать себе работу,
            они хотят приходить на работу, нажимать на кнопочку и чтобы все само делалось, а отдел
            информационных технологий должен сделать эту задачу им.");
            Employee timur = new Employee("Тимур", "Генеральный директор");

            Employee rashid = new Employee("Рашид", "Финансовый директор", timur);
            Employee ilham = new Employee("Ильхам", "Директор по автоматизации", timur);

            Employee lucas = new Employee("Лукас", "Главный бухгалтер", rashid);

            Employee arkadiy = new Employee("Оркадий", "Начальник инф систем", ilham);
            Employee volodya = new Employee("Володя", "Зам. начальника", ilham);

            Employee ilshat = new Employee("Ильшат", "Главный системщик", arkadiy);
            Employee ivanych = new Employee("Иваныч", "Зам. главного системщика", ilshat);
            Employee ilya = new Employee("Илья", "Системщик", ivanych);
            Employee vitia = new Employee("Витя", "Системщик", ivanych);
            Employee zhenya = new Employee("Женя", "Системщик", ivanych);

            Employee sergey = new Employee("Сергей", "Главный разработчик", arkadiy);
            Employee laisan = new Employee("Ляйсан", "Зам. главного разработчика", sergey);
            Employee marat = new Employee("Марат", "Разработчик", laisan);
            Employee dina = new Employee("Дина", "Разработчик", laisan);
            Employee ildar = new Employee("Ильдар", "Разработчик", laisan);
            Employee anton = new Employee("Антон", "Разработчик", laisan);

            List<Employee> employees = new List<Employee>
            {
                timur, rashid, ilham, lucas,
                arkadiy, volodya,
                ilshat, ivanych, ilya, vitia, zhenya,
                sergey, laisan, marat, dina, ildar, anton
            };
            AssignTask(employees, "Автоматизировать отчеты", timur, rashid);
            AssignTask(employees, "Настроить сеть", volodya, ilya);
            AssignTask(employees, "Написать новый модуль", sergey, marat);
            AssignTask(employees, "Подготовить бюджет", rashid, lucas);
            AssignTask(employees, "Проверить сервер", ilshat, vitia);
        }

        static void AssignTask(List<Employee> employees, string task, Employee from, Employee to)
        {
            Console.WriteLine($"От {from} даётся задача '{task}' сотруднику {to}");

            if (to.AcceptsTaskFrom(from))
            {
                Console.WriteLine($"Задача принята: {to.Name} выполнит '{task}'\n");
            }
            else
            {
                Console.WriteLine($"Задача отклонена: {to.Name} не принимает задачи от {from.Name}\n");
            }
        }
    }
}