using System.Reflection;
using System.Text;

namespace Stealer;

public class Spy
{
    public string StealFieldInfo(string className,params string[] fieldsToInvestigate)
    {
        Type type = Type.GetType(className);
        FieldInfo[] classFields = type.GetFields(BindingFlags.Instance | BindingFlags.Static |
                                                 BindingFlags.NonPublic | BindingFlags.Public);
        StringBuilder sb = new StringBuilder();

        Object classInstance = Activator.CreateInstance(type, new object[] { });
        sb.AppendLine($"Class under investigation: {className}");

        foreach (FieldInfo fieldInfo in classFields.Where(f => fieldsToInvestigate.Contains(f.Name)))
        {
            sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();

    }
}