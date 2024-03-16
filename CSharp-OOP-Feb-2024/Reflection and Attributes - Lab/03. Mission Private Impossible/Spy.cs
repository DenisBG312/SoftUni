using System.Reflection;
using System.Text;

namespace Stealer;

public class Spy
{
    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All private Methods of Class: {className}");
        sb.AppendLine($"Base class: {classType.BaseType.Name}");

        foreach (MethodInfo classMethod in classMethods)
        {
            sb.AppendLine(classMethod.Name);
        }

        return sb.ToString().Trim();
    }
}