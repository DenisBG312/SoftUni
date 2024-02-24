using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            BladeKnight bladeKnight = new BladeKnight("Denis", 10);
            Console.WriteLine(bladeKnight);
        }
    }
}