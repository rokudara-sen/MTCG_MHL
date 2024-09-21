using MTCG_MHL.Enums;

namespace MTCG_MHL.Models.Cards.Monsters;

public class Dragon : MonsterCard
{
    public Dragon(ElementType elementType, VisibleName visibleName, int baseDamage, int cardRarity, int monsterHealth) : base(elementType, CardName.Dragon, baseDamage, cardRarity, monsterHealth, visibleName)
    {
    }
}