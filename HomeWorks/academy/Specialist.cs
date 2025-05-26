using Academy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
    class Specialist : Graduate
    {
        public double Expirience;
        public string Firm;
        public Specialist(string last_name, string first_name, int age,
            string speciality, string group, double rating, double attendance,
            string subject, double expirience, string firm
            ) : base(last_name, first_name, age, speciality, group, rating, attendance, subject)
        {
            Expirience = expirience;
            Firm = firm;
            Console.WriteLine($"SConstructor\t:{this.GetHashCode()}");
        }
        public Specialist(Graduate graduate, double expirience, string firm) : base(graduate)
        {
            Expirience = expirience;
            Firm = firm;
            Console.WriteLine($"GConstructor:{this.GetHashCode()}");
        }
        ~Specialist()
        {
            Console.WriteLine($"GDestructor:{this.GetHashCode()}");
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"\t{Expirience}");
            Console.WriteLine($"\t{Firm}");
        }

        public override string ToString()
        {
            return base.ToString() + Convert.ToString(Expirience)+Firm;
        }
        public override string ToFileString()
        {
            return base.ToFileString() + $",{Expirience}"+$",{Firm}";
        }

        public static Specialist FromFileString(string line)
        {
            string[] parts = line.Split(',');
            if (parts.Length != 10) return null;

            string lastName = parts[1];
            string firstName = parts[2];
            if (!int.TryParse(parts[3], out int age)) return null;
            string speciality = parts[4];
            string group = parts[5];
            if (!double.TryParse(parts[6], out double rating)) return null;
            if (!double.TryParse(parts[7], out double attendance)) return null;
            string subject = parts[8];
            if (!double.TryParse(parts[9], out double expirience)) return null;
            string firm = parts[10];

            return new Specialist(firstName, lastName, age, speciality, group, rating, attendance, subject, expirience, firm);
        }
    }
}
