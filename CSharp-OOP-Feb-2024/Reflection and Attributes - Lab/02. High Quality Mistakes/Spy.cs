using System.Reflection;
using System.Text;

namespace Stealer;

public class Spy
{
    public string AnalyzeAcessModifiers(string investigatedClass)
    {
        Type classType = Type.GetType(investigatedClass);
        FieldInfo[] classFields =
            classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();
        foreach (FieldInfo field in classFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo methodInfo in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{methodInfo.Name} have to be public!");
        }

        foreach (MethodInfo methodInfo in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{methodInfo.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }
}