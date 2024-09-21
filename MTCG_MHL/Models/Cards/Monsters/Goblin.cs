using MTCG_MHL.Enums;

namespace MTCG_MHL.Models.Cards.Monsters;

public class Goblin : MonsterCard
{
    public Goblin(ElementType elementType, VisibleName visibleName, int baseDamage, int cardRarity, int monsterHealth) : base(elementType, CardName.Goblin, baseDamage, cardRarity, monsterHealth, visibleName)
    {
    }
}