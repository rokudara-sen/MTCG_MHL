using MTCG_MHL.Enums;

namespace MTCG_MHL.Models.Cards.Monsters;

public class Ork : MonsterCard
{
    public Ork(ElementType elementType, VisibleName visibleName, int baseDamage, int cardRarity, int monsterHealth) : base(elementType, CardName.Ork, baseDamage, cardRarity, monsterHealth, visibleName)
    {
    }
}