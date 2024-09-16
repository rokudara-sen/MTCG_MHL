using MTCG_MHL.Interface;

namespace MTCG_MHL.Game.Cards.Monster;

public class Wizard : Card, IMonster
{
    public Wizard(string elementType)
    {
        ElementType = elementType;
        CardName = "Wizard";
        MonsterHealth = 20;
        CardDamage = 5;
    }

    protected override int CardSpecialEffect(Card card, int damage)
    {
        switch (card.CardName)
        {
            case "Wizard":
                return damage;
            case "Ork":
                return damage;
            case "Dragon":
                return damage;
            case "Kraken":
                return damage;
            case "Goblin":
                return damage;
            case "Elf":
                return damage;
            case "Knight":
                return damage;
            default:
                return -1;
        }
    }

    public int MonsterHealth { get; set; }
    public void ReceiveDamage(int damage)
    {
        MonsterHealth -= damage;
    }
}