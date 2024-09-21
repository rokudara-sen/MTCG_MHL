using MTCG_MHL.Enums;

namespace MTCG_MHL.Models.Cards.Spells;

public class Ignitio : SpellCard
{
    public Ignitio(ElementType elementType, VisibleName visibleName, int baseDamage, int cardRarity, string specialEffect) : base(elementType, CardName.Ignitio, baseDamage, cardRarity, specialEffect, visibleName)
    {
    }
}