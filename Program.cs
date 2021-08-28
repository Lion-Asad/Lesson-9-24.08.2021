using System;

 
namespace фигуры
{
    class Program
    {
       public class CurrencyConverter
    {
        public double USD { get; }
        public double EUR { get; }
        public double RUB { get; }
 
        public CurrencyConverter(double usd, double eur, double rub)
        {
            USD = usd;
            EUR = eur;
            RUB = rub;
        }
 
        public double ConvertToUsd(double value)
        {
            return value / USD;
        }
 
        public double ConvertToEur(double value)
        {
            return value / EUR;
        }
 
        public double ConvertToRub(double value)
        {
            return value / RUB;
        }
 
        public double ConvertFromUsd(double value)
        {
            return USD * value;
        }
 
        public double ConvertFromEur(double value)
        {
            return EUR * value;
        }
 
        public double ConvertFromRub(double value)
        {
            return RUB * value;
        }
    }
    abstract class OperateCost
    {
        public double salary;
        public double tax;

        public abstract void ApplyBonus(double bonus, double grade);
        public abstract void ApplyTax();
    }
    class Slave : OperateCost
    {
        public override void ApplyBonus(double bonus, double grade)
        {
            salary = (1800 + 2 * bonus) * grade;
        }

        public override void ApplyTax()
        {
            tax = salary * 0.14;
        }
    }

    class Warden : OperateCost
    {
        public override void ApplyBonus(double bonus, double grade)
        {
            salary = (1800 + 5 * bonus) * grade;
        }
        public override void ApplyTax()
        {
            tax = salary * 0.14;
        }
    }

    class Lord : OperateCost
    {
        public override void ApplyBonus(double bonus, double grade)
        {
            salary = (1800 + 10 * bonus) * grade;
        }
        public override void ApplyTax()
        {
            tax = salary * 0.14;
        }
    }
    class Employee
    {
        public string name;
        public string surname;
        public static string dateOfHire;
        public OperateCost operationCost;


        public Employee(string name, string surname, string dateOfHire, OperateCost opCost)
        {
            this.name = name;
            this.surname = surname;
            Employee.dateOfHire = dateOfHire;
            this.operationCost = opCost;

        }

        public static double DiscoverGrade(string dateOfHire)
        {
            double dateValueForGrade = (DateTime.Now - DateTime.Parse(dateOfHire)).TotalDays;

            if (dateValueForGrade >= 100 && dateValueForGrade < 365)
                return 1.1;
            else if (dateValueForGrade >= 365)
                return 1.25;
            else
                return 1.5;
        }



    }
    public class Program1
    {
        public static void Main(string[] args)
        {
            var converter = new CurrencyConverter(11.33, 13.30, 0.152);
 
            Console.WriteLine("Виберите конвертацию:");
            Console.WriteLine("1: Конвертация на Сомони");
            Console.WriteLine("2: Конвертация из Сомони");
 
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    ConvertTo(converter);
                    break;
                case 2:
                    ConvertFrom(converter);
                    break;
            }
 
            Console.WriteLine("Конец операции\n \n Заработная плата Эшмата");
            
            Warden oc = new Warden();
            Employee emp = new Employee("Эшмат", "Тошматов", "11.12.2003", oc);
            double grade = Employee.DiscoverGrade("11.12.2003");
            Console.WriteLine("Имя: {0}\nФамилия: {1}\nДата рождения: {2}\n", emp.name, emp.surname, Employee.dateOfHire);
            oc.ApplyBonus(400, grade);
            oc.ApplyTax();
            Console.WriteLine("Зарплата: {0}\nНалог: {1}", emp.operationCost.salary, emp.operationCost.tax);
            Console.ReadKey();
        }
 
        private static void ConvertTo(CurrencyConverter currencyConverter)
        {
            Console.WriteLine("Виберите валюту:");
            Console.WriteLine("1: Конвертация в USD");
            Console.WriteLine("2: Конвертация в EUR");
            Console.WriteLine("3: Конвертация в RUB");
 
            var option = int.Parse(Console.ReadLine());
 
            Console.WriteLine("Введите сумму");
 
            var input = double.Parse(Console.ReadLine());
 
            switch (option)
            {
                case 1:
                    Console.WriteLine(currencyConverter.ConvertFromUsd(input));
                    break;
                case 2:
                    Console.WriteLine(currencyConverter.ConvertFromEur(input));
                    break;
                case 3:
                    Console.WriteLine(currencyConverter.ConvertFromRub(input));
                    break;
            }
        }
 
        private static void ConvertFrom(CurrencyConverter currencyConverter)
        {
            Console.WriteLine("Виберити валюту:");
            Console.WriteLine("1: Конвертация из USD");
            Console.WriteLine("2: Конвертация из EUR");
            Console.WriteLine("3: Конвертация из RUB");
 
            var option = int.Parse(Console.ReadLine());
 
            Console.WriteLine("Введите сумму");
 
            var input = double.Parse(Console.ReadLine());
 
            switch (option)
            {
                case 1:
                    Console.WriteLine(currencyConverter.ConvertToUsd(input));
                    break;
                case 2:
                    Console.WriteLine(currencyConverter.ConvertToEur(input));
                    break;
                case 3:
                    Console.WriteLine(currencyConverter.ConvertToRub(input));
                    break;
            }
        }
    }
    }
}
