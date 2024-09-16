using MTCG_MHL.Interface;

namespace MTCG_MHL.Game;

public abstract class Card
{
    
    public enum Effectiveness
    {
        NoEffect = 1,
        NotEffective = 0,
        Effective = 2,
        Error = -1
    }

    public string ElementType { get; protected set; }

    public string CardName { get; protected set; }
    
    public int CardDamage { get; protected set; }

    public void AttackTarget(Card card)
    {
        if (card is IMonster monster)
        {
            monster.ReceiveDamage(CardSpecialEffect(card, CardDamage));
            Console.WriteLine("{0} does {1} damage to {2}.\n", CardName, CardSpecialEffect(card, CardDamage), card.CardName);
        }
        else if (card is ISpell spell)
        {
            Console.WriteLine("Cannot attack a spell.\n");
        }
    }
    
    protected Effectiveness CheckEffectiveness(Card card)
    {
        if (ElementType == "Fire")
        {
            switch (card.ElementType)
            {
                case "Fire":
                    return Effectiveness.NoEffect;
                case "Water":
                    return Effectiveness.NotEffective;
                case "Normal":
                    return Effectiveness.Effective;
                default:
                    return Effectiveness.Error;
            }
        }
        if (ElementType == "Water")
        {
            switch (card.ElementType)
            {
                case "Fire":
                    return Effectiveness.Effective;
                case "Water":
                    return Effectiveness.NoEffect;
                case "Normal":
                    return Effectiveness.NotEffective;
                default:
                    return Effectiveness.Error;
            }
        }
        if (ElementType == "Normal")
        {
            switch (card.ElementType)
            {
                case "Fire":
                    return Effectiveness.NotEffective;
                case "Water":
                    return Effectiveness.Effective;
                case "Normal":
                    return Effectiveness.NoEffect;
                default:
                    return Effectiveness.Error;
            }
        }
        return Effectiveness.Error;
    }
    
    protected virtual int CardSpecialEffect(Card card, int damage)
    {
        if (CheckEffectiveness(card) == Effectiveness.Effective)
            return CardDamage * 2;
        if (CheckEffectiveness(card) == Effectiveness.NoEffect)
            return CardDamage;
        if (CheckEffectiveness(card) == Effectiveness.NotEffective)
            return CardDamage / 2;
        if (CheckEffectiveness(card) == Effectiveness.Error)
            return -1;
        return -1;
    }
}