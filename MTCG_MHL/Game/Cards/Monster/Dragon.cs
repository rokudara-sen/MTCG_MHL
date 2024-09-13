using MTCG_MHL.Interface;

namespace MTCG_MHL.Game.Cards.Monster;

public class Dragon : Card, IMonster
{
    public Dragon(string elementType)
    {
        ElementType = elementType;
        CardName = "Dragon";
        MonsterHealth = 20;
        MonsterDamage = 5;
    }
    
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
        return damage;
    }

    public int MonsterHealth { get; set; }
    public int MonsterDamage { get; set; }
    public void ReceiveDamage(int damage)
    {
        MonsterHealth -= damage;
    }
}