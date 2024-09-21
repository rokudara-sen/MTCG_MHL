using MTCG_MHL.Enums;

namespace MTCG_MHL.Models.Cards.Spells;

public class Tsunami : SpellCard
{
    public Tsunami(ElementType elementType, VisibleName visibleName, int baseDamage, int cardRarity, string specialEffect) : base(elementType, CardName.Tsunami, baseDamage, cardRarity, specialEffect, visibleName)
    {
    }
}