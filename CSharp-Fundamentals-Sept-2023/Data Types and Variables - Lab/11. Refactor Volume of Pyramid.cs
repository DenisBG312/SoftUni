double length = double.Parse(Console.ReadLine());
double width = double.Parse(Console.ReadLine());
double height = double.Parse(Console.ReadLine());

height = (length * width * height) / 3;

Console.Write($"Length: Width: Height: Pyramid Volume: {height:f2}");
