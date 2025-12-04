using System.Reflection;

class Program
{

    static void Main(string[] args)
    {

        string relative_address = "..\\..\\..\\..\\01 EXE - No Protection Against Reflection\\bin\\Debug\\net9.0\\01 EXE - No Protection Against Reflection.dll";//Address Of Target Assembly
        string full_path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), relative_address);

        Console.WriteLine("Execution Of Internal Constructor: ");
        Assembly assembly = Assembly.LoadFile(full_path);//Load Assembly
        Type programType = assembly.GetType("_01_EXE___No_Protection_Against_Reflection.Internal_Class");//Retrieve Internal_Class From Assembly.
        Object programObject = Activator.CreateInstance(programType as Type, true);//Create Instance of Internal_Class.

        Console.WriteLine("");//Formatting

        Console.WriteLine("Execution Of Private Method: ");
        MethodInfo testMethod = programType.GetMethod("Private_Method", BindingFlags.NonPublic | BindingFlags.Instance);//Load Private_Method Method Into Memory.
        testMethod.Invoke(programObject, null);//Execute Private_Method On Internal_Class Object | null => Method With No Parameters)

        Console.ReadLine();//Formatting - Pause Application

    }

}