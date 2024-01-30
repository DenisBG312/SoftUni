
using _06._Speed_Racing;

namespace DefineClasses;
public class StartUp
{
    public static void Main(string[] args)
    {
        string input;
        Dictionary<string, Trainers> trainers = new Dictionary<string, Trainers>();
        List<Pokemon> pokemons = new List<Pokemon>();
        while ((input = Console.ReadLine()) != "Tournament")
        {
            string[] tokens = input.Split
                (" ", StringSplitOptions.RemoveEmptyEntries);

            string trainerName = tokens[0];
            string pokemonName = tokens[1];
            string pokemonElement = tokens[2];
            double pokemonHealth = double.Parse(tokens[3]);

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            if (!trainers.ContainsKey(trainerName))
            {
                Trainers trainer = new Trainers(trainerName);
                trainers.Add(trainerName, trainer);
            }
            trainers[trainerName].Pokemons.Add(pokemon);
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (tokens[0] == "Fire")
            {
                CheckPokemon(trainers, tokens);
            }
            else if (tokens[0] == "Water")
            {
                CheckPokemon(trainers, tokens);
            }
            else if (tokens[0] == "Electricity")
            {
                CheckPokemon(trainers, tokens);
            }
        }

        foreach (var trainer in trainers.Values.OrderByDescending(
                     x => x.NumberOfBadges))
        {
            Console.WriteLine(trainer.ToString());
        }
    }

    private static void CheckPokemon(Dictionary<string, Trainers> trainers, string[] tokens)
    {
        foreach (var trainer in trainers.Values)
        {
            if (trainer.Pokemons.Any(x => x.Element == tokens[0]))
            {
                trainer.NumberOfBadges++;
            }
            else
            {
                foreach (var pokemon in trainer.Pokemons)
                {
                    pokemon.Health -= 10;
                    if (pokemon.Health <= 0)
                    {
                        trainer.Pokemons.Remove(pokemon);
                        break;
                    }
                }
            }
        }
    }
}