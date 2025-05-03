//#define DATA_TYPES

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {

//#if DATA_TYPES
//            Console.WriteLine("DataTypes");
//            Console.WriteLine(typeof(sbyte));
//            Console.WriteLine(sizeof(byte));
//            Console.WriteLine($"Byte:  {byte.MinValue} ... {byte.MaxValue}");
//            Console.WriteLine($"SByte:{sbyte.MinValue}... {sbyte.MaxValue}"); 
//#endif

            Console.WriteLine("Hello Constants");
            Console.WriteLine($"Имя: { '+'.GetType(),-15} Размер: {sizeof(Char),-3} От: {Char.MinValue} До: {Char.MaxValue}");
            Console.WriteLine($"Имя: {5.GetType(),-15} Размер: {sizeof(int),-3} От: {int.MinValue} До: {int.MaxValue}");
            Console.WriteLine($"Имя: {true.GetType(),-15} Размер: {sizeof(bool),-3} От: {false} До: {true}");
            Console.WriteLine($"Имя: {5.4.GetType(),-15} Размер: {sizeof(double),-3} От: {double.MinValue} До: {double.MaxValue}");
            Console.WriteLine($"Имя: {typeof(uint).FullName,-15} Размер: {sizeof(uint),-3} От: {uint.MinValue} До: {uint.MaxValue}");
            

            int a = -2;
            uint b = (uint)a;
            //C-like notation (C-подобная форма записи)
            Console.ReadLine();
        }
    }
}
