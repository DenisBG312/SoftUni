int numCenturies = int.Parse(Console.ReadLine());

int years = numCenturies * 100;
int days = (int)(years * 365.2422);
int hours = days * 24;
int minutes = hours * 60;

Console.WriteLine($"{numCenturies} centuries = {years} years = {days:f0} days = {hours} hours = {minutes} minutes");

