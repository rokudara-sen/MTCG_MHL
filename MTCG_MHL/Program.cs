using MTCG_MHL.Game.Cards.Monster;
using System;
using MTCG_MHL.Game;

namespace MTCG_MHL;

class Program
{
    static void Main(string[] args)
    {
        Goblin goblin = new Goblin("Fire");
        Dragon dragon = new Dragon("Water");
        
        Console.WriteLine("Before attack:");
        Console.WriteLine("Goblin Health: {0}", goblin.MonsterHealth);
        Console.WriteLine("Dragon Health: {0}", dragon.MonsterHealth);
        Console.WriteLine();

        // Goblin attacks Dragon
        goblin.AttackTarget(dragon);

        // Display health after attack
        Console.WriteLine("After attack:");
        Console.WriteLine("Goblin Health: {0}", goblin.MonsterHealth);
        Console.WriteLine("Dragon Health: {0}", dragon.MonsterHealth);
    }
}