//#define INHERITANCE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;    //Input/Output
using System.Diagnostics;   //Для запуска других программ при помощи класса 'Process';

namespace Academy
{
    class Program
    {
        static readonly string delimiter = "\n----------------------------------------------\n";
        static void Main(string[] args)
        {

#if INHERITANCE
			Human human = new Human("Montana", "Antonio", 25);
			human.Info();
			Console.WriteLine(delimiter);

			Student student = new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 95, 96);
			student.Info();
			Console.WriteLine(delimiter);

			Teacher teacher = new Teacher("White", "Walter", 50, "Chemistry", 25);
			teacher.Info();
			Console.WriteLine(delimiter);

			Human tommy = new Human("Vercetty", "Tommy", 30);
			tommy.Info();
			Console.WriteLine(delimiter);

			Student s_tommy = new Student(tommy, "Theft", "Vice", 95, 98);
			s_tommy.Info();
			Console.WriteLine(delimiter);

			Graduate g_tommy = new Graduate(s_tommy, "How to make money");
			g_tommy.Info();
			Console.WriteLine(delimiter);

			Graduate graduate = new Graduate("Schreder", "Hank", 40, "Criminalistic", "OBN", 70, 80, "How to catch Heizenberg");
			graduate.Info();
			Console.WriteLine(delimiter); 
#endif

            //Generalization (Обобщение):
            Human[] group = new Human[]
            {
                new Student("Goodman", "Saul", 38, "Law", "JBC_001", 88, 91),
                new Teacher("Smith", "John", 45, "Mathematics", 30),
                new Graduate("Taylor", "Alex", 24, "Physics", "QuantumLab", 89, 93, "Dark Matter Research"),
                new Graduate("Murphy", "Emma", 31, "Biology", "GeneticsDept", 78, 85, "CRISPR Applications"),
                new Teacher("Lee", "Bruce", 42, "Philosophy", 18),
                new Specialist("Kovalsky", "Victor", 35, "Software Engineering", "DevMasters", 94, 92, "AI in Medicine", 5.5, "TechNova"),
                new Specialist("Orlova", "Natalia", 29, "Data Science", "DataPros", 87, 90, "Big Data Analytics", 3.2, "DataCore")
            };

            //Specialization (Уточнение):
            for (int i = 0; i < group.Length; i++)
            {
                Console.WriteLine(group[i]);
                //group[i].Info();
                //Console.WriteLine(delimiter);
            }
            ///////////////////////////////////////////////

            StreamWriter sw = new StreamWriter("Group.txt");    //Создаем и открываем поток

            for (int i = 0; i < group.Length; i++)
            {
                sw.WriteLine(group[i].ToFileString());
            }

            sw.Close(); //Потоки обязательно нужно закрывать!!!

            Process.Start("notepad.exe", "Group.txt");

            //CSV - Comma Separated Values (Значения раздеренные запятой);

            List<Human> loadedGroupList = new List<Human>();
            using (StreamReader sr = new StreamReader("Group.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length < 4) continue; // Skip invalid lines

                    string typeName = parts[0];
                    Human human = null;

                    switch (typeName)
                    {
                        case "Human":
                            human = Human.FromFileString(line);
                            break;
                        case "Student":
                            human = Student.FromFileString(line);
                            break;
                        case "Teacher":
                            human = Teacher.FromFileString(line);
                            break;
                        //case "Graduate":
                        //    human = Graduate.FromFileString(line);
                        //    break;
                    }

                    if (human != null)
                    {
                        loadedGroupList.Add(human);
                    }
                }
            }

            Human[] loadedGroup = loadedGroupList.ToArray();

            Console.WriteLine("\nLoaded Group:");
            for (int i = 0; i < loadedGroup.Length; i++)
            {
                Console.WriteLine(loadedGroup[i]);
                Console.WriteLine(delimiter);
            }

            Console.ReadKey();
        }
    }
}