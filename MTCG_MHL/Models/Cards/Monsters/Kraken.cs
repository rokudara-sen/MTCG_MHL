using MTCG_MHL.Enums;

namespace MTCG_MHL.Models.Cards.Monsters;

public class Kraken : MonsterCard
{
    public Kraken(ElementType elementType, VisibleName visibleName, int baseDamage, int cardRarity, int monsterHealth) : base(elementType, CardName.Kraken, baseDamage, cardRarity, monsterHealth, visibleName)
    {
    }
}