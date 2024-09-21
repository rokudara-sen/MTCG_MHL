using MTCG_MHL.Enums;

namespace MTCG_MHL.Models.Cards.Monsters;

public class Wizard : MonsterCard
{
    public Wizard(ElementType elementType, VisibleName visibleName, int baseDamage, int cardRarity, int monsterHealth) : base(elementType, CardName.Wizard, baseDamage, cardRarity, monsterHealth, visibleName)
    {
    }
}