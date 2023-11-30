using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_EXE___No_Protection_Against_Reflection
{
    internal class Internal_Class
    {

        internal Internal_Class()//Should Only Be Invoked By Classes Contained Within The Same DLL
        {
            Console.WriteLine("Constructor With Internal Access Modifier (incl. Reflection Defenses).");
            Private_Method();
        }

        private void Private_Method()//Should Only Be Invoked By The Constructor For Internal_Class.
        {
            Console.WriteLine("Method With Private Access Modifier (incl. Reflection Defenses).");
        }

    }
}
