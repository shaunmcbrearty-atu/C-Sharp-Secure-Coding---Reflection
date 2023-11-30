using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace _03_EXE___Protected_Against_Reflection
{
    internal class Internal_Class
    {

        internal Internal_Class()//Should Only Be Invoked By Classes Contained Within The Same DLL
        {
            
            if (Verify_Calling_Method("03 EXE - Protected Against Reflection.dll", "Program", "Main") == true)
            {
                Console.WriteLine("Constructor With Internal Access Modifier (incl. Reflection Defenses).");
                Private_Method();
            }
            else
                throw new MethodAccessException();

        }

        private void Private_Method()//Should Only Be Invoked By The Constructor For Internal_Class.
        {
            if (Verify_Calling_Method("03 EXE - Protected Against Reflection.dll", "Internal_Class", ".ctor") == true)
                Console.WriteLine("Method With Private Access Modifier (incl. Reflection Defenses).");
            else
                throw new MethodAccessException();

        }

        private bool Verify_Calling_Method(string desiredAssesmblyName, string desiredClassName, string desiredMethodName, string desiredFileName = null, int desiredLineNo = 0)
        {

            /*
             * Retrieves The Second Most Recent Frame From The Call Stack, i.e. 
             * The Method Which Invoked The Constructor For Internal_Class Or
             * The Method Which Invoked The Private_Method Method.
            */

            StackFrame stackFrame = new StackFrame(2, true);

            /*
             * Retrieves The Name Of The "Calling Method", The Associated Class
             * As Well As The Name Of The Associated Assembly (DLL or EXE) - And
             * Compares These Against The Values Inputted Into The Method.
             * 
             * Note That This Can Be Further Expanded To Include The Full Path 
             * Of The Assembly (MethodBase.Module.FullyQualifiedName) - Or The
             * "Details" Associated With The Assembly - Such As Version No., Date
             * Modified, Signature/Hash Value, etc.
            */

            MethodBase actualCallingMethod = stackFrame.GetMethod();
            string actualCallingMethodName = actualCallingMethod.Name;
            string actualCallingClass = actualCallingMethod.ReflectedType.Name;
            string actualCallingAssembly = actualCallingMethod.Module.Name;

            //Check Calling Assembly

            bool assemblyMatch = false;

            if (desiredAssesmblyName != null)
                assemblyMatch = desiredAssesmblyName.Equals(actualCallingAssembly);
            else//NULL => No Check Required.
                assemblyMatch = true;

            //Check Calling Class

            bool classMatch = false;

            if (desiredClassName != null)
                classMatch = desiredClassName.Equals(actualCallingClass);
            else//NULL => No Check Required.
                classMatch = true;

            //Check Calling Method

            bool methodMatch = false;

            if (desiredMethodName != null)
                methodMatch = desiredMethodName.Equals(actualCallingMethodName);
            else//NULL => No Check Required.
                methodMatch = true;

            //Other Checks (Debug Builds Only)

            bool fileNameMatch = true;//Assume True Incase A Release Build Is Used
            bool lineNoMatch = true;

            if (stackFrame.HasSource() && desiredFileName != null)//If HasSource() == true => Debug Build => File Names And Line Numbers Can Also Be Used
            {
                string actualFileName = stackFrame.GetFileName().ToString();//If stackFrame.HasSource() == false => Result of GetFileName() Is null.
                string actualLineNo = stackFrame.GetFileLineNumber().ToString();//If stackFrame.HasSource() == false => Result of GetLineNumber() Is null.
                fileNameMatch = desiredFileName.Equals(actualFileName);
                lineNoMatch = desiredLineNo.Equals(actualLineNo);
                
            }
            
            return (assemblyMatch && classMatch && methodMatch && fileNameMatch && lineNoMatch);//If All TRUE, Result Is TRUE.


        }

    }
}
