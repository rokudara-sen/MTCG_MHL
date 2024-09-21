using MTCG_MHL.Enums;

namespace MTCG_MHL.Models.Cards.Monsters;

public class Elf : MonsterCard
{
    public Elf(ElementType elementType, VisibleName visibleName, int baseDamage, int cardRarity, int monsterHealth) : base(elementType, CardName.Elf, baseDamage, cardRarity, monsterHealth, visibleName)
    {
    }
}