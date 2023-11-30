using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _07_Invoking_EXE__06__That_Prevents_Reflection_Being_Used
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string relative_address = "..\\..\\..\\06 EXE - Protected Against Reflection Using Attributes\\bin\\Debug\\06 EXE - Protected Against Reflection Using Attributes.exe";
            string full_path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), relative_address);

            Console.WriteLine("Execution Of Internal Constructor: ");
            Assembly assembly = Assembly.LoadFile(full_path);
            Type programType = assembly.GetType("_06_EXE___No_Protection_Against_Reflection.Internal_Class");
            Object programObject = Activator.CreateInstance(programType as Type, true);

            Console.WriteLine("");

            Console.WriteLine("Execution Of Private Method: ");
            MethodInfo testMethod = programType.GetMethod("Private_Method", BindingFlags.NonPublic | BindingFlags.Instance);
            testMethod.Invoke(programObject, null);

            Console.ReadLine();

        }
    }
}
