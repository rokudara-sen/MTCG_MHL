using MTCG_MHL.Enums;

namespace MTCG_MHL.Models.Cards.Monsters;

public class Knight : MonsterCard
{
    public Knight(ElementType elementType, VisibleName visibleName, int baseDamage, int cardRarity, int monsterHealth) : base(elementType, CardName.Knight, baseDamage, cardRarity, monsterHealth, visibleName)
    {
    }
}