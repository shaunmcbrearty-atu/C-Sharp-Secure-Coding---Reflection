using System.Reflection;

class Program
{

    static void Main(string[] args)
    {

        string relative_address = "..\\..\\..\\..\\03 EXE - Protected Against Reflection\\bin\\Debug\\net7.0\\03 EXE - Protected Against Reflection.dll";
        string full_path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), relative_address);

        Console.WriteLine("Execution Of Internal Constructor: ");
        Assembly assembly = Assembly.LoadFile(full_path);
        Type programType = assembly.GetType("_03_EXE___Protected_Against_Reflection.Internal_Class");
        Object programObject = Activator.CreateInstance(programType as Type, true);

        Console.WriteLine("");

        Console.WriteLine("Execution Of Private Method: ");
        MethodInfo testMethod = programType.GetMethod("Private_Method", BindingFlags.NonPublic | BindingFlags.Instance);
        testMethod.Invoke(programObject, null);
        
        Console.ReadLine();

    }

}