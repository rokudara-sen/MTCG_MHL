using System.Globalization;
using MTCG_MHL.Interface;
using MTCG_MHL.Game;

namespace MTCG_MHL.Game.Cards.Monster;

public class Goblin : Card, IMonster
{
    public Goblin(string elementType)
    {
        ElementType = elementType;
        CardName = "Goblin";
        MonsterHealth = 15;
        CardDamage = 5;
    }
    
    public int MonsterHealth { get; set; }
    

    protected override int CardSpecialEffect(Card card, int damage)
    {
        switch (card.CardName)
        {
            case "Wizard":
                return damage;
            case "Ork":
                return damage;
            case "Dragon":
                return 0;
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

    public void ReceiveDamage(int damage)
    {
        MonsterHealth -= damage;
    }
}