using MTCG_MHL.Enums;

namespace MTCG_MHL.Models.Cards.Spells;

public class FlyingPunch : SpellCard
{
    public FlyingPunch(ElementType elementType, VisibleName visibleName, int baseDamage, int cardRarity, string specialEffect) : base(elementType, CardName.FlyingPunch, baseDamage, cardRarity, specialEffect, visibleName)
    {
    }
}