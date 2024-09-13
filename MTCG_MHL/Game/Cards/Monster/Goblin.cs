using System.Globalization;
using MTCG_MHL.Interface;
using MTCG_MHL.Game;

namespace MTCG_MHL.Game.Cards.Monster;

public class Goblin : Card, Interface.IMonster
{
    public Goblin(string elementType)
    {
        ElementType = elementType;
        CardName = "Goblin";
        MonsterHealth = 5;
        MonsterDamage = 5;
    }
    
    public int MonsterHealth { get; set; }
    public int MonsterDamage { get; set; }

    public override void AttackTarget(Card card)
    {
        if (card is IMonster monster)
        {
            monster.ReceiveDamage(CardSpecialEffect(card, MonsterDamage));
            Console.WriteLine("{0} does {1} damage to {2}.\n", CardName, CardSpecialEffect(card, MonsterDamage), card.CardName);
        }
        else if (card is ISpell spell)
        {
            Console.WriteLine("Cannot attack a spell.\n");
        }
    }

    protected override int CardSpecialEffect(Card card, int damage)
    {
        if (card.CardName == "Dragon")
        {
            return 0;
        }
        else
        {
            return damage;
        }
    }

    public void ReceiveDamage(int damage)
    {
        MonsterHealth -= damage;
    }
}