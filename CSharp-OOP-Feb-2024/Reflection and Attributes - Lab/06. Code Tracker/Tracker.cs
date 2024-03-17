using System.Reflection;

namespace AuthorProblem;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        PrintMethodsByType(typeof(StartUp));
    }

    private void PrintMethodsByType(Type type)
    {
        MethodInfo[] methods = type.GetMethods();
        foreach (MethodInfo method in methods)
        {
            List<AuthorAttribute> attributes =
                type.GetCustomAttributes<AuthorAttribute>().ToList();
            if (attributes.Count > 0)
            {
                foreach (var authorAttribute in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {authorAttribute.Name}");
                }
            }
        }
    }
}