using System;
class Person
    {
        private string name;
        private DateTime birthYear;

        public string Name => name;
        public DateTime BirthYear => birthYear;

        public Person()
        {
            name = "Невідомо";
            birthYear = DateTime.Now;
        }

        public Person(string name, DateTime birthYear)
        {
            this.name = name;
            this.birthYear = birthYear;
        }

        public int Age()
        {
            int age = DateTime.Now.Year - birthYear.Year;
            if (DateTime.Now.DayOfYear < birthYear.DayOfYear)
                age--;
            return age;
        }

        public void ChangeName(string newName)
        {
            name = newName;
        }

        public void Input()
        {
            Console.Write("Введіть ім'я: ");
            name = Console.ReadLine();
            Console.Write("Введіть рік народження (рік): ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Введіть місяць народження: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Введіть день народження: ");
            int day = int.Parse(Console.ReadLine());
            birthYear = new DateTime(year, month, day);
        }

        public override string ToString()
        {
            return $"Ім'я: {name}, Рік народження: {birthYear.Year}, Вік: {Age()}";
        }

        public void Output()
        {
            Console.WriteLine(ToString());
        }

        public static bool operator ==(Person p1, Person p2)
        {
            return p1.name == p2.name;
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                return name == person.name;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[6];
            people[0] = new Person("Олександр", new DateTime(2005, 6, 12));
            people[1] = new Person("Іван", new DateTime(2010, 3, 24));
            people[2] = new Person("Марія", new DateTime(2015, 7, 19));
            people[3] = new Person("Олександр", new DateTime(2008, 1, 1));
            people[4] = new Person("Анна", new DateTime(2003, 5, 9));
            people[5] = new Person();
            people[5].Input();

            Console.WriteLine("\nІм'я та вік кожної особи:");
            for (int i = 0; i < people.Length; i++)
            {
                Console.WriteLine($"{people[i].Name} - Вік: {people[i].Age()}");
            }

            for (int i = 0; i < people.Length; i++)
            {
                if (people[i].Age() < 16)
                {
                    people[i].ChangeName("Very Young");
                }
            }

            Console.WriteLine("\nІнформація про всіх осіб після заміни імені:");
            for (int i = 0; i < people.Length; i++)
            {
                people[i].Output();
            }

            Console.WriteLine("\nОсоби з однаковими іменами:");
            for (int i = 0; i < people.Length; i++)
            {
                for (int j = i + 1; j < people.Length; j++)
                {
                    if (people[i] == people[j])
                    {
                        Console.WriteLine($"Збіг імен для:");
                        people[i].Output();
                        people[j].Output();
                        Console.WriteLine();
                    }
                }
            }
        }
    }

