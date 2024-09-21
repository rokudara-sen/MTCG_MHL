using MTCG_MHL.Enums;
using MTCG_MHL.Models.Cards;
using MTCG_MHL.Models.Cards.Monsters;

namespace MTCG_MHL.Business.Logic.Battle;

public class SpecialRulesLogic
{
    public bool CehckSpecialRules(Card attacker, Card defender)
    {
        if (attacker is Goblin && defender is Dragon)
        {
            Console.WriteLine("Goblin is too afraid of the Dragon to attack!\n");
            return true;
        }

        if (defender is Wizard && attacker is Ork)
        {
            Console.WriteLine("Wizard controls the Ork which renders him unable to attack the Wizard\n");
            return true;
        }

        if (defender is Knight && attacker is SpellCard && attacker.ElementType == ElementType.Water)
        {
            Console.WriteLine("The Knight's armor renders him unable to swim and drowns to death\n");
            return true;
        }

        if (defender is Kraken && attacker is SpellCard)
        {
            Console.WriteLine("The Kraken is immune to spells.\n");
            return true;
        }

        if (attacker is Dragon && defender is Elf && attacker.ElementType == ElementType.Fire)
        {
            Console.WriteLine("Fire Elves are able to evade the dragons attack.\n");
            return true;
        }
        return false;
    }
}