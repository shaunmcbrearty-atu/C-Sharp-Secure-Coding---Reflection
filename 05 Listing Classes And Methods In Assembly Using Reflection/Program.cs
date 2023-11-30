using System.Reflection;

class Program
{

    static void Main(string[] args)
    {

        //Adapted From: https://stackoverflow.com/questions/38909666/how-to-use-reflection-in-c-sharp-to-extract-class-and-method-information-from-ex

        string relative_address = "..\\..\\..\\..\\03 EXE - Protected Against Reflection\\bin\\Debug\\net7.0\\03 EXE - Protected Against Reflection.dll";
        string full_path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), relative_address);
        var assembly = Assembly.LoadFile(full_path);

        foreach (var type in assembly.GetTypes())
        {

            Console.WriteLine("Class {" + type.Name + "}:");
            Console.WriteLine("  Namespace: {" + type.Namespace + "}");
            Console.WriteLine("  Full name: {" + type.FullName + "}");

            Console.WriteLine("  Methods:");
            foreach (var methodInfo in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                Console.WriteLine("    Method {" + methodInfo.Name + "}");

                if (methodInfo.IsPublic)//Method With public Access Modifier
                    Console.WriteLine("      Public");

                if (methodInfo.IsFamily)//Method With protected Access Modifier
                    Console.WriteLine("      Protected");

                if (methodInfo.IsAssembly)//Method With internal Access Modifier
                    Console.WriteLine("      Internal");

                if (methodInfo.IsPrivate)//Method With private Access Modifier
                    Console.WriteLine("      Private");

                Console.WriteLine("      ReturnType {" + methodInfo.ReturnType + "}");

                Console.WriteLine("      Arguments {" + string.Join(", ", methodInfo.GetParameters().Select(x => x.ParameterType.ToString()).ToArray()) + "}");

            }

        }

        Console.ReadLine();

    }

}