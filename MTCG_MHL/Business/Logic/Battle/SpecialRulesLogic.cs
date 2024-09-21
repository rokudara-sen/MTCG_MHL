using MTCG_MHL.Enums;
using MTCG_MHL.Models.Cards;
using MTCG_MHL.Models.Cards.Monsters;

namespace MTCG_MHL.Business.Logic.Battle;

public class SpecialRulesLogic
{
    public SpecialRuleOutcome CheckSpecialRules(Card attacker, Card defender)
    {
        if (attacker is Goblin && defender is Dragon)
        {
            Console.WriteLine("Goblin is too afraid of the Dragon to attack!\n");
            return SpecialRuleOutcome.NoDamage;
        }

        if (defender is Wizard && attacker is Ork)
        {
            Console.WriteLine("Wizard controls the Ork which renders him unable to attack the Wizard\n");
            return SpecialRuleOutcome.NoDamage;
        }

        if (defender is Knight && attacker is SpellCard && attacker.ElementType == ElementType.Water)
        {
            Console.WriteLine("The Knight's armor renders him unable to swim and drowns to death\n");
            return SpecialRuleOutcome.InstantDeath;
        }

        if (defender is Kraken && attacker is SpellCard)
        {
            Console.WriteLine("The Kraken is immune to spells.\n");
            return SpecialRuleOutcome.Immunity;
        }

        if (attacker is Dragon && defender is Elf && attacker.ElementType == ElementType.Fire)
        {
            Console.WriteLine("Fire Elves are able to evade the dragons attack.\n");
            return SpecialRuleOutcome.NoDamage;
        }

        if (attacker is Knight && defender is Dragon)
        {
            Console.WriteLine("Knights know how to fight dragons dealing twice as much damage.\n");
            return SpecialRuleOutcome.DoubleDamage;
        }

        if (attacker is Wizard && defender is Elf)
        {
            Console.WriteLine("Wizards are stunned by the elven beauty and deal half damage.\n");
            return SpecialRuleOutcome.HalfDamage;
        }
        return SpecialRuleOutcome.NoEffect;
    }
}